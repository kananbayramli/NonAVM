using ECommerse.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerse.DataAccess.CustomValidations;

public class PasswordValidator : IPasswordValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
    {
        var errors = new List<IdentityError>();
        if (password!.ToLower().Contains(user.Name.ToLower()) || password!.ToLower().Contains(user.Surname.ToLower()) || password!.ToLower().Contains(user.UserName!.ToLower()))
        {
            errors.Add(new IdentityError() { Code = "PasswordContainsUserInfo", Description = "Şirə isdifadəçi məlumatlarından ibarət ola bilməz" });
        }

        return errors.Any() ? Task.FromResult(IdentityResult.Failed(errors.ToArray())) : Task.FromResult(IdentityResult.Success);
    }
}
