using ECommerse.Core.Common;
using ECommerse.Core.Identity;

namespace ECommerse.Core.Entities;

public class Payment : BaseEntity
{
    public bool IsDefault { get; set; }
    public int AccountNumber { get; set; }
    public DateTime ExpireDate { get; set; }

    public string UserID { get; set; } = null!;
    public AppUser User { get; set; } = null!;

}
