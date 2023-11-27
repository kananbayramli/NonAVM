using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IDiscountService
{
    Task Create(DiscountDTO DiscountDto);
    Task<List<DiscountDTO>> GetAllAsync(Expression<Func<Discount, bool>>? expression = null, params Expression<Func<Discount, object>>[] includes);
    Task<List<DiscountDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Discount, bool>>? expression = null, params Expression<Func<Discount, object>>[] includes);
    Task<DiscountDTO?> GetAsync(Expression<Func<Discount, bool>>? expression = null, params Expression<Func<Discount, object>>[] includes);
    void Remove(DiscountDTO DiscountDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(DiscountDTO DiscountDto);
}