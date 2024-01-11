using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.Models;
using ECommerse.WebUI.Areas.Admin.Models.Product;
using ECommerse.WebUI.Areas.Admin.Models.ProductItem;
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
    private readonly IProductItemService _productItemService;
    private readonly ICategoryService _categoryService;
    private readonly IStoreService _storeService;
    private readonly IBrandService _brandService;
    private readonly IMapper _mapper;
    private readonly PhotoHandlerService _photoHandlerService;

    public ProductController(IProductService productService, ICategoryService categoryService, IStoreService storeService, IBrandService brandService, PhotoHandlerService photoHandlerService, IMapper mapper, IProductItemService productItemService)
    {
        this._productService = productService;
        this._categoryService = categoryService;
        this._storeService = storeService;
        this._brandService = brandService;
        _photoHandlerService = photoHandlerService;
        _mapper = mapper;
        _productItemService = productItemService;
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


    public async Task<ActionResult> AddProduct(int productId = 0)
    {
        ViewBag.categoryList = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        ViewBag.storeList = new SelectList(await _storeService.GetAllAsync(), "Id", "Name");
        ViewBag.brandList = new SelectList(await _brandService.GetAllAsync(), "Id", "Name");
        ViewBag.variants = new Variants();
        if (productId != 0)
        {
            var productDto = await _productService.GetAsync(p => p.Id == productId, p => p.Category, p => p.ProductItems);
            return View( new ProductViewModel(1, 2)
            {
                     Name = productDto.Name,
                     Description  = productDto.Description,
                     Image = productDto.Image,
                     Video  = productDto.Video,
                     Refundable  = productDto.Refundable,
                     Photo  = productDto.Photo,
                     CategoryID  = productDto.CategoryID,
                     Category  = productDto.Category,
                     Brand  = productDto.Brand,
            });
        }
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
        return Json(product.Id);
    }
    

    public async Task<ActionResult> EditProduct(int productId)
    {
        ViewBag.categoryList = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        ViewBag.storeList = new SelectList(await _storeService.GetAllAsync(), "Id", "Name");
        ViewBag.brandList = new SelectList(await _brandService.GetAllAsync(), "Id", "Name");
        ViewBag.variants = new Variants();
        var itemModel = new CreateProductItemViewModel() { ProductId = productId };

        var items = await _productItemService.GetByProductIdAsync(productId);

        items.ForEach(i =>
        {
            itemModel.ProductItems.Add(i);
        });
        ViewBag.productItems = itemModel;

        var productDto = await _productService.GetAsync(p => p.Id == productId, p => p.Category, p => p.ProductItems);
        return View(new ProductViewModel(1, 2)
        {
            Id = productDto.Id,
            StoreId = productDto.StoreID.Value,
            Name = productDto.Name,
            Description = productDto.Description,
            Image = productDto.Image,
            Video = productDto.Video,
            Refundable = productDto.Refundable,
            Photo = productDto.Photo,
            CategoryID = productDto.CategoryID,
            Category = productDto.Category,
            Brand = productDto.Brand,
        });
    }

    [HttpPost]
    public async Task<ActionResult> EditProduct(ProductDTO product)
    {
        var photo = product.Photo;
        if (photo is not null)
        {
            string? uniqueName = await _photoHandlerService.SavePhotoAsync(photo);
            product.Image = uniqueName;
        }
        _productService.Update(product);
        await _productService.SaveChangesAsync(CancellationToken.None);
        return Json(product.Id);
    }
}
