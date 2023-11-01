using Microsoft.AspNetCore.Authorization;

namespace ECommerse.WebUI;

public class OneMonthTrialRequirement : IAuthorizationRequirement
{
}

public class OneMonthTrialHandler : AuthorizationHandler<OneMonthTrialRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OneMonthTrialRequirement requirement)
    {
        if (context.User != null & context.User!.Identity != null)
        {
            var claim = context.User.Claims.Where(x => x.Type == "OneMonthTrialRemaining" && x.Value != null).FirstOrDefault();

            if (claim != null)
            {
                if (Convert.ToDateTime(claim.Value) >= DateTime.Now)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
        }
        return Task.CompletedTask;
    }
}
