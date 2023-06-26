using API_Payroll.ViewModels.Others;
using System.Security.Claims;

namespace API_Payroll.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromxpiredToken(string token);
        ClaimVM ExtractClaimsFromJwt(string token);
    }
}
