using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IProductReviewMediaService
{
    Task Create(ProductReviewMediaDTO ProductReviewMediaDto);
    Task<List<ProductReviewMediaDTO>> GetAllAsync(Expression<Func<ProductReviewMedia, bool>>? expression = null, params Expression<Func<ProductReviewMedia, object>>[] includes);
    Task<List<ProductReviewMediaDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<ProductReviewMedia, bool>>? expression = null, params Expression<Func<ProductReviewMedia, object>>[] includes);
    Task<ProductReviewMediaDTO?> GetAsync(Expression<Func<ProductReviewMedia, bool>>? expression = null, params Expression<Func<ProductReviewMedia, object>>[] includes);
    void Remove(ProductReviewMediaDTO ProductReviewMediaDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(ProductReviewMediaDTO ProductReviewMediaDto);
}