using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class ProductReviewDTO : BaseDTO, IMapFrom<ProductReview>
{
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public string UserID { get; set; } = null!;
    public UserDTO User { get; set; } = null!;

    public int ProductID { get; set; }
    public ProductDTO Product { get; set; } = null!;

    public ICollection<ProductReviewMediaDTO>? Medias { get; set; }
}
