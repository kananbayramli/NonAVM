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
public class DiscountService : IDiscountService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Discount> _discountRepository;
    private readonly IMapper _mapper;

    public DiscountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _discountRepository = _unitOfWork.Repository<Discount>();
        _mapper = mapper;
    }


    public async Task<List<DiscountDTO>> GetAllAsync(
        Expression<Func<Discount, bool>>? expression = null,
        params Expression<Func<Discount, object>>[] includes)
    {
        var Discounts = await _discountRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<DiscountDTO>>(Discounts);
        return dtos;
    }

    public async Task<List<DiscountDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Discount, bool>>? expression = null,
        params Expression<Func<Discount, object>>[] includes)
    {
        var Discounts = await _discountRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<DiscountDTO>>(Discounts);
        return dtos;
    }

    public async Task<DiscountDTO?> GetAsync(
        Expression<Func<Discount, bool>>? expression = null,
        params Expression<Func<Discount, object>>[] includes)
    {
        var Discount = await _discountRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<DiscountDTO>(Discount);
        return dto;
    }

    public async Task Add(DiscountDTO DiscountDto)
    {
        var Discount = _mapper.Map<Discount>(DiscountDto);
        await _discountRepository.Create(Discount);
    }

    public async Task Create(DiscountDTO DiscountDto)
    {
        var Discount = _mapper.Map<Discount>(DiscountDto);
        await _discountRepository.Create(Discount);
        await SaveChangesAsync();
        _mapper.Map(Discount, DiscountDto);
    }

    public void Update(DiscountDTO DiscountDto)
    {
        var Discount = _mapper.Map<Discount>(DiscountDto);
        _discountRepository.Update(Discount);
    }

    public void Remove(DiscountDTO DiscountDto)
    {
        var Discount = _mapper.Map<Discount>(DiscountDto);
        _discountRepository.Remove(Discount);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _discountRepository.SaveChangesAsync(cancellationToken);
    }
}
