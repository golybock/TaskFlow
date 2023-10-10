namespace TF.Auth.Tokens;

public interface ITokensPair
{
    public string Token { get; set; }

    public string RefreshToken { get; set; }
}