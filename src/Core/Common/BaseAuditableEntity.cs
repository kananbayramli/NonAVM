namespace ECommerse.Core.Common;

public class BaseAuditableEntity : BaseEntity
{
    public string CreatedBy { get; set; } = null!;
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}
