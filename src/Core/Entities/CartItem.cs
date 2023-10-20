using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class CartItem : BaseEntity
{
    public int ShoppingCartID { get; set; }
    public Basket? ShoppingCart { get; set; }
    public int ProductItemID { get; set; }
    public ProductItem? ProductItem { get; set; }

    public int Count { get; set; }
}
