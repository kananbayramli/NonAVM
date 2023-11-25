using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Concrete;

public class ProductService : IScoppedLifetime, IProductService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = _unitOfWork.Repository<Product>();
        _mapper = mapper;
    }


    public async Task<List<ProductDTO>> GetAllAsync(
        Expression<Func<Product, bool>>? expression = null,
        params Expression<Func<Product, object>>[] includes)
    {
        var products = await _productRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ProductDTO>>(products);
        return dtos;
    }

    public async Task<List<ProductDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Product, bool>>? expression = null,
        params Expression<Func<Product, object>>[] includes)
    {
        var products = await _productRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ProductDTO>>(products);
        return dtos;
    }

    public async Task<ProductDTO?> GetAsync(
        Expression<Func<Product, bool>>? expression = null,
        params Expression<Func<Product, object>>[] includes)
    {
        var product = await _productRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ProductDTO>(product);
        return dto;
    }

    public async Task Create(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.Create(product);
    }

    public void Update(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productRepository.Update(product);
    }

    public void Remove(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productRepository.Remove(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _productRepository.SaveChangesAsync(cancellationToken);
    }
}
