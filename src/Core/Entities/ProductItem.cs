using ECommerse.Core.Common;
using ECommerse.Core.Enums;

namespace ECommerse.Core.Entities;

public class ProductItem : BaseEntity
{
    public string? SKU { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public Color? Color { get; set; }
    public Size? Size { get; set; }
    public Material? Material { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; } = null!;
    public OrderDetails? OrderDetail { get; set; }

    public ICollection<BasketItem>? BasketItems { get; set; }
    public ICollection<Media>? Medias { get; set; }
}
