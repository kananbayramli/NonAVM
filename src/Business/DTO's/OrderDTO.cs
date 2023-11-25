using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class OrderDTO : BaseDTO, IMapFrom<Order>
    {
        public decimal TotalPrice { get; set; }

        public int? ShippingAddressID { get; set; }
        public AddressDTO? ShippingAddress { get; set; }

        public string? UserID { get; set; }
        public UserDTO? User { get; set; }

        public int? ShippingID { get; set; }
        public ShippingDTO? Shipping { get; set; }
        public TrackingDTO? Tracking { get; set; }

        public ICollection<OrderDetailsDTO> OrderDetails { get; set; } = null!;
    }
}
