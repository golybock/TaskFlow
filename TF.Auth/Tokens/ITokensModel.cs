namespace TF.Auth.Tokens;

public interface ITokensModel
{
    public string Token { get; set; }

    public string RefreshToken { get; set; }
}