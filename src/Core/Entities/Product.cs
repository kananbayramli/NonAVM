using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }


    public int StoreID { get; set; }
    public Store Store { get; set; } = null!;

    public int CategoryID { get; set; }
    public Category Category { get; set; } = null!;

    public ProductDiscount? ProductDiscount { get; set; }


    public ICollection<ProductItem>? ProductItems { get; set; }
    public ICollection<ProductReview>? ProductReviews{ get; set; }

}
