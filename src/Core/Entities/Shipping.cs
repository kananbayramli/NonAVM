using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Shipping : BaseEntity
{
    public string Title { get; set; } = null!;
    public decimal Cost { get; set; }

    public ICollection<Order>? Orders { get; set; }
}