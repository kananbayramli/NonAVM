using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Identity;
using ECommerse.WebUI.Models.Product;
using ECommerse.WebUI.Models.ProductItem;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Controllers;
public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly IProductItemService _productItemService;
    public ProductController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IProductItemService productItemService, IProductService productService) : base(userManager, signInManager, roleManager)
    {
        _productItemService = productItemService;
        _productService = productService;
    }

    public async Task<IActionResult> Index(int productId)
    {
        var productDto = await _productService.GetAsync(p => p.Id == productId);
        var productItemDto = await _productItemService.GetAllAsync(i => i.ProductID == productId);

        var productItemVM = new ProductItemViewModel 
        {
            Quantity = productItemDto.FirstOrDefault() is null ? 0 : productItemDto.FirstOrDefault().Quantity,
            Images = new string[1] { productDto.Image },
            PriceAfterDiscount = productItemDto.FirstOrDefault()?.Price,
            PriceBeforeDiscount = productItemDto.FirstOrDefault() is null ? 9.99M : productItemDto.FirstOrDefault().Price,
            Product = new ProductViewModel
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
            }

        };
        return View(productItemVM);
    }
}
