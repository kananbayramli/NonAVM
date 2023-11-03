using ECommerse.Core.Common;
using ECommerse.Core.Identity;
using System.Security.Cryptography.X509Certificates;

namespace ECommerse.Core.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public int? ShippingAddressID { get; set; }
    public Address? ShippingAddress { get; set; }

    public string? UserID { get; set; }
    public AppUser? User { get; set; }

    public int? ShippingID { get; set; }
    public Shipping? Shipping { get; set; }
    public Tracking? Tracking { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; } = null!;
}
