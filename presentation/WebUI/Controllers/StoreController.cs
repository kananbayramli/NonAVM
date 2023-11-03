using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Business.Services.Concrete;
using ECommerse.WebUI.Models.StoreViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerse.WebUI.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.stores = await storeService.GetAllAsync();
            return View("CreateStore");
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(StoreModel store)
        {
            var storeDto = new StoreDTO
            {
                Name = store.Name,
                Desription = store.Desription,
                OwnerID = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value
            };
            
            await storeService.Create(storeDto);
            await storeService.SaveChangesAsync(CancellationToken.None);

            return RedirectToAction("Index");
        }
    }
}
