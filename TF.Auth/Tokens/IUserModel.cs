namespace TF.Auth.Tokens;

public interface IUserModel
{
    public string Username { get; set; }

    public string ToJson();
}