using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class Basket : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public string UserID { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public ICollection<BasketItem>? BasketItems { get; set; }
}
