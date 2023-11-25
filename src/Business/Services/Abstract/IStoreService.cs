using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;

public interface IStoreService
{
    Task Create(StoreDTO StoreDto);
    Task<List<StoreDTO>> GetAllAsync(Expression<Func<Store, bool>>? expression = null, params Expression<Func<Store, object>>[] includes);
    Task<List<StoreDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Store, bool>>? expression = null, params Expression<Func<Store, object>>[] includes);
    Task<StoreDTO?> GetAsync(Expression<Func<Store, bool>>? expression = null, params Expression<Func<Store, object>>[] includes);
    void Remove(StoreDTO StoreDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(StoreDTO StoreDto);
}