using ECommerse.Core.Enums;

namespace ECommerse.WebUI.Models.Product;

public class ProductViewModel
{
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Rating { get; set; }
    public Size[]? Sizes { get; set; }
    public Color[]? Colors { get; set; }
    public Material[]? Materials { get; set; }
}
