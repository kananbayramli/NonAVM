using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class DiscountDTO : BaseDTO, IMapFrom<Discount>
    {
        public string? Title { get; set; }
        public double Value { get; set; }
        public DateTime ExpireDate { get; set; }

        public ICollection<ProductDiscountDTO>? ProductDiscountsDTO { get; set; }
    }
}
