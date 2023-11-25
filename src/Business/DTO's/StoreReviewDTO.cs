using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class StoreReviewDTO : BaseDTO, IMapFrom<StoreReview>
{
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public string UserID { get; set; } = null!;
    public UserDTO User { get; set; } = null!;

    public int StoreID { get; set; }
    public StoreDTO Store { get; set; } = null!;
}
