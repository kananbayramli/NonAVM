using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Identity;
using ECommerse.WebUI.Areas.Admin.Models.Store;
using ECommerse.WebUI.Controllers;
using ECommerse.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StoreController : BaseController
{
    private readonly IStoreService _storeService;
    private readonly IProductService _productService;
    private readonly PhotoHandlerService _photoHandlerService;

    public StoreController(IStoreService storeService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IProductService productService, PhotoHandlerService photoHandlerService) : base(userManager, signInManager, roleManager)
    {
        this._storeService = storeService;
        _productService = productService;
        _photoHandlerService = photoHandlerService;
    }

    public IActionResult Index()
    {
        return View("CreateStore");
    }

    public async Task<IActionResult> VendorList()
    {
        var storeDtos = await _storeService.GetAllAsync();

        var vendorList = new List<VendorListViewModel>();

        foreach (var item in storeDtos)
        {
            var vendor = new VendorListViewModel
            {
                StoreName = item.Name,
                StoreLogo = item.StoreLogo,
                CreatedDate = item.CreatedDate,
                OwnerID = item.OwnerID
            };

            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user = userManager.Users.FirstOrDefault(u => u.Id == userId);
            vendor.OwnerName = user?.Name ?? "John Doe";
            vendor.ProductCount = await _productService.GetProductCount(item.Id);
            vendorList.Add(vendor);
        }
        return View(vendorList);
    }
        
    [HttpPost]
    public async Task<IActionResult> BecameSeller(StoreViewModel store)
    {
        var photo = store.Image;
        string? uniqueName = await _photoHandlerService.SavePhotoAsync(photo);
        var storeDto = new StoreDTO
        {
            Name = store.Name,
            Desription = store.Desription,
            OwnerID = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value,
            CreatedDate = DateTime.Now,
            StoreLogo = uniqueName
        };

        await _storeService.Create(storeDto);
        await _storeService.SaveChangesAsync(CancellationToken.None);

        return Json("Store successfully created for user");
    }
}
