using ECommerse.Core.Identity;
using ECommerse.WebUI.Controllers;
using ECommerse.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles="admin,roleaction")]
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

        public async Task<IActionResult> AssignRole(string id = "be783051-fac9-4cff-b247-948a1e7de560")
        {
            TempData["userId"] = id;
            AppUser user = await userManager.FindByIdAsync(id);

            ViewBag.userName = user.UserName;

            IQueryable<AppRole> roles = roleManager.Roles;

            List<string> userroles = userManager.GetRolesAsync(user).Result as List<string>;

            List<AssignRoleViewModel> AssignRoleViewModels = new List<AssignRoleViewModel>();

            foreach (var role in roles)
            {
                AssignRoleViewModel r = new AssignRoleViewModel();
                r.RoleId = role.Id;
                r.RoleName = role.Name;
                if (userroles.Contains(role.Name))
                {
                    r.Exists = true;
                }
                else
                {
                    r.Exists = false;
                }
                AssignRoleViewModels.Add(r);
            }

            return View(AssignRoleViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> roleAssignViewModels)
        {
            AppUser user = await userManager.FindByIdAsync(TempData["userId"].ToString());

            foreach (var item in roleAssignViewModels)
            {
                if (item.Exists)

                {
                    await userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }


            return RedirectToAction("AssignRole", new { id = "be783051-fac9-4cff-b247-948a1e7de560" });
        }
    }
}
