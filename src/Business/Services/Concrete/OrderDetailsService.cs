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
public class OrderDetailsService : IOrderDetailsService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<OrderDetails> _orderDetailsRepository;
    private readonly IMapper _mapper;

    public OrderDetailsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _orderDetailsRepository = _unitOfWork.Repository<OrderDetails>();
        _mapper = mapper;
    }


    public async Task<List<OrderDetailsDTO>> GetAllAsync(
        Expression<Func<OrderDetails, bool>>? expression = null,
        params Expression<Func<OrderDetails, object>>[] includes)
    {
        var OrderDetailss = await _orderDetailsRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<OrderDetailsDTO>>(OrderDetailss);
        return dtos;
    }

    public async Task<List<OrderDetailsDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<OrderDetails, bool>>? expression = null,
        params Expression<Func<OrderDetails, object>>[] includes)
    {
        var OrderDetailss = await _orderDetailsRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<OrderDetailsDTO>>(OrderDetailss);
        return dtos;
    }

    public async Task<OrderDetailsDTO?> GetAsync(
        Expression<Func<OrderDetails, bool>>? expression = null,
        params Expression<Func<OrderDetails, object>>[] includes)
    {
        var OrderDetails = await _orderDetailsRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<OrderDetailsDTO>(OrderDetails);
        return dto;
    }

    public async Task Add(OrderDetailsDTO OrderDetailsDto)
    {
        var OrderDetails = _mapper.Map<OrderDetails>(OrderDetailsDto);
        await _orderDetailsRepository.Create(OrderDetails);
    }

    public async Task Create(OrderDetailsDTO OrderDetailsDto)
    {
        var OrderDetails = _mapper.Map<OrderDetails>(OrderDetailsDto);
        await _orderDetailsRepository.Create(OrderDetails);
        await SaveChangesAsync();
        _mapper.Map(OrderDetails, OrderDetailsDto);
    }

    public void Update(OrderDetailsDTO OrderDetailsDto)
    {
        var OrderDetails = _mapper.Map<OrderDetails>(OrderDetailsDto);
        _orderDetailsRepository.Update(OrderDetails);
    }

    public void Remove(OrderDetailsDTO OrderDetailsDto)
    {
        var OrderDetails = _mapper.Map<OrderDetails>(OrderDetailsDto);
        _orderDetailsRepository.Remove(OrderDetails);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _orderDetailsRepository.SaveChangesAsync(cancellationToken);
    }
}
