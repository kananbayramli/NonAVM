using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using System.Linq.Expressions;

namespace ECommerse.Business.Services.Abstract;
public interface IProductEntryService
{
    Task Create(ProductEntryDTO ProductEntryDto);
    Task<List<ProductEntryDTO>> GetAllAsync(Expression<Func<ProductEntry, bool>>? expression = null, params Expression<Func<ProductEntry, object>>[] includes);
    Task<List<ProductEntryDTO>> GetAllPaginatedAsync(int pageIndex, int pageSize, Expression<Func<ProductEntry, bool>>? expression = null, params Expression<Func<ProductEntry, object>>[] includes);
    Task<ProductEntryDTO?> GetAsync(Expression<Func<ProductEntry, bool>>? expression = null, params Expression<Func<ProductEntry, object>>[] includes);
    void Remove(ProductEntryDTO ProductEntryDto);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Update(ProductEntryDTO ProductEntryDto);
}