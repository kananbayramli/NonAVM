using ECommerse.Core.Common;
using ECommerse.DataAccess.Persistance;
using ECommerse.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerse.DataAccess.Repositories.Concrete;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly ECommerseDbContext _context;
    public Repository(ECommerseDbContext context)
    {
        _context = context;
    }
    public async Task Create(TEntity product)
    {
        await _context.Set<TEntity>().AddAsync(product);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = GetWithInclude(includes);
        return expression is null
            ? await query.ToListAsync()
            : await query.Where(expression).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>>? expression = null,
                                                          params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = GetWithInclude(includes);
        return expression is null
            ? await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync()
            : await query.Where(expression).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? expression = null,
                                         params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = GetWithInclude(includes);
        return expression is null
            ? await query.FirstOrDefaultAsync()
            : await query.FirstOrDefaultAsync(expression);
    }

    public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().AnyAsync(expression);
    }

    public void Remove(TEntity product)
    {
        _context.Set<TEntity>().Remove(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Update(TEntity product)
    {
        _context.Set<TEntity>().Update(product);
    }

    //private IQueryable<TEntity> GetQuery(params string[] includes)
    //{
    //    IQueryable<TEntity> query = _context.Set<TEntity>();
    //    foreach (var includeProperty in includes)
    //    {
    //        query = query.Include(includeProperty);
    //    }
    //    return query;
    //}

    private IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }
}
