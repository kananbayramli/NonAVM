using ECommerse.Core.Entities;
using ECommerse.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace ECommerse.Core.Identity;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime? BirthDay { get; set; }
    public Gender Gender { get; set; }
    public string? ProfilePicture { get; set; }

    public Store? Store { get; set; }

    public Promo? Promo { get; set; }

    public Basket? Basket { get; set; }

    public ICollection<Order>? Orders { get; set; }
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<StoreReview>? StoreReviews { get; set; }
    public ICollection<Payment>? Payments { get; set; }
    public ICollection<ProductReview>? Reviews { get; set; }
}
