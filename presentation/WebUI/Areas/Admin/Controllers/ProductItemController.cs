﻿using Microsoft.AspNetCore.Mvc;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.Models.ProductItem;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductItemController : Controller
{
    private readonly IProductItemService _productItemService;
    private readonly IProductService _productService;

    public ProductItemController(IProductItemService productItemService, IProductService productService)
    {
        _productItemService = productItemService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var productItems = await _productItemService.GetAllAsync();
        return View(productItems);
    }

    public IActionResult AddProductItem(int productId)
    {
        var product = _productService.GetAsync(p => p.Id == 1002);
        return View(new CreateProductItemViewModel { ProductId = product.Id});
    }

    [HttpPost]
    public async Task<IActionResult> AddProductItem(CreateProductItemViewModel createProductItemViewModel) 
    {
        if (createProductItemViewModel.ProductItemsDTO is null)
            return View();

        foreach (var item in createProductItemViewModel.ProductItemsDTO)
        {
            item.ProductID = createProductItemViewModel.ProductId;
            await _productItemService.Create(item);
        }
        await _productItemService.SaveChangesAsync(CancellationToken.None);

        return View();
    }
}
