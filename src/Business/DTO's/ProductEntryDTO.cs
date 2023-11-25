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
    public class ProductEntryDTO : BaseDTO, IMapFrom<ProductEntry>
    {
        public int ProductItemID { get; set; }
        public ProductItemDTO ProductItemDTO { get; set; } = null!;

        public Size Size { get; set; }
        public Color Color { get; set; }
        public Material Material { get; set; }
    }
}
