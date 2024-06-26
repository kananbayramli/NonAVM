﻿using ECommerse.Core.Identity;
using ECommerse.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.ViewComponents;

public class UserLayoutViewComponent : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;

    public UserLayoutViewComponent(UserManager<AppUser> userManager)
    {
        this._userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
        var userLayoutViewModel = new UserLayoutViewModel { UserName = user.UserName, Name = user.Name, Surname = user.Surname, Email = user.Email, ProfilePicture = user.ProfilePicture };
        return View(userLayoutViewModel);
    }
}
