using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IShippingService
{
    Task Create(ShippingDTO ShippingDto);
    Task<List<ShippingDTO>> GetAllAsync(Expression<Func<Shipping, bool>>? expression = null, params Expression<Func<Shipping, object>>[] includes);
    Task<List<ShippingDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Shipping, bool>>? expression = null, params Expression<Func<Shipping, object>>[] includes);
    Task<ShippingDTO?> GetAsync(Expression<Func<Shipping, bool>>? expression = null, params Expression<Func<Shipping, object>>[] includes);
    void Remove(ShippingDTO ShippingDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(ShippingDTO ShippingDto);
}