using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface ITrackingService
{
    Task Create(TrackingDTO TrackingDto);
    Task<List<TrackingDTO>> GetAllAsync(Expression<Func<Tracking, bool>>? expression = null, params Expression<Func<Tracking, object>>[] includes);
    Task<List<TrackingDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Tracking, bool>>? expression = null, params Expression<Func<Tracking, object>>[] includes);
    Task<TrackingDTO?> GetAsync(Expression<Func<Tracking, bool>>? expression = null, params Expression<Func<Tracking, object>>[] includes);
    void Remove(TrackingDTO TrackingDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(TrackingDTO TrackingDto);
}