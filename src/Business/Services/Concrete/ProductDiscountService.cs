using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.Services.Concrete;
public class ProductDiscountService : IProductDiscountService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<ProductDiscount> _productDiscountRepository;
    private readonly IMapper _mapper;

    public ProductDiscountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productDiscountRepository = _unitOfWork.Repository<ProductDiscount>();
        _mapper = mapper;
    }


    public async Task<List<ProductDiscountDTO>> GetAllAsync(
        Expression<Func<ProductDiscount, bool>>? expression = null,
        params Expression<Func<ProductDiscount, object>>[] includes)
    {
        var ProductDiscounts = await _productDiscountRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ProductDiscountDTO>>(ProductDiscounts);
        return dtos;
    }

    public async Task<List<ProductDiscountDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<ProductDiscount, bool>>? expression = null,
        params Expression<Func<ProductDiscount, object>>[] includes)
    {
        var ProductDiscounts = await _productDiscountRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ProductDiscountDTO>>(ProductDiscounts);
        return dtos;
    }

    public async Task<ProductDiscountDTO?> GetAsync(
        Expression<Func<ProductDiscount, bool>>? expression = null,
        params Expression<Func<ProductDiscount, object>>[] includes)
    {
        var ProductDiscount = await _productDiscountRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ProductDiscountDTO>(ProductDiscount);
        return dto;
    }

    public async Task Create(ProductDiscountDTO ProductDiscountDto)
    {
        var ProductDiscount = _mapper.Map<ProductDiscount>(ProductDiscountDto);
        await _productDiscountRepository.Create(ProductDiscount);
    }

    public void Update(ProductDiscountDTO ProductDiscountDto)
    {
        var ProductDiscount = _mapper.Map<ProductDiscount>(ProductDiscountDto);
        _productDiscountRepository.Update(ProductDiscount);
    }

    public void Remove(ProductDiscountDTO ProductDiscountDto)
    {
        var ProductDiscount = _mapper.Map<ProductDiscount>(ProductDiscountDto);
        _productDiscountRepository.Remove(ProductDiscount);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _productDiscountRepository.SaveChangesAsync(cancellationToken);
    }
}
