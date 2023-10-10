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

    public IUserModel GetUserFromToken(string token);

    public IUserModel GetUserFromToken(JwtSecurityToken token);

    public IUserModel GetUserFromClaims(ClaimsPrincipal claims);

    public IEnumerable<Claim> CreateIdentityClaims(IUserModel userModel);

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    protected JwtSecurityToken GenerateJwtSecurityToken(IEnumerable<Claim> claims);
}