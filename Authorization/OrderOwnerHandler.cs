using System.Security.Claims;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AddisEats.Api.Authorization;

public class OrderOwnerHandler : AuthorizationHandler<OperationAuthorizationRequirement, Order>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Order resource)
    {
      var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

      if(context.User.IsInRole("customer") && resource.CustomerId.ToString() == userId)
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}