using System.Security.Claims;
using EstoqueApi.Models;

namespace EstoqueApi.Extensions;

public static class RoleClaimsExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email)
        };
        result.AddRange(
            user
                .profiles
                .Select(profile =>new Claim(
                    ClaimTypes.Role, profile.Slug)));
        return result;
    }
}