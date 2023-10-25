using ECommerse.Business.DTO_s;

namespace ECommerse.Business.Services.Abstract
{
    public interface IProductService
    {
        Task AddProduct(ProductDTO productDTO);
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}