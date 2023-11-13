using Microsoft.AspNetCore.Identity;

namespace ECommerse.DataAccess.Localizations;

internal class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DuplicateEmail(string email)
    {
        return new IdentityError() { Code = "DublicateEmail", Description = $"{email} bu ünvan ilə artıq qeydiyyatdan keçilib." };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError() { Code = "DublicateUserName", Description = $"{userName} isdifadəçi adı artıq götürülüb." };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError() { Code = "PasswordTooShort", Description = "Şifrə minimum 8 simvoldan ibarət olmalıdır." };
    }
    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError() { Code = "PasswordRequiresDigit", Description = "Şifrədə ən az 1 rəqəm yazılmalıdır." };
    }
}
