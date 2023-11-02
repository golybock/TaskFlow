using TF.Auth.Tokens;
using TF.DatabaseModels.Models.User;
using TF.DomainModels.Models.User;
using TF.Tools.Enums;
using TF.Tools.Extensions;

namespace TF.ViewModels.Models.User;

public class UserView : IUserModel
{
    public Guid Id { get; set; }

    public String FullName { get; set; } = null!;

    public String Username { get; set; } = null!;

    public String Email { get; set; } = null!;

    public String Letters { get; set; } = null!;

    public String? ImageUrl { get; set; }

    public string? Role { get; set; }

    public UserView(UserDomain userDomain)
    {
        Id = userDomain.Id;
        FullName = userDomain.FullName;
        Username = userDomain.Username;
        Email = userDomain.Email;
        Letters = userDomain.Letters;
        ImageUrl = userDomain.ImageUrl;
        Role = userDomain.Role.GetDisplayName();
    }
}