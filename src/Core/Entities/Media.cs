using ECommerse.Core.Common;

namespace ECommerse.Core.Entities;

public class Media : BaseEntity
{
    public string? Image { get; set; }
    public int ProductItemID { get; set; }
    public ProductItem ProductItem { get; set; } = null!;
}