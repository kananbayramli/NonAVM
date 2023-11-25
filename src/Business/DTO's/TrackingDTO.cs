using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class TrackingDTO : BaseDTO, IMapFrom<Tracking>
    {
        public int TrackingNumber { get; set; }
        public ShippingStatus ShippingStatus { get; set; }
        public DateTime? Delivered { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }

        public int OrderID { get; set; }
        public OrderDTO Order { get; set; } = null!;
    }
}
