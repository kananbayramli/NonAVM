using ECommerse.Business.Mappings;
using ECommerse.Core.Enums;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class UserDTO : IMapFrom<AppUser>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber{ get; set; }
        public string Surname { get; set; } = null!;
        public DateTime? BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string? ProfilePicture { get; set; }

    }
}
