using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IOrderDetailsService
{
    Task Create(OrderDetailsDTO OrderDetailsDto);
    Task<List<OrderDetailsDTO>> GetAllAsync(Expression<Func<OrderDetails, bool>>? expression = null, params Expression<Func<OrderDetails, object>>[] includes);
    Task<List<OrderDetailsDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<OrderDetails, bool>>? expression = null, params Expression<Func<OrderDetails, object>>[] includes);
    Task<OrderDetailsDTO?> GetAsync(Expression<Func<OrderDetails, bool>>? expression = null, params Expression<Func<OrderDetails, object>>[] includes);
    void Remove(OrderDetailsDTO OrderDetailsDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(OrderDetailsDTO OrderDetailsDto);
}