using ECommerse.Core.Identity;
using ECommerse.WebUI.Models.User;
using ECommerse.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerse.WebUI.Controllers;

public class MemberController : BaseController
{
    private readonly PhotoHandlerService _photoHandlerService;
    public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, PhotoHandlerService photoHandlerService) : base(userManager, signInManager, roleManager)
    {
        _photoHandlerService = photoHandlerService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> EditProfile()
    {
        AppUser? user = await userManager.FindByIdAsync(User?.Claims?.FirstOrDefault(c => c?.Type == ClaimTypes.NameIdentifier)?.Value!);
        if (user == null)
            return NoContent();
        return View(new UserEditViewModel()
        {
            UserName = user.UserName!,
            Email = user.Email!,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber ?? "",
            Surname = user.Surname,
            Gender = user.Gender
            
        });
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(UserEditViewModel userDto)
    {
        var photo = userDto.ProfilePicture;
        string? pp = await _photoHandlerService.SavePhotoAsync(photo);

        var user = await userManager.FindByEmailAsync(userDto.Email);
        user.UserName = userDto.UserName;
        user.Email = userDto.Email;
        user.Name = userDto.Name;
        user.PhoneNumber = userDto.PhoneNumber;
        user.Surname = userDto.Surname;
        //user.Gender = userDto.Gender.Value;
        user.ProfilePicture = pp;
        await userManager.UpdateAsync(user);


        return RedirectToAction("EditProfile", user);
    }
}
