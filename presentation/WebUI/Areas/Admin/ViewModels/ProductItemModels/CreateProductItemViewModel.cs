﻿using ECommerse.Business.DTO_s;

namespace ECommerse.WebUI.Areas.Admin.ViewModels.ProductItemModels;

public class CreateProductItemViewModel
{
    public int ProductId { get; set; }
    public ICollection<ProductItemDTO>? ProductItemsDTO { get; set; }
}