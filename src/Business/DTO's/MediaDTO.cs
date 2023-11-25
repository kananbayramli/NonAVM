using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class MediaDTO : BaseDTO, IMapFrom<Media>
    {
        public string? Image { get; set; }
        public int ProductItemID { get; set; }
        public ProductItemDTO ProductItemDTO { get; set; } = null!;
    }
}
