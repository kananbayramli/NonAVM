using ECommerse.Core.Common;

namespace ECommerse.DataAccess.Repositories.Abstract;

public interface IUnitOfWork
{

    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task SaveChangesAsync();
}
