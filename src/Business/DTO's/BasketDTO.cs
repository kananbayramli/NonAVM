using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;

namespace ECommerse.Business.DTO_s;

public class BasketDTO : BaseDTO, IMapFrom<Basket>
{
    public decimal TotalPrice { get; set; }

    public string UserID { get; set; } = null!;
    public UserDTO User { get; set; } = null!;

    public ICollection<BasketItemDTO>? BasketItems { get; set; }
}
