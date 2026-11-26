using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AddisEats.Api.Authorization;
public static class OrderOperations
{
    public static readonly OperationAuthorizationRequirement Read =
    new()
    {
        Name = nameof(Read)
    };
}