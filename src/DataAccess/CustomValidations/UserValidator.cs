
using ECommerse.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerse.DataAccess.CustomValidations;

internal class UserValidator : IUserValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
    {
        var errors = new List<IdentityError>();
        var allowed1stChars = " ._@".ToCharArray();
        if (int.TryParse(user!.UserName![0].ToString(), out _) || allowed1stChars.Contains(user!.UserName![0]))
        {
            errors.Add(new IdentityError() { Code="PermittedFirstChar", Description = "İsdifadəçi adı rəqəm və digər icazə verilməyən simvol ilə başlaya bilməz." });
        }

        return errors.Any() ? Task.FromResult(IdentityResult.Failed(errors.ToArray())) : Task.FromResult(IdentityResult.Success);
    }
}
