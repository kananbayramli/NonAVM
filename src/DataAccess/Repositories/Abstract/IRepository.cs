using ECommerse.Core.Common;
using System.Linq.Expressions;

namespace ECommerse.DataAccess.Repositories.Abstract;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null,
                                    params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> expression = null,
                                             params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null,
                           params Expression<Func<TEntity, object>>[] includes);
    Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);
    Task Create(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
