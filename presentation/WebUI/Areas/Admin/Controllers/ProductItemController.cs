using Microsoft.AspNetCore.Mvc;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.ViewModels.ProductItemModels;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

public class ProductItemController : Controller
{
    private readonly IProductItemService _productItemService;

    public ProductItemController(IProductItemService productItemService)
    {
        _productItemService = productItemService;
    }

    public async Task<IActionResult> Index()
    {
        var productItems = await _productItemService.GetAllAsync();
        return View(productItems);
    }

    public async Task<IActionResult> Create(CreateProductItemViewModel createProductItemViewModel) 
    {
        foreach (var item in createProductItemViewModel.ProductItemsDTO)
        {
            item.ProductID = createProductItemViewModel.ProductId;
            await _productItemService.Create(item);
        }
        await _productItemService.SaveChangesAsync(CancellationToken.None);
        return View();
    }
}
