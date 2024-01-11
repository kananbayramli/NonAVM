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
public class ProductReviewMediaService : IProductReviewMediaService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<ProductReviewMedia> _productReviewMediaRepository;
    private readonly IMapper _mapper;

    public ProductReviewMediaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productReviewMediaRepository = _unitOfWork.Repository<ProductReviewMedia>();
        _mapper = mapper;
    }


    public async Task<List<ProductReviewMediaDTO>> GetAllAsync(
        Expression<Func<ProductReviewMedia, bool>>? expression = null,
        params Expression<Func<ProductReviewMedia, object>>[] includes)
    {
        var ProductReviewMedias = await _productReviewMediaRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ProductReviewMediaDTO>>(ProductReviewMedias);
        return dtos;
    }

    public async Task<List<ProductReviewMediaDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<ProductReviewMedia, bool>>? expression = null,
        params Expression<Func<ProductReviewMedia, object>>[] includes)
    {
        var ProductReviewMedias = await _productReviewMediaRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ProductReviewMediaDTO>>(ProductReviewMedias);
        return dtos;
    }

    public async Task<ProductReviewMediaDTO?> GetAsync(
        Expression<Func<ProductReviewMedia, bool>>? expression = null,
        params Expression<Func<ProductReviewMedia, object>>[] includes)
    {
        var ProductReviewMedia = await _productReviewMediaRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ProductReviewMediaDTO>(ProductReviewMedia);
        return dto;
    }

    public async Task Add(ProductReviewMediaDTO ProductReviewMediaDto)
    {
        var ProductReviewMedia = _mapper.Map<ProductReviewMedia>(ProductReviewMediaDto);
        await _productReviewMediaRepository.Create(ProductReviewMedia);
    }

    public async Task Create(ProductReviewMediaDTO ProductReviewMediaDto)
    {
        var ProductReviewMedia = _mapper.Map<ProductReviewMedia>(ProductReviewMediaDto);
        await _productReviewMediaRepository.Create(ProductReviewMedia);
        await SaveChangesAsync();
        _mapper.Map(ProductReviewMedia, ProductReviewMediaDto);
    }

    public void Update(ProductReviewMediaDTO ProductReviewMediaDto)
    {
        var ProductReviewMedia = _mapper.Map<ProductReviewMedia>(ProductReviewMediaDto);
        _productReviewMediaRepository.Update(ProductReviewMedia);
    }

    public void Remove(ProductReviewMediaDTO ProductReviewMediaDto)
    {
        var ProductReviewMedia = _mapper.Map<ProductReviewMedia>(ProductReviewMediaDto);
        _productReviewMediaRepository.Remove(ProductReviewMedia);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _productReviewMediaRepository.SaveChangesAsync(cancellationToken);
    }
}
