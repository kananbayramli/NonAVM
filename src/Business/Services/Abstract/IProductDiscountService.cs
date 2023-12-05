using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IProductDiscountService
{
    Task Create(ProductDiscountDTO ProductDiscountDto);
    Task<List<ProductDiscountDTO>> GetAllAsync(Expression<Func<ProductDiscount, bool>>? expression = null, params Expression<Func<ProductDiscount, object>>[] includes);
    Task<List<ProductDiscountDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<ProductDiscount, bool>>? expression = null, params Expression<Func<ProductDiscount, object>>[] includes);
    Task<ProductDiscountDTO?> GetAsync(Expression<Func<ProductDiscount, bool>>? expression = null, params Expression<Func<ProductDiscount, object>>[] includes);
    void Remove(ProductDiscountDTO ProductDiscountDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(ProductDiscountDTO ProductDiscountDto);
}