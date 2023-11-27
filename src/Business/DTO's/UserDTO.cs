using ECommerse.Business.Mappings;
using ECommerse.Core.Enums;
using ECommerse.Core.Identity;

namespace ECommerse.Business.DTO_s;

public class UserDTO : BaseDTO<string>, IMapFrom<AppUser>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber{ get; set; }
    public string Surname { get; set; } = null!;
    public DateTime? BirthDay { get; set; }
    public Gender Gender { get; set; }
    public string? ProfilePicture { get; set; }

}