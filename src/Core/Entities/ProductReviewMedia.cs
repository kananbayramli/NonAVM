using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class ProductReviewMedia : BaseEntity
{
    public string? Image { get; set; }

    public int ProductReviewID { get; set; }
    public ProductReview ProductReview { get; set; } = null!;
}
