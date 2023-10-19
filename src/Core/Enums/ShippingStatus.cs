namespace ECommerse.Core.Enums;

public enum ShippingStatus
{
    Unknown = 0,
    PENDING,     // The shipment is waiting to be processed.
    IN_TRANSIT,  // The shipment is currently in transit or on its way.
    OUT_FOR_DELIVERY, // The shipment is out for delivery to the recipient.
    DELIVERED,   // The shipment has been successfully delivered.
    FAILED,      // Delivery failed for some reason.
    RETURNED     // The shipment was returned to the sender.

}
