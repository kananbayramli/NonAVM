﻿using ECommerse.Business.Mappings;
using ECommerse.Core.Entities;

namespace ECommerse.Business.DTO_s;

public class CategoryDTO : IMapFrom<Category>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentCategoryID { get; set; }

    public ICollection<ProductDTO>? Products { get; set; }
}
