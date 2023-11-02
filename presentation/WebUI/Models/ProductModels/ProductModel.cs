using ECommerse.Core.Entities;

namespace ECommerse.WebUI.Models.ProductModels;

public class ProductModel
{
    public ProductModel(int price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string StoreName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;

    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
