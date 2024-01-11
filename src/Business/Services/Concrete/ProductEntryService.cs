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
public class ProductEntryService : IProductEntryService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<ProductEntry> _productEntryRepository;
    private readonly IMapper _mapper;

    public ProductEntryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productEntryRepository = _unitOfWork.Repository<ProductEntry>();
        _mapper = mapper;
    }


    public async Task<List<ProductEntryDTO>> GetAllAsync(
        Expression<Func<ProductEntry, bool>>? expression = null,
        params Expression<Func<ProductEntry, object>>[] includes)
    {
        var ProductEntrys = await _productEntryRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<ProductEntryDTO>>(ProductEntrys);
        return dtos;
    }

    public async Task<List<ProductEntryDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<ProductEntry, bool>>? expression = null,
        params Expression<Func<ProductEntry, object>>[] includes)
    {
        var ProductEntrys = await _productEntryRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<ProductEntryDTO>>(ProductEntrys);
        return dtos;
    }

    public async Task<ProductEntryDTO?> GetAsync(
        Expression<Func<ProductEntry, bool>>? expression = null,
        params Expression<Func<ProductEntry, object>>[] includes)
    {
        var ProductEntry = await _productEntryRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<ProductEntryDTO>(ProductEntry);
        return dto;
    }

    public async Task Add(ProductEntryDTO ProductEntryDto)
    {
        var ProductEntry = _mapper.Map<ProductEntry>(ProductEntryDto);
        await _productEntryRepository.Create(ProductEntry);
    }


    public async Task Create(ProductEntryDTO ProductEntryDto)
    {
        var ProductEntry = _mapper.Map<ProductEntry>(ProductEntryDto);
        await _productEntryRepository.Create(ProductEntry);
        await SaveChangesAsync();
        _mapper.Map(ProductEntry, ProductEntryDto);
    }

    public void Update(ProductEntryDTO ProductEntryDto)
    {
        var ProductEntry = _mapper.Map<ProductEntry>(ProductEntryDto);
        _productEntryRepository.Update(ProductEntry);
    }

    public void Remove(ProductEntryDTO ProductEntryDto)
    {
        var ProductEntry = _mapper.Map<ProductEntry>(ProductEntryDto);
        _productEntryRepository.Remove(ProductEntry);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _productEntryRepository.SaveChangesAsync(cancellationToken);
    }
}
