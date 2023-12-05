using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IPromoService
{
    Task Create(PromoDTO PromoDto);
    Task<List<PromoDTO>> GetAllAsync(Expression<Func<Promo, bool>>? expression = null, params Expression<Func<Promo, object>>[] includes);
    Task<List<PromoDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Promo, bool>>? expression = null, params Expression<Func<Promo, object>>[] includes);
    Task<PromoDTO?> GetAsync(Expression<Func<Promo, bool>>? expression = null, params Expression<Func<Promo, object>>[] includes);
    void Remove(PromoDTO PromoDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(PromoDTO PromoDto);
}