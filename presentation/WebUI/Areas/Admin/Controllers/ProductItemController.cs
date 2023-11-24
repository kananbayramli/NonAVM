using Microsoft.AspNetCore.Mvc;
using ECommerse.Business.Services.Abstract;

namespace ECommerse.WebUI.Areas.Admin.Controllers
{
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
    }
}
