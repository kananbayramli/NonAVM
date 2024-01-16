using ECommerse.Business.DTO_s;

namespace ECommerse.WebUI.Models.Basket;

public class BasketViewModel
{
    public decimal TotalPrice { get; set; }
    public string UserID { get; set; } = null!;
    public ICollection<BasketItemViewModel>? BasketItems { get; set; }
}
