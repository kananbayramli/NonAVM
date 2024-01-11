using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Category : BaseEntity
{ 
    public string Name { get; set; } = null!;
    public int? ParentCategoryID { get; set; }
    public string? Slug { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Brand>? Brands { get; set; }
}
