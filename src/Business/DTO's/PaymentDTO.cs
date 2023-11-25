using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class PaymentDTO : BaseDTO, IMapFrom<Payment>
{
    public bool IsDefault { get; set; }
    public int AccountNumber { get; set; }
    public DateTime ExpireDate { get; set; }

    public string UserID { get; set; } = null!;
    public UserDTO User { get; set; } = null!;
}
