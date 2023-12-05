using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IStoreReviewService
{
    Task Create(StoreReviewDTO StoreReviewDto);
    Task<List<StoreReviewDTO>> GetAllAsync(Expression<Func<StoreReview, bool>>? expression = null, params Expression<Func<StoreReview, object>>[] includes);
    Task<List<StoreReviewDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<StoreReview, bool>>? expression = null, params Expression<Func<StoreReview, object>>[] includes);
    Task<StoreReviewDTO?> GetAsync(Expression<Func<StoreReview, bool>>? expression = null, params Expression<Func<StoreReview, object>>[] includes);
    void Remove(StoreReviewDTO StoreReviewDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(StoreReviewDTO StoreReviewDto);
}