using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class OrderDetailsDTO : BaseDTO, IMapFrom<OrderDetails>
{
    public int? ProductItemQuantity { get; set; }
    public decimal ProductItemPrice { get; set; }
    public string? ProductItemName { get; set; }

    public int OrderID { get; set; }
    public OrderDTO Order { get; set; } = null!;

    public int? ProductItemID { get; set; }
    public ProductItemDTO? ProductItem { get; set; }
}
