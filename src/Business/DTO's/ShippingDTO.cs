using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class ShippingDTO : BaseDTO, IMapFrom<Shipping>
    {
        public string Title { get; set; } = null!;
        public decimal Cost { get; set; }

        public ICollection<OrderDTO>? Orders { get; set; }
    }
}
