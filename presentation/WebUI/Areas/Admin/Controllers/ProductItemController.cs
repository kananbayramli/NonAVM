using Microsoft.AspNetCore.Mvc;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.Models.ProductItem;
using ECommerse.Core.Enums;
using ECommerse.Business.Services.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerse.WebUI.Areas.Admin.Models;
using ECommerse.Business.DTO_s;

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


    public IActionResult GetVariants()
    {
        return Json(new Variants());
    }

    public IActionResult AddProductItem(int productId)
    {
        var product = _productService.GetAsync(p => p.Id == 1002);
        return View(new CreateProductItemViewModel { ProductId = product.Id});
    }

    [HttpPost]
    public async Task<IActionResult> AddProductItem(CreateProductItemViewModel createProductItemViewModel) 
    {
        if (createProductItemViewModel.ProductItems is null)
            return View();

        foreach (var item in createProductItemViewModel.ProductItems)
        {
            item.ProductID = createProductItemViewModel.ProductId;
            await _productItemService.Create(item);
        }
        await _productItemService.SaveChangesAsync(CancellationToken.None);

        return RedirectToAction("AddProduct", "Product");
    }

    [HttpPost]
    public async Task<IActionResult> EditProductItem(CreateProductItemViewModel createProductItemViewModel)
    {
        if (createProductItemViewModel.ProductItems is null)
            return View();

        foreach (var item in createProductItemViewModel.ProductItems)
        {
            _productItemService.Update(item);
        }
        await _productItemService.SaveChangesAsync(CancellationToken.None);

        return RedirectToAction("EditProduct", "Product", new {productId = createProductItemViewModel.ProductId});
    }
}
