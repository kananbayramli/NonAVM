using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract
{
    public interface IProductItemService
    {
        Task Create(ProductItemDTO productItemDto);
        Task<List<ProductItemDTO>> GetAllAsync(Expression<Func<ProductItem, bool>>? expression = null, params Expression<Func<ProductItem, object>>[] includes);
        Task<List<ProductItemDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<ProductItem, bool>>? expression = null, params Expression<Func<ProductItem, object>>[] includes);
        Task<ProductItemDTO?> GetAsync(Expression<Func<ProductItem, bool>>? expression = null, params Expression<Func<ProductItem, object>>[] includes);
        void Remove(ProductItemDTO productItemDto);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void Update(ProductItemDTO productItemDto);
    }
}