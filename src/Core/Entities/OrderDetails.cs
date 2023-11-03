using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class OrderDetails : BaseEntity
{
    public int? ProductItemQuantity { get; set; }
    public decimal ProductItemPrice { get; set; }
    public string? ProductItemName { get; set; }

    public int OrderID { get; set; }
    public Order Order { get; set; } = null!;

    public int? ProductItemID { get; set; }
    public ProductItem? ProductItem { get; set; }
}
