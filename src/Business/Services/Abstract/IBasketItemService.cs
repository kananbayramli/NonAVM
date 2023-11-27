using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IBasketItemService
{
    Task Create(BasketItemDTO BasketItemDto);
    Task<List<BasketItemDTO>> GetAllAsync(Expression<Func<BasketItem, bool>>? expression = null, params Expression<Func<BasketItem, object>>[] includes);
    Task<List<BasketItemDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<BasketItem, bool>>? expression = null, params Expression<Func<BasketItem, object>>[] includes);
    Task<BasketItemDTO?> GetAsync(Expression<Func<BasketItem, bool>>? expression = null, params Expression<Func<BasketItem, object>>[] includes);
    void Remove(BasketItemDTO BasketItemDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(BasketItemDTO BasketItemDto);
}