using ECommerse.Business.DTO_s;

namespace ECommerse.WebUI.Areas.Admin.Models.ProductItem;

public class CreateProductItemViewModel
{
    public int? ProductId { get; set; }
    public ICollection<ProductItemDTO>? ProductItems { get; set; }
}
