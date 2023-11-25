using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class ProductDTO : BaseDTO, IMapFrom<Product>
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image;
        public IFormFile Photo { get; set; }
        public int? StoreID { get; set; }
        public StoreDTO? Store { get; set; }
        public int CategoryID { get; set; }
        public CategoryDTO? Category { get; set; }
        public ICollection<ProductItemDTO>? ProductItems { get; set; }
    }
}
