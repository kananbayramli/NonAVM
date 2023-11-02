using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract
{
    public interface IProductService
    {
        Task Create(ProductDTO productDto);
        Task<List<ProductDTO>> GetAllAsync(Expression<Func<Product, bool>>? expression = null, params Expression<Func<Product, object>>[] includes);
        Task<List<ProductDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Product, bool>>? expression = null, params Expression<Func<Product, object>>[] includes);
        Task<ProductDTO?> GetAsync(Expression<Func<Product, bool>>? expression = null, params Expression<Func<Product, object>>[] includes);
        void Remove(ProductDTO productDto);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void Update(ProductDTO productDto);
    }
}