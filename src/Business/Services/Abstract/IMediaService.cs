using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IMediaService
{
    Task Create(MediaDTO MediaDto);
    Task<List<MediaDTO>> GetAllAsync(Expression<Func<Media, bool>>? expression = null, params Expression<Func<Media, object>>[] includes);
    Task<List<MediaDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Media, bool>>? expression = null, params Expression<Func<Media, object>>[] includes);
    Task<MediaDTO?> GetAsync(Expression<Func<Media, bool>>? expression = null, params Expression<Func<Media, object>>[] includes);
    void Remove(MediaDTO MediaDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(MediaDTO MediaDto);
}