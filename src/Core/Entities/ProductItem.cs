using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class ProductItem : BaseEntity
{
    public int SKU { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }

    public Product Product { get; set; } = null!;
    public int ProductID { get; set; }

    public ICollection<ProductEntry>? ProductEntries { get; set; }
}
