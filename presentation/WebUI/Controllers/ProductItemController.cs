using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Controllers
{
    public class ProductItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
