using ECommerse.Business.DTO_s;

namespace ECommerse.WebUI.Areas.Admin.Models.Product;

public class ProductViewModel
{
    public ProductViewModel(int price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Tag { get; set; }
    public string? Image { get; set; }
    public string? Video { get; set; }
    public IFormFile? Photo { get; set; }
    public bool Refundable { get; set; }
    public string StoreName { get; set; } = null!;
    public int CategoryID { get; set; }
    public CategoryDTO? Category { get; set; }
    public int BrandID { get; set; }
    public BrandDTO? Brand { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
