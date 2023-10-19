using Microsoft.AspNetCore.Identity;

namespace ECommerse.Core.Identity;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}
