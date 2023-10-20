using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class Basket : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public int UserID { get; set; }
    public AppUser User { get; set; } = null!;

    public ICollection<CartItem>? CartItems { get; set; }
}
