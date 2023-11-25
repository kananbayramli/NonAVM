using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Logo { get; set; }

    public ICollection<Product> Products { get; set; } = null!;
    public ICollection<Category> Categories { get; set; } = null!;
}
