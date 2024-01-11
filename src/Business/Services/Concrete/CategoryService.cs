using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Concrete;

public class CategoryService : IScoppedLifetime, ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = _unitOfWork.Repository<Category>();
        _mapper = mapper;
    }


    public async Task<List<CategoryDTO>> GetAllAsync(
        Expression<Func<Category, bool>>? expression = null,
        params Expression<Func<Category, object>>[] includes)
    {
        var categories = await _categoryRepository.GetAllAsync(expression, includes);
        var dtos = _mapper.Map<List<CategoryDTO>>(categories);
        return dtos;
    }

    public async Task<List<CategoryDTO>> GetAllPaginatedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<Category, bool>>? expression = null,
        params Expression<Func<Category, object>>[] includes)
    {
        var categories = await _categoryRepository.GetAllPaginatedAsync(pageIndex, pageSize, expression, includes);
        var dtos = _mapper.Map<List<CategoryDTO>>(categories);
        return dtos;
    }

    public async Task<CategoryDTO?> GetAsync(
        Expression<Func<Category, bool>>? expression = null,
        params Expression<Func<Category, object>>[] includes)
    {
        var category = await _categoryRepository.GetAsync(expression, includes);
        var dto = _mapper.Map<CategoryDTO>(category);
        return dto;
    }

    public async Task Add(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(category);
    }

    public async Task Create(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(category);
        await SaveChangesAsync();
        _mapper.Map(category, categoryDto);
    }


    public void Update(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        _categoryRepository.Update(category);
    }

    public void Remove(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        _categoryRepository.Remove(category);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _categoryRepository.SaveChangesAsync(cancellationToken);
    }
}
