using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class ProductDiscount : BaseEntity
{
    public int DiscountID { get; set; }
    public Discount? Discount { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; } = null!;
}
