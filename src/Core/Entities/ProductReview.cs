using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class ProductReview : BaseEntity
{
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public int UserID { get; set; }
    public AppUser User { get; set; } = null!;

    public int ProductID { get; set; }
    public Product Product { get; set; } = null!;

    public ICollection<ProductReviewMedia>? Medias { get; set; }

}
