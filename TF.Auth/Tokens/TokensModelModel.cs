namespace TF.Auth.Tokens;

public class TokensModelModel : ITokensModel
{
    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}