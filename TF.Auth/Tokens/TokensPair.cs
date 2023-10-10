namespace TF.Auth.Tokens;

public class TokensPair : ITokensPair
{
    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}