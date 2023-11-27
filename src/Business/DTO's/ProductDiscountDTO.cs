using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class ProductDiscountDTO : BaseDTO, IMapFrom<ProductDiscount>
{
    public int DiscountID { get; set; }
    public DiscountDTO Discount { get; set; } = null!;

    public int ProductID { get; set; }
    public ProductDTO Product { get; set; } = null!;
}
