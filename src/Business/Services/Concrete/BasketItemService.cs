﻿using AutoMapper;
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
public class BasketItemService : IBasketItemService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<BasketItem> _basketItemRepository;
    private readonly IMapper _mapper;

    public BasketItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _basketItemRepository = _unitOfWork.Repository<BasketItem>();
        _mapper = mapper;
    }


    public async Task<List<BasketItemDTO>> GetAllAsync(
        Expression<Func<BasketItem, bool>>? expression = null,
        params Expression<Func<BasketItem, object>>[] includes)
    {
        var BasketItems = await _basketItemRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<BasketItemDTO>>(BasketItems);
        return dtos;
    }

    public async Task<List<BasketItemDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<BasketItem, bool>>? expression = null,
        params Expression<Func<BasketItem, object>>[] includes)
    {
        var BasketItems = await _basketItemRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<BasketItemDTO>>(BasketItems);
        return dtos;
    }

    public async Task<BasketItemDTO?> GetAsync(
        Expression<Func<BasketItem, bool>>? expression = null,
        params Expression<Func<BasketItem, object>>[] includes)
    {
        var BasketItem = await _basketItemRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<BasketItemDTO>(BasketItem);
        return dto;
    }

    public async Task Create(BasketItemDTO BasketItemDto)
    {
        var BasketItem = _mapper.Map<BasketItem>(BasketItemDto);
        await _basketItemRepository.Create(BasketItem);
    }

    public void Update(BasketItemDTO BasketItemDto)
    {
        var BasketItem = _mapper.Map<BasketItem>(BasketItemDto);
        _basketItemRepository.Update(BasketItem);
    }

    public void Remove(BasketItemDTO BasketItemDto)
    {
        var BasketItem = _mapper.Map<BasketItem>(BasketItemDto);
        _basketItemRepository.Remove(BasketItem);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _basketItemRepository.SaveChangesAsync(cancellationToken);
    }
}