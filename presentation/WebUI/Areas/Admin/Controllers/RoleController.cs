using ECommerse.Core.Identity;
using ECommerse.WebUI.Controllers;
using ECommerse.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ECommerse.WebUI.Areas.Admin.Controllers;

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
        return View(roles.Select(r => new RoleViewModel { Id = r.Id, Name = r.Name }).ToList());
    }

    //[HttpGet("Admin/Role/finduser/{userNameOrMail}")]
    public async Task<JsonResult> findUser(string userNameOrMail)
    {
        AppUser? user;
        if (String.IsNullOrWhiteSpace(userNameOrMail))
            return Json(new { found = false });

        user = userNameOrMail.Contains('@') ? await userManager.FindByEmailAsync(userNameOrMail) : await userManager.FindByNameAsync(userNameOrMail);
        if (user is null)
            return Json(new { found = false });
            
        return Json(new { found = true, creds = new { userId = user.Id, userName = user.UserName, email = user.Email } });

    }

    public async Task<IActionResult> AssignRole(string id = null)
    {
        AppUser user;
        List<string> userroles = new List<string>();
        var assignRoleViewModel = new AssignRoleViewModel();

        if (Guid.TryParse(id, out Guid guid))
        { 
            user = await userManager.FindByIdAsync(guid.ToString());
            assignRoleViewModel.UserId = user.Id;
            userroles = userManager.GetRolesAsync(user).Result as List<string>;
        }


        var roleViewModels = new List<RoleViewModel>();

        foreach (var role in roleManager.Roles)
        {
            RoleViewModel r = new RoleViewModel();
            r.Id = role.Id;
            r.Name = role.Name!;
            r.IsSelected = userroles.Contains(role.Name);
            roleViewModels.Add(r);
        }
        assignRoleViewModel.RoleViewModels = roleViewModels;
        return View(assignRoleViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(AssignRoleViewModel assignRole)
    {
        AppUser user = await userManager.FindByIdAsync(assignRole.UserId);

        if (user != null)
        foreach (var item in assignRole.RoleViewModels)
        {
            if (item.IsSelected)
            {
                await userManager.AddToRoleAsync(user, item.Name);
            }
            else
            {
                await userManager.RemoveFromRoleAsync(user, item.Name);
            }
        }


        return RedirectToAction("AssignRole", new { id = user?.Id });
    }
}
