using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IAddressService
{
    Task Create(AddressDTO storeDto);
    Task<List<AddressDTO>> GetAllAsync(Expression<Func<Address, bool>>? expression = null, params Expression<Func<Address, object>>[] includes);
    Task<List<AddressDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Address, bool>>? expression = null, params Expression<Func<Address, object>>[] includes);
    Task<AddressDTO?> GetAsync(Expression<Func<Address, bool>>? expression = null, params Expression<Func<Address, object>>[] includes);
    void Remove(AddressDTO storeDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(AddressDTO storeDto);
}