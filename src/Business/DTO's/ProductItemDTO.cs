
using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;

namespace ECommerse.Business.DTO_s;

public class ProductItemDTO : BaseDTO, IMapFrom<ProductItem>
{
    public int? SKU { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public int? ProductID { get; set; }
    public ProductDTO? Product { get; set; }
}
