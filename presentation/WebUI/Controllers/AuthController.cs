using ECommerse.Core.Identity;
using ECommerse.WebUI.Helper;
using ECommerse.WebUI.Models;
using ECommerse.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
        }

        public IActionResult LogIn(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel userlogin)
        {
            if (ModelState.IsValid)
            {

                AppUser user = await userManager.FindByEmailAsync(userlogin.Email);

                if (user != null)
                {
                    if (await userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız bir süreliğine kilitlenmiştir. Lütfen daha sonra tekrar deneyiniz.");

                        return View(userlogin);
                    }

                    //if (userManager.IsEmailConfirmedAsync(user).Result == false)
                    //{
                    //    ModelState.AddModelError("", "Email adresiniz onaylanmamıştır. Lütfen  epostanızı kontrol ediniz.");
                    //    return View(userlogin);
                    //}

                    //await signInManager.SignOutAsync();

                    var result = await signInManager.PasswordSignInAsync(user, userlogin.Password, false, false);

                    if (result.Succeeded)
                    {
                        await userManager.ResetAccessFailedCountAsync(user);

                        if (TempData["ReturnUrl"] != null)
                        {
                            return Redirect(TempData["ReturnUrl"].ToString());
                        }

                        return RedirectToAction("Index", "Member");
                    }
                   
                    else
                    {
                        await userManager.AccessFailedAsync(user);

                        int fail = await userManager.GetAccessFailedCountAsync(user);
                        ModelState.AddModelError("", $" {fail} kez başarısız giriş.");
                        if (fail == 3)
                        {
                            await userManager.SetLockoutEndDateAsync(user, new System.DateTimeOffset(DateTime.Now.AddMinutes(20)));

                            ModelState.AddModelError("", "Hesabınız 3 başarısız girişten dolayı 20 dakika süreyle kitlenmiştir. Lütfen daha sonra tekrar deneyiniz.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email adresiniz veya şifreniz yanlış.");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamamıştır.");
                }
            }

            return View(userlogin);
        }


        public IActionResult Register()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Member");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if ( userViewModel.PhoneNumber is not null && userManager.Users.Any(u => u.PhoneNumber == userViewModel.PhoneNumber))
                {
                    ModelState.AddModelError("", "Bu telefon numarası kayıtlıdır.");
                    return View(userViewModel);
                }

                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                //user.Name = userViewModel.Name;
                //user.Surname = userViewModel.Surname;

                IdentityResult result = await userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
//                    string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);

//#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
//                    string link = Url.Action("ConfirmEmail", "Home", new
//                    {
//                        userId = user.Id,
//                        token = confirmationToken
//                    }, protocol: HttpContext.Request.Scheme

//                    );
//#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

//                    EmailConfrimation.SendEmail(link!, user.Email);

                    return RedirectToAction("LogIn");
                }
                else
                {
                    AddModelError(result);
                }
            }

            return View(userViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);

            IdentityResult result = await userManager.ConfirmEmailAsync(user!, token);

            if (result.Succeeded)
            {
                ViewBag.status = "Email adresiniz onaylanmıştır. Login ekranından giriş yapabilirsiniz.";
            }
            else
            {
                ViewBag.status = "Bir hata meydana geldi. lütfen daha sonra tekrar deneyiniz.";
            }
            return View();
        }
    }
}
