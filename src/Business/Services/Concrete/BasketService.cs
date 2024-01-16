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
public class BasketService : IBasketService, IScoppedLifetime
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Basket> _basketRepository;
    private readonly IMapper _mapper;

    public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _basketRepository = _unitOfWork.Repository<Basket>();
        _mapper = mapper;
    }


    public async Task<List<BasketDTO>> GetAllAsync(
        Expression<Func<Basket, bool>>? expression = null,
        params Expression<Func<Basket, object>>[] includes)
    {
        var Baskets = await _basketRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<BasketDTO>>(Baskets);
        return dtos;
    }

    public async Task<List<BasketDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Basket, bool>>? expression = null,
        params Expression<Func<Basket, object>>[] includes)
    {
        var Baskets = await _basketRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<BasketDTO>>(Baskets);
        return dtos;
    }

    public async Task<BasketDTO?> GetAsync(
        Expression<Func<Basket, bool>>? expression = null,
        params Expression<Func<Basket, object>>[] includes)
    {
        var Basket = await _basketRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<BasketDTO>(Basket);
        return dto;
    }

    public async Task Add(BasketDTO BasketDto)
    {
        var Basket = _mapper.Map<Basket>(BasketDto);
        await _basketRepository.Create(Basket);
    }

    public async Task Create(BasketDTO BasketDto)
    {
        var Basket = _mapper.Map<Basket>(BasketDto);
        await _basketRepository.Create(Basket);
        await SaveChangesAsync();
        _mapper.Map(Basket, BasketDto);
    }


    public void Update(BasketDTO BasketDto)
    {
        var Basket = _mapper.Map<Basket>(BasketDto);
        _basketRepository.Update(Basket);
    }

    public void Remove(BasketDTO BasketDto)
    {
        var Basket = _mapper.Map<Basket>(BasketDto);
        _basketRepository.Remove(Basket);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _basketRepository.SaveChangesAsync(cancellationToken);
    }
}
