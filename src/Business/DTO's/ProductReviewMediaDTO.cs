using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class ProductReviewMediaDTO : BaseDTO, IMapFrom<ProductReviewMedia>
    {
        public string? Image { get; set; }

        public int ProductReviewID { get; set; }
        public ProductReviewDTO ProductReview { get; set; } = null!;
    }
}
