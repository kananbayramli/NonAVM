using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Discount : BaseEntity
{
    public string? Title { get; set; }
    public double Value { get; set; }
    public DateTime ExpireDate { get; set; }
}
