using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Concrete;

internal class ProductItemService : IScoppedLifetime, IProductItemService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<ProductItem> _productItemRepository;
    private readonly IMapper _mapper;

    public ProductItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productItemRepository = _unitOfWork.Repository<ProductItem>();
        _mapper = mapper;
    }


    public async Task<List<ProductItemDTO>> GetAllAsync(
        Expression<Func<ProductItem, bool>>? expression = null,
        params Expression<Func<ProductItem, object>>[] includes)
    {
        var productItems = await _productItemRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ProductItemDTO>>(productItems);
        return dtos;
    }

    public async Task<List<ProductItemDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<ProductItem, bool>>? expression = null,
        params Expression<Func<ProductItem, object>>[] includes)
    {
        var productItems = await _productItemRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ProductItemDTO>>(productItems);
        return dtos;
    }

    public async Task<ProductItemDTO?> GetAsync(
        Expression<Func<ProductItem, bool>>? expression = null,
        params Expression<Func<ProductItem, object>>[] includes)
    {
        var productItem = await _productItemRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ProductItemDTO>(productItem);
        return dto;
    }

    public async Task Create(ProductItemDTO productItemDto)
    {
        var productItem = _mapper.Map<ProductItem>(productItemDto);
        await _productItemRepository.Create(productItem);
    }

    public void Update(ProductItemDTO productItemDto)
    {
        var productItem = _mapper.Map<ProductItem>(productItemDto);
        _productItemRepository.Update(productItem);
    }

    public void Remove(ProductItemDTO productItemDto)
    {
        var productItem = _mapper.Map<ProductItem>(productItemDto);
        _productItemRepository.Remove(productItem);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _productItemRepository.SaveChangesAsync(cancellationToken);
    }
}
