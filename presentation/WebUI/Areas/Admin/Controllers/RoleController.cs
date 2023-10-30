using ECommerse.Core.Identity;
using ECommerse.WebUI.Controllers;
using ECommerse.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        public RoleController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles.Select(r => new RoleViewModel { Id = r.Id, Name = r.Name }));
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            var result = await roleManager.CreateAsync(new AppRole() { Name = roleViewModel.Name });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role is not null)
                return View(new RoleViewModel { Id = role.Id, Name = role .Name});
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleViewModel roleViewModel)
        {
            await roleManager.UpdateAsync(new AppRole { Id = roleViewModel.Id, Name = roleViewModel.Name });
            return RedirectToAction("Index", "Role");
        }

        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role is not null)
            {
                await roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}
