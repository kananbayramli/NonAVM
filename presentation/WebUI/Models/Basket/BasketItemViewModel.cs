using ECommerse.Business.DTO_s;
using ECommerse.WebUI.Models.ProductItem;

namespace ECommerse.WebUI.Models.Basket;

public class BasketItemViewModel
{
    public int? BasketID { get; set; }
    public ProductItemViewModel? ProductItem { get; set; }
    public int Count { get; set; }
}
