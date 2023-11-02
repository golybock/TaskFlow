using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using TF.Auth.Options;

namespace TF.Auth.Tokens;

public class TokenManager : ITokenManager
{
    private readonly IRefreshCookieOptions _options;

    public TokenManager(IRefreshCookieOptions options)
    {
        _options = options;
    }

    #region validate params from appsettings or options

    private string? Secret => _options.Secret;

    private string? ValidAudience => _options.ValidAudience;

    private string? ValidIssuer => _options.ValidIssuer;

    private long? TokenValidityTicks => _options.TokenLifeTimeTicks;

    private SymmetricSecurityKey IssuerSigningKey =>
        new(Encoding.UTF8.GetBytes(Secret!));

    private SigningCredentials SigningCredentials =>
        new(IssuerSigningKey, SecurityAlgorithms.HmacSha256);

    #endregion

    #region validate

    private bool ValidateIssuerSigningKey =>
        _options.ValidateIssuerSigningKey;

    private bool ValidateLifetime =>
        _options.ValidateLifetime;

    private bool ValidateIssuer =>
        _options.ValidateIssuer;

    private bool ValidateAudience =>
        _options.ValidateAudience;

    #endregion

    private TokenValidationParameters GetValidationParameters(bool validateLifetime = true) => new TokenValidationParameters
    {
        ValidateIssuerSigningKey = ValidateIssuerSigningKey,
        IssuerSigningKey = IssuerSigningKey,
        ValidateLifetime = validateLifetime,
        ValidateAudience = ValidateAudience,
        ValidateIssuer = ValidateIssuer,
        ValidAudience = ValidAudience,
        ValidIssuer = ValidIssuer
    };

    private DateTime GetTokenExpirationTime(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = handler.ReadJwtToken(token);

        return jwtSecurityToken.ValidTo;
    }

    private DateTime GetTokenExpirationTime(JwtSecurityToken token)
    {
        return token.ValidTo;
    }

    public bool TokenActive(string token)
    {
        var validTo = GetTokenExpirationTime(token);

        return validTo >= DateTime.UtcNow;
    }

    public bool TokenValid(string token)
    {
        var tokenValidationParameters = GetValidationParameters(ValidateLifetime);

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))

                return false;

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var token = GenerateJwtSecurityToken(claims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal GetPrincipalFromToken(string token)
    {
        var tokenValidationParameters = GetValidationParameters();

        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        return claims;
    }

    public IUserModel GetUserFromToken(string token)
    {
        var claims = GetPrincipalFromToken(token);

        var user = claims.FindFirst(ClaimTypes.Authentication)?.Value;

        return JsonSerializer.Deserialize<IUserModel>(user!)!;
    }

    public IUserModel GetUserFromToken(JwtSecurityToken token)
    {
        var claims = token.Claims;

        var user = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Authentication)?.Value;

        return JsonSerializer.Deserialize<IUserModel>(user!)!;
    }

    public IUserModel GetUserFromClaims(ClaimsPrincipal claims)
    {
        var user = claims.FindFirst(ClaimTypes.Authentication)?.Value;

        return JsonSerializer.Deserialize<IUserModel>(user!)!;
    }

    public IEnumerable<Claim> CreateIdentityClaims(IUserModel userModel)
    {
        return new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userModel.Username),
            new Claim(ClaimTypes.Role, userModel.Role ?? "None"),
            new Claim(ClaimTypes.Authentication, JsonSerializer.Serialize(userModel))
        };
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = GetValidationParameters(false);

        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        return claims;
    }

    public JwtSecurityToken GenerateJwtSecurityToken(IEnumerable<Claim> claims)
    {
        DateTime expires = new DateTime();

        // если включена валидация по времени
        if (ValidateLifetime)
        {
            // время не указано
            if (TokenValidityTicks == null)
                throw new Exception("Cannot read TokenValidityTicks, but validatingLifeTime = true");

            expires = DateTime.UtcNow.AddTicks(TokenValidityTicks.Value);
        }

        // creating token
        var token = new JwtSecurityToken(
            issuer: ValidIssuer,
            audience: ValidAudience,
            claims: claims,
            expires: expires,
            signingCredentials: SigningCredentials
        );

        return token;
    }
}