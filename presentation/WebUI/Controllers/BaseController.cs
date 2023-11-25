using ECommerse.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Controllers;

public class BaseController : Controller
{
    protected UserManager<AppUser> userManager { get; }
    protected SignInManager<AppUser> signInManager { get; }

    protected RoleManager<AppRole> roleManager { get; }

    public BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }

    protected AppUser CurrentUser => userManager.FindByNameAsync(User.Identity!.Name!).Result!;

    public void AddModelError(IdentityResult result)
    {
        foreach (var item in result.Errors)
        {
            ModelState.AddModelError("", item.Description);
        }
    }
}
