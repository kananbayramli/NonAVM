using ECommerse.Core.Enums;
using ECommerse.WebUI.Models.Product;

namespace ECommerse.WebUI.Models.ProductItem;

public class ProductItemViewModel
{
    public ProductItemViewModel()
    {
        Product = new ProductViewModel();
    }
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string[]? Images { get; set; }
    public decimal PriceBeforeDiscount { get; set; }
    public decimal? PriceAfterDiscount { get; set; }
    public ProductViewModel Product { get; set; }
}
