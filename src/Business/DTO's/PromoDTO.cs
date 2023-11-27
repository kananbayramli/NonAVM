using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class PromoDTO : BaseDTO, IMapFrom<Promo>
{
    public string Code { get; set; } = null!;
    public double PromoValue { get; set; }
    public DateTime ExpireDate { get; set; }

    public string? UserID { get; set; }
    public UserDTO? User { get; set; } //if null valid for all users
}
