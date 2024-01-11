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
public class StoreReviewService : IStoreReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<StoreReview> _storeReviewRepository;
    private readonly IMapper _mapper;

    public StoreReviewService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _storeReviewRepository = _unitOfWork.Repository<StoreReview>();
        _mapper = mapper;
    }


    public async Task<List<StoreReviewDTO>> GetAllAsync(
        Expression<Func<StoreReview, bool>>? expression = null,
        params Expression<Func<StoreReview, object>>[] includes)
    {
        var StoreReviews = await _storeReviewRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<StoreReviewDTO>>(StoreReviews);
        return dtos;
    }

    public async Task<List<StoreReviewDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<StoreReview, bool>>? expression = null,
        params Expression<Func<StoreReview, object>>[] includes)
    {
        var StoreReviews = await _storeReviewRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<StoreReviewDTO>>(StoreReviews);
        return dtos;
    }

    public async Task<StoreReviewDTO?> GetAsync(
        Expression<Func<StoreReview, bool>>? expression = null,
        params Expression<Func<StoreReview, object>>[] includes)
    {
        var StoreReview = await _storeReviewRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<StoreReviewDTO>(StoreReview);
        return dto;
    }

    public async Task Add(StoreReviewDTO StoreReviewDto)
    {
        var StoreReview = _mapper.Map<StoreReview>(StoreReviewDto);
        await _storeReviewRepository.Create(StoreReview);
    }

    public async Task Create(StoreReviewDTO StoreReviewDto)
    {
        var StoreReview = _mapper.Map<StoreReview>(StoreReviewDto);
        await _storeReviewRepository.Create(StoreReview);
        await SaveChangesAsync();
        _mapper.Map(StoreReview, StoreReviewDto);
    }

    public void Update(StoreReviewDTO StoreReviewDto)
    {
        var StoreReview = _mapper.Map<StoreReview>(StoreReviewDto);
        _storeReviewRepository.Update(StoreReview);
    }

    public void Remove(StoreReviewDTO StoreReviewDto)
    {
        var StoreReview = _mapper.Map<StoreReview>(StoreReviewDto);
        _storeReviewRepository.Remove(StoreReview);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _storeReviewRepository.SaveChangesAsync(cancellationToken);
    }
}
