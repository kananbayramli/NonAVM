using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class BasketItemDTO : BaseDTO, IMapFrom<BasketItem>
    {
        public int? BasketID { get; set; }
        public BasketDTO? Basket { get; set; }
        public int? ProductItemID { get; set; }
        public ProductItemDTO? ProductItem { get; set; }

        public int Count { get; set; }
    }
}
