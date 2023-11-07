using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TF.Auth.Tokens;

public interface ITokenManager
{
    public bool TokenActive(string token);

    public bool TokenValid(string token);

    public string GenerateRefreshToken();

    public string GenerateToken(IEnumerable<Claim> claims);

    public ClaimsPrincipal GetPrincipalFromToken(string token);

    public String GetUserFromToken(string token);

    public String GetUserFromToken(JwtSecurityToken token);

    public String GetUserFromClaims(ClaimsPrincipal claims);


    public IEnumerable<Claim> CreateIdentityClaims(String user, String role);

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    protected JwtSecurityToken GenerateJwtSecurityToken(IEnumerable<Claim> claims);
}