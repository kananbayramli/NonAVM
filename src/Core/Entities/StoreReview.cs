using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class StoreReview : BaseEntity
{
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public string UserID { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public int StoreID { get; set; }
    public Store Store{ get; set; } = null!;
}
