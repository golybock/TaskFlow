using TF.DatabaseModels.Models.User;
using TF.Tools.Enums;

namespace TF.DomainModels.Models.User;

public class UserDomain
{
    public Guid Id { get; set; }

    public String FullName { get; set; } = null!;

    public String Username { get; set; } = null!;

    public String Email { get; set; } = null!;

    public String Letters { get; set; } = null!;

    public String? ImageUrl { get; set; }

    public Role Role { get; set; }

    public UserDomain()
    {
    }

    public UserDomain(Guid id, string fullName, string username, string email, string letters, string? imageUrl, Role role)
    {
        Id = id;
        FullName = fullName;
        Username = username;
        Email = email;
        Letters = letters;
        ImageUrl = imageUrl;
        Role = role;
    }

    public UserDomain(UserDatabase userDatabase)
    {
        Id = userDatabase.Id;
        FullName = userDatabase.FullName;
        Username = userDatabase.Username;
        Email = userDatabase.Email;
        Letters = userDatabase.Letters;
        ImageUrl = userDatabase.ImageUrl;
        Role = userDatabase.RoleId;
    }
}