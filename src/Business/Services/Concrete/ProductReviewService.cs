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
public class ProductReviewService : IProductReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<ProductReview> _productReviewRepository;
    private readonly IMapper _mapper;

    public ProductReviewService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productReviewRepository = _unitOfWork.Repository<ProductReview>();
        _mapper = mapper;
    }


    public async Task<List<ProductReviewDTO>> GetAllAsync(
        Expression<Func<ProductReview, bool>>? expression = null,
        params Expression<Func<ProductReview, object>>[] includes)
    {
        var ProductReviews = await _productReviewRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ProductReviewDTO>>(ProductReviews);
        return dtos;
    }

    public async Task<List<ProductReviewDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<ProductReview, bool>>? expression = null,
        params Expression<Func<ProductReview, object>>[] includes)
    {
        var ProductReviews = await _productReviewRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ProductReviewDTO>>(ProductReviews);
        return dtos;
    }

    public async Task<ProductReviewDTO?> GetAsync(
        Expression<Func<ProductReview, bool>>? expression = null,
        params Expression<Func<ProductReview, object>>[] includes)
    {
        var ProductReview = await _productReviewRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ProductReviewDTO>(ProductReview);
        return dto;
    }

    public async Task Create(ProductReviewDTO ProductReviewDto)
    {
        var ProductReview = _mapper.Map<ProductReview>(ProductReviewDto);
        await _productReviewRepository.Create(ProductReview);
    }

    public void Update(ProductReviewDTO ProductReviewDto)
    {
        var ProductReview = _mapper.Map<ProductReview>(ProductReviewDto);
        _productReviewRepository.Update(ProductReview);
    }

    public void Remove(ProductReviewDTO ProductReviewDto)
    {
        var ProductReview = _mapper.Map<ProductReview>(ProductReviewDto);
        _productReviewRepository.Remove(ProductReview);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _productReviewRepository.SaveChangesAsync(cancellationToken);
    }
}
