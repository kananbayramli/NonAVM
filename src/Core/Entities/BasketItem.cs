using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class BasketItem : BaseEntity
{
    public int BasketID { get; set; }
    public Basket? Basket { get; set; }
    public int ProductItemID { get; set; }
    public ProductItem? ProductItem { get; set; }

    public int Count { get; set; }
}
