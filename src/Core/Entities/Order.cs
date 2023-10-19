using ECommerse.Core.Common;
using ECommerse.Core.Identity;
using System.Security.Cryptography.X509Certificates;

namespace ECommerse.Core.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public int ShippingAddressID { get; set; }
    public UserAddress ShippingAddress { get; set; } = null!;

    public string UserID { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public int ShippingID { get; set; }
    public Shipping Shipping { get; set; } = null!;

    public int TrackingID { get; set; }
    public Tracking? Tracking { get; set; }
}
