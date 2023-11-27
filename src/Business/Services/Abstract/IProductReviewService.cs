using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IProductReviewService
{
    Task Create(ProductReviewDTO ProductReviewDto);
    Task<List<ProductReviewDTO>> GetAllAsync(Expression<Func<ProductReview, bool>>? expression = null, params Expression<Func<ProductReview, object>>[] includes);
    Task<List<ProductReviewDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<ProductReview, bool>>? expression = null, params Expression<Func<ProductReview, object>>[] includes);
    Task<ProductReviewDTO?> GetAsync(Expression<Func<ProductReview, bool>>? expression = null, params Expression<Func<ProductReview, object>>[] includes);
    void Remove(ProductReviewDTO ProductReviewDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(ProductReviewDTO ProductReviewDto);
}