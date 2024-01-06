using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;

namespace ECommerse.Business.DTO_s;

public class CategoryDTO : BaseDTO, IMapFrom<Category>
{
    public string Name { get; set; } = null!;
    public int? ParentCategoryID { get; set; }
    public string? Slug { get; set; }
    public ICollection<ProductDTO>? Products { get; set; }
}
