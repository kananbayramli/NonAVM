using ECommerse.Core.Enums;

namespace ECommerse.WebUI.Models.Catalog;

public class ProductCatalogViewModel
{
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal? PriceBeforeDiscount { get; set; }
    public decimal? PriceAfterDiscount { get; set; }
    public int Rating { get; set; }
    public Size[]? Sizes { get; set; }
    public Color[]? Colors { get; set; }
}
