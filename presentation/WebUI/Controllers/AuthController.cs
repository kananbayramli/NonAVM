using ECommerse.Core.Identity;
using ECommerse.WebUI.Helper;
using ECommerse.WebUI.Models.Auth;
using ECommerse.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerse.WebUI.Controllers;

public class AuthController : BaseController
{
    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager){}

    public IActionResult LogIn(string ReturnUrl) //kanan
    {
        TempData["ReturnUrl"] = ReturnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LoginViewModel userlogin)
    {
        if (ModelState.IsValid)
        {

            AppUser? user = await userManager.FindByEmailAsync(userlogin.Email!);

            if (user != null)
            {
                if (await userManager.IsLockedOutAsync(user))
                {
                    ModelState.AddModelError("", "Yanlış məlumatlar daxil etdiyiniz üçün hesabınız kilidə düşüb. Xahiş edirik bir az sonra təkrar cəhd edin.");

                    return View(userlogin);
                }

                if (userManager.IsEmailConfirmedAsync(user).Result == false)
                {
                    ModelState.AddModelError("", "Email adresi təstiq edilməyib. Zəhmət olmasa sizə göndərilən emaili yoxlayın.");
                    return View(userlogin);
                }

                //await signInManager.SignOutAsync();

                //#region AddClaim
                //var claim = User.Claims.Where(x => x.Type == "OneMonthTrialRemaining" && x.Value != null).FirstOrDefault();
                //if (claim is null)
                //{
                //    var idiResult = await userManager.AddClaimAsync(user, new Claim("OneMonthTrialRemaining", DateTime.Now.AddSeconds(15).ToString()));
                //}
                //#endregion

                var result = await signInManager.PasswordSignInAsync(user, userlogin.Password, userlogin.RememberMe, true);

                if (result.Succeeded)
                {
                    await userManager.ResetAccessFailedCountAsync(user);

                    if (TempData["ReturnUrl"] != null)
                    {
                        return Redirect(TempData["ReturnUrl"].ToString());
                    }

                    return RedirectToAction("Index", "Home");
                }
               
                else
                {
                    await userManager.AccessFailedAsync(user);

                    int fail = await userManager.GetAccessFailedCountAsync(user);
                    ModelState.AddModelError("", $" {fail} dəfə uğursuz cəhd.");
                    if (fail == 3)
                    {
                        await userManager.SetLockoutEndDateAsync(user, new System.DateTimeOffset(DateTime.Now.AddMinutes(20)));

                        ModelState.AddModelError("", "Hesabınız 3 uğursuz cəhdən dolayı 20 dəqiqə müddətində kilidə salınıb. Zəhmət olmasa sonra yenidən cəhd edin.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email adresi yaxud şifrə yanlışdır.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Bu email adresinə bağlı hesab mövcud deyil.");
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
                ModelState.AddModelError("", $"{userViewModel.PhoneNumber} telefon nömrəsi ilə artıq qeydiyyatdan keçilib.");
                return View(userViewModel);
            }

            AppUser user = new()
            {
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
                PhoneNumber = userViewModel.PhoneNumber,
                Name = userViewModel.Name,
                Surname = userViewModel.Surname
            };

            IdentityResult result = await userManager.CreateAsync(user, userViewModel.Password);

            if (result.Succeeded)
            {
                string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);

                string? link = Url.Action("ConfirmEmail", "Auth", new
                    {
                        userId = user.Id,
                        token = confirmationToken
                    }, protocol: HttpContext.Request.Scheme);

                EmailConfrimation.SendEmail(link!, user.Email);

                TempData["ConfirmEmail"] = $"Qeydiyyat prosesini tamamlamaq üçün {user.Email} ünvanına göndərilən link-ə daxil olaraq e-mail ünvanını təstiq edin.";

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

        IdentityResult result = await userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
        {
            ViewBag.status = "Email adresiniz onaylanmıştır. Login ekranından giriş yapabilirsiniz.";
        }
        else
        {
            ViewBag.status = "Bir hata meydana geldi. lütfen daha sonra tekrar deneyiniz.";
        }
        return RedirectToAction("Login");
    }

    public async Task<ActionResult> LogOut()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Login", "Auth");
    }

    public IActionResult ResetPasswordRequest()
    {
        TempData["durum"] = null;
        return View();
    }
    [HttpPost]
    public IActionResult ResetPasswordRequest(PasswordResetViewModel passwordResetViewModel)
    {
        if (TempData["durum"] == null)
        {
            AppUser user = userManager.FindByEmailAsync(passwordResetViewModel.Email).Result;

            if (user != null)

            {
                string passwordResetToken = userManager.GeneratePasswordResetTokenAsync(user).Result;

                string passwordResetLink = Url.Action("ResetPasswordConfirm", "Auth", new
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);

                //  www.bıdıbıdı.com/Home/ResetPasswordConfirm?userId=sdjfsjf&token=dfjkdjfdjf

                Helper.PasswordReset.PasswordResetSendEmail(passwordResetLink, user.Email);

                ViewBag.status = "success";
                TempData["durum"] = true.ToString();
            }
            else
            {
                ModelState.AddModelError("", "Sistemde kayıtlı email adresi bulunamamıştır.");
            }
            return View(passwordResetViewModel);
        }
        else
        {
            return RedirectToAction("ResetPassword");
        }
    }

    public IActionResult ResetPasswordConfirm(string userId, string token)
    {
        TempData["userId"] = userId;
        TempData["token"] = token;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ResetPasswordConfirm([Bind("PasswordNew")] PasswordResetViewModel passwordResetViewModel)
    {
        string token = TempData["token"].ToString();
        string userId = TempData["userId"].ToString();

        AppUser user = await userManager.FindByIdAsync(userId);

        if (user != null)
        {
            IdentityResult result = await userManager.ResetPasswordAsync(user, token, passwordResetViewModel.PasswordNew);

            if (result.Succeeded)
            {
                await userManager.UpdateSecurityStampAsync(user);

                ViewBag.status = "success";
            }
            else
            {
                AddModelError(result);
            }
        }
        else
        {
            ModelState.AddModelError("", "hata meydana gelmiştir. Lütfen daha sonra tekrar deneyiniz.");
        }

        return RedirectToAction("Login");
    }

}
