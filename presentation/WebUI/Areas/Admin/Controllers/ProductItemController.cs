using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Areas.Admin.Controllers
{
    public class ProductItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
