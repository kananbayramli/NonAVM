using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class Promo : BaseEntity
{
    public string Code { get; set; } = null!;
    public double PromoValue { get; set; }
    public DateTime ExpireDate { get; set; }

    public string? UserID { get; set; }
    public AppUser? User{ get; set; } //if null valid for all users

}
