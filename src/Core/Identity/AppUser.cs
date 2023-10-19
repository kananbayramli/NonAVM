using ECommerse.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerse.Core.Identity;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public Store? Store { get; set; }
    public int StoreID { get; set; }

    public ICollection<Order>? Orders { get; set; }
    public ICollection<UserAddress>? Addresses { get; set; }
    public ICollection<StoreReview>? StoreReviews { get; set; }
}
