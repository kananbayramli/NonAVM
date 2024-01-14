using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Identity;
using ECommerse.WebUI.Models.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Controllers;
public class CatalogController : BaseController
{
    IProductService _productService;
    IProductItemService _productItemService;
    public CatalogController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IProductService productService, IProductItemService productItemService) : base(userManager, signInManager, roleManager)
    {
        _productService = productService;
        _productItemService = productItemService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();

        var productVMs = new List<ProductCatalogViewModel>();

        foreach (var product in products)
        {

            var productVM = new ProductCatalogViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description.Length <= 100 ? product.Description : product.Description.Substring(0, 100) +"...",
                Image = product.Image,
            };
            var productItems = await _productItemService.GetAllAsync(i => i.ProductID == product.Id);
            productVM.PriceBeforeDiscount = productItems?.FirstOrDefault()?.Price;
            productVM.PriceAfterDiscount = productItems?.FirstOrDefault()?.Price;
            productVMs.Add(productVM);
        }
        return View(productVMs);
    }
}
