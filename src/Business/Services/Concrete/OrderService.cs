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
public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = _unitOfWork.Repository<Order>();
        _mapper = mapper;
    }


    public async Task<List<OrderDTO>> GetAllAsync(
        Expression<Func<Order, bool>>? expression = null,
        params Expression<Func<Order, object>>[] includes)
    {
        var Orders = await _orderRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<OrderDTO>>(Orders);
        return dtos;
    }

    public async Task<List<OrderDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Order, bool>>? expression = null,
        params Expression<Func<Order, object>>[] includes)
    {
        var Orders = await _orderRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<OrderDTO>>(Orders);
        return dtos;
    }

    public async Task<OrderDTO?> GetAsync(
        Expression<Func<Order, bool>>? expression = null,
        params Expression<Func<Order, object>>[] includes)
    {
        var Order = await _orderRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<OrderDTO>(Order);
        return dto;
    }

    public async Task Add(OrderDTO OrderDto)
    {
        var Order = _mapper.Map<Order>(OrderDto);
        await _orderRepository.Create(Order);
    }

    public async Task Create(OrderDTO OrderDto)
    {
        var Order = _mapper.Map<Order>(OrderDto);
        await _orderRepository.Create(Order);
        await SaveChangesAsync();
        _mapper.Map(Order, OrderDto);
    }

    public void Update(OrderDTO OrderDto)
    {
        var Order = _mapper.Map<Order>(OrderDto);
        _orderRepository.Update(Order);
    }

    public void Remove(OrderDTO OrderDto)
    {
        var Order = _mapper.Map<Order>(OrderDto);
        _orderRepository.Remove(Order);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _orderRepository.SaveChangesAsync(cancellationToken);
    }
}
