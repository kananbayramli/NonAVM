using ECommerse.Core.Common;
using ECommerse.Core.Enums;
using System.Drawing;
using Color = ECommerse.Core.Enums.Color;
using Size = ECommerse.Core.Enums.Size;

namespace ECommerse.Core.Entities;

public class ProductEntry : BaseEntity
{
    public int ProductItemID { get; set; }
    public ProductItem ProductItem { get; set; } = null!;

    public Size Size { get; set; }
    public Color Color { get; set; }
    public Material Material { get; set; }
}
