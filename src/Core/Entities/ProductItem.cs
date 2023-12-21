using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class ProductItem : BaseEntity
{
    public string? SKU { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; } = null!;
    public OrderDetails? OrderDetail { get; set; }

    public ICollection<BasketItem>? BasketItems { get; set; }
    public ICollection<ProductEntry>? ProductEntries { get; set; }
    public ICollection<Media>? Medias { get; set; }
}
