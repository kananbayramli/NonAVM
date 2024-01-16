using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class Store : BaseEntity
{

    public string Name { get; set; } = null!;
    public string? Desription { get; set; }
    public string? StoreLogo { get; set; }
    public DateTime CreatedDate { get; set; }

    public string OwnerID { get; set; } = null!;
    public AppUser Owner{ get; set; } = null!;

    public ICollection<StoreReview>? StoreReviews { get; set; }
    public ICollection<Product>? Products { get; set; }
}
