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
public class ShippingService : IShippingService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Shipping> _shippingRepository;
    private readonly IMapper _mapper;

    public ShippingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _shippingRepository = _unitOfWork.Repository<Shipping>();
        _mapper = mapper;
    }


    public async Task<List<ShippingDTO>> GetAllAsync(
        Expression<Func<Shipping, bool>>? expression = null,
        params Expression<Func<Shipping, object>>[] includes)
    {
        var Shippings = await _shippingRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ShippingDTO>>(Shippings);
        return dtos;
    }

    public async Task<List<ShippingDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Shipping, bool>>? expression = null,
        params Expression<Func<Shipping, object>>[] includes)
    {
        var Shippings = await _shippingRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ShippingDTO>>(Shippings);
        return dtos;
    }

    public async Task<ShippingDTO?> GetAsync(
        Expression<Func<Shipping, bool>>? expression = null,
        params Expression<Func<Shipping, object>>[] includes)
    {
        var Shipping = await _shippingRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ShippingDTO>(Shipping);
        return dto;
    }

    public async Task Create(ShippingDTO ShippingDto)
    {
        var Shipping = _mapper.Map<Shipping>(ShippingDto);
        await _shippingRepository.Create(Shipping);
    }

    public void Update(ShippingDTO ShippingDto)
    {
        var Shipping = _mapper.Map<Shipping>(ShippingDto);
        _shippingRepository.Update(Shipping);
    }

    public void Remove(ShippingDTO ShippingDto)
    {
        var Shipping = _mapper.Map<Shipping>(ShippingDto);
        _shippingRepository.Remove(Shipping);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _shippingRepository.SaveChangesAsync(cancellationToken);
    }
}
