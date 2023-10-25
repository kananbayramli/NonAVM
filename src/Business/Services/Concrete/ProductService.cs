using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.Services.Concrete
{
    public class ProductService : IScoppedLifetime, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        IRepository<Product> _productRepository;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.Repository<Product>();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var dtos = products.Select(p => new ProductDTO { Id = p.Id, Name = p.Name });

            return dtos;
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            await _productRepository.Create(new Product { Name = productDTO.Name, CategoryID = 3 });
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
