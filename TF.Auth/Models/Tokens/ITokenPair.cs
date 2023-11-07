namespace TF.Auth.Models.Tokens;

public interface ITokenPair
{
    public string Token { get; set; }

    public string RefreshToken { get; set; }
}