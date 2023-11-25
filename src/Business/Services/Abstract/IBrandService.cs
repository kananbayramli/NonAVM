using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract
{
    public interface IBrandService
    {
        Task Create(BrandDTO storeDto);
        Task<List<BrandDTO>> GetAllAsync(Expression<Func<Brand, bool>>? expression = null, params Expression<Func<Brand, object>>[] includes);
        Task<List<BrandDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Brand, bool>>? expression = null, params Expression<Func<Brand, object>>[] includes);
        Task<BrandDTO?> GetAsync(Expression<Func<Brand, bool>>? expression = null, params Expression<Func<Brand, object>>[] includes);
        void Remove(BrandDTO storeDto);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void Update(BrandDTO storeDto);
    }
}