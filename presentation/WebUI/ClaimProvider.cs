using ECommerse.Core.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ECommerse.WebUI;

public class ClaimProvider : IClaimsTransformation
{
    public UserManager<AppUser> userManager { get; set; }

    public ClaimProvider(UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (principal is not null && principal.Identity.IsAuthenticated)
        {
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;

            AppUser user = await userManager.FindByNameAsync(identity.Name);

            if (user is null)
            {
                return principal;
            }
            if (user.BirthDay is null)
            {
                return principal;
            }
            var today = DateTime.Today;
            var age = today.Year - user.BirthDay?.Year;

            if (age >= 18)
            {
                Claim adulthoodClaim = new Claim("adult", true.ToString(), ClaimValueTypes.String, "Internal");

                identity.AddClaim(adulthoodClaim);
            }


            if (!principal.HasClaim(c => c.Type == "gender"))
            {
                Claim genderClaim = new Claim("gender", user.Gender.ToString(), ClaimValueTypes.String, "Internal");

                identity.AddClaim(genderClaim);
            }
        }

        return principal;
    }
}
