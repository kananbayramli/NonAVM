using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IBasketService
{
    Task Create(BasketDTO BasketDto);
    Task<List<BasketDTO>> GetAllAsync(Expression<Func<Basket, bool>>? expression = null, params Expression<Func<Basket, object>>[] includes);
    Task<List<BasketDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Basket, bool>>? expression = null, params Expression<Func<Basket, object>>[] includes);
    Task<BasketDTO?> GetAsync(Expression<Func<Basket, bool>>? expression = null, params Expression<Func<Basket, object>>[] includes);
    void Remove(BasketDTO BasketDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(BasketDTO BasketDto);
}