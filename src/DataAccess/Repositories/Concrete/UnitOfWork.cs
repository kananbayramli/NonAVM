using ECommerse.Core.Common;
using ECommerse.DataAccess.Persistance;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Collections;

namespace ECommerse.DataAccess.Repositories.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly ECommerseDbContext _context;
    private Hashtable _repositories;
    public UnitOfWork(ECommerseDbContext context)
    {
        _context = context;
    }
   
    public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        if (_repositories == null) _repositories = new Hashtable();
        var Type = typeof(TEntity).Name;
        if (!_repositories.ContainsKey(Type))
        {
            var repositiryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(
                repositiryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(Type, repositoryInstance);
        }
        return (IRepository<TEntity>)_repositories[Type];
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
