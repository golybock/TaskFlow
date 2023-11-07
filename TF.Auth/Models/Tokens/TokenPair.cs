namespace TF.Auth.Models.Tokens;

public class TokenPair : ITokenPair
{
    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}