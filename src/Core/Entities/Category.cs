using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Category : BaseEntity
{ 
    public string Name { get; set; } = null!;
    public int ParentCategoryID { get; set; }

    public ICollection<Product>? Products { get; set; }
}
