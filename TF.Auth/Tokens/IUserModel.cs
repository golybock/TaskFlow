namespace TF.Auth.Tokens;

public interface IUserModel
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string? Role { get; set; }
}