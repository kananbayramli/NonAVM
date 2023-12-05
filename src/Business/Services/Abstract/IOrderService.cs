using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IOrderService
{
    Task Create(OrderDTO OrderDto);
    Task<List<OrderDTO>> GetAllAsync(Expression<Func<Order, bool>>? expression = null, params Expression<Func<Order, object>>[] includes);
    Task<List<OrderDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Order, bool>>? expression = null, params Expression<Func<Order, object>>[] includes);
    Task<OrderDTO?> GetAsync(Expression<Func<Order, bool>>? expression = null, params Expression<Func<Order, object>>[] includes);
    void Remove(OrderDTO OrderDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(OrderDTO OrderDto);
}