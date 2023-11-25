using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;

namespace ECommerse.Business.DTO_s;

public class StoreDTO : BaseDTO, IMapFrom<Store>
{
    public string Name { get; set; } = null!;
    public string? Desription { get; set; }
    public string OwnerID { get; set; } = null!;
    public ICollection<ProductDTO>? Products { get; set; }
}
