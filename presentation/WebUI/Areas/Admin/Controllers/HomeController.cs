using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using ECommerse.WebUI.Controllers;
using ECommerse.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[Authorize(Roles = "admin")]
public class HomeController : BaseController
{
    private readonly IMapper _mapper;
    public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper) : base(userManager, signInManager, roleManager)
    {
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }


    public async Task<IActionResult> UserList()
    {
        var users = await userManager.Users.ToListAsync();
        return View(users.Select(u => 
            new UserDTO
            {
                Email = u.Email!,
                Name = u.Name,
                Id = u.Id,
                PhoneNumber = u.PhoneNumber
            }
        ).ToList());
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
            using (var stream = new FileStream(path, FileMode.Create))
                await photo.CopyToAsync(stream);
        }

        return RedirectToAction("EditProfile", user);
    }
}
