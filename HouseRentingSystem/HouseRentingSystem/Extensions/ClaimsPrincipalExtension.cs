using System.Security.Claims;

namespace Microsoft.Extensions.DependencyInjection;

public static class ClaimsPrincipalExtension
{
    public static string Id(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}