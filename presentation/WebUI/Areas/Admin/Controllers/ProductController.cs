using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.Models;
using ECommerse.WebUI.Areas.Admin.Models.Product;
using ECommerse.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IStoreService _storeService;
    private readonly IBrandService _brandService;
    private readonly PhotoHandlerService _photoHandlerService;

    public ProductController(IProductService productService, ICategoryService categoryService, IStoreService storeService, IBrandService brandService, PhotoHandlerService photoHandlerService)
    {
        this._productService = productService;
        this._categoryService = categoryService;
        this._storeService = storeService;
        this._brandService = brandService;
        _photoHandlerService = photoHandlerService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync(null, p => p.Category, s => s.Store);
        return View(products.Select(p => new ProductViewModel(Random.Shared.Next(1000), Random.Shared.Next(500))
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Image = p.Image,
            Video = p.Video,
            Category = p.Category,
            StoreName = p.Store!.Name
        }).ToList());
    }


    public async Task<ActionResult> AddProduct()
    {
        ViewBag.categoryList = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        ViewBag.storeList = new SelectList(await _storeService.GetAllAsync(), "Id", "Name");
        ViewBag.brandList = new SelectList(await _brandService.GetAllAsync(), "Id", "Name");
        ViewBag.variants = new Variants();
        return View();
    }


    [HttpPost]
    public async Task<ActionResult> AddProduct(ProductDTO product)
    {
        var photo = product.Photo;
        string? uniqueName = await _photoHandlerService.SavePhotoAsync(photo);

        var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var store = await _storeService.GetAsync(s => s.OwnerID == userId);
        product.StoreID = store!.Id;
        product.Image = uniqueName;
        await _productService.Create(product);
        await _productService.SaveChangesAsync(CancellationToken.None);
        return RedirectToAction("Index");
    }
}
