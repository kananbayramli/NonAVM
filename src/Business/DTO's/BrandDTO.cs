using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;

namespace ECommerse.Business.DTO_s;

public class BrandDTO : BaseDTO, IMapFrom<Brand>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Logo { get; set; }
}
