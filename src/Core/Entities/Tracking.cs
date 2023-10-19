using ECommerse.Core.Common;
using ECommerse.Core.Enums;

namespace ECommerse.Core.Entities;

public class Tracking : BaseEntity
{
    public int TrackingNumber { get; set; }
    public ShippingStatus ShippingStatus{ get; set; }
    public DateTime? Delivered { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }

    public int OrderID { get; set; }
    public Order Order { get; set; } = null!;
}
