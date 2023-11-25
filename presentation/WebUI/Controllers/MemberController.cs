using ECommerse.Core.Identity;
using ECommerse.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerse.WebUI.Controllers;

public class MemberController : BaseController
{
    public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager){}

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
        var user = await userManager.FindByEmailAsync(userDto.Email);
        user.UserName = userDto.UserName;
        user.Email = userDto.Email;
        user.Name = userDto.Name;
        user.PhoneNumber = userDto.PhoneNumber;
        user.Surname = userDto.Surname;
        //user.Gender = userDto.Gender.Value;
        user.ProfilePicture = userDto.ProfilePicture?.FileName;
        await userManager.UpdateAsync(user);

        var photo = userDto.ProfilePicture;
        if (photo is not null && photo.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
            using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream);
        }

        return RedirectToAction("EditProfile", user);
    }
}
