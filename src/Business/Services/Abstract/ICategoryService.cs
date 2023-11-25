using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;

public interface ICategoryService
{
    Task Create(CategoryDTO categoryDto);
    Task<List<CategoryDTO>> GetAllAsync(Expression<Func<Category, bool>>? expression = null, params Expression<Func<Category, object>>[] includes);
    Task<List<CategoryDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<Category, bool>>? expression = null, params Expression<Func<Category, object>>[] includes);
    Task<CategoryDTO?> GetAsync(Expression<Func<Category, bool>>? expression = null, params Expression<Func<Category, object>>[] includes);
    void Remove(CategoryDTO categoryDto);
    void Update(CategoryDTO categoryDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}