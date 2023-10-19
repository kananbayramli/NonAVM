using ECommerse.Core.Common;
using ECommerse.Core.Enums;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class UserAddress : BaseEntity
{
    public string UserID { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public ICollection<Order>? Orders { get; set; }

    public string AdressLine1 { get; set; } = null!;
    public string? AdressLine2 { get; set; }
    public City City { get; set; }
    public bool Is_Default { get; set; }
    public string? PostalCode { get; set; }
}