using TF.BlankModels.Models.User;
using TF.Tools.Enums;

namespace TF.DatabaseModels.Models.User;

public class UserDatabase
{
    public Guid Id { get; set; }

    public String FullName { get; set; } = null!;

    public String Username { get; set; } = null!;

    public String Email { get; set; } = null!;

    public Byte[] Password { get; set; } = Array.Empty<Byte>();

    public String Letters { get; set; } = null!;

    public String? ImageUrl { get; set; }

    public Int32 RoleId { get; set; }

    public Boolean Deleted { get; set; }

    public UserDatabase()
    {
    }

    public UserDatabase(Guid id, string fullName, string username, string email, byte[] password, string letters,
        string? imageUrl, Role roleId, bool deleted)
    {
        Id = id;
        FullName = fullName;
        Username = username;
        Email = email;
        Password = password;
        Letters = letters;
        ImageUrl = imageUrl;
        RoleId = (int) roleId;
        Deleted = deleted;
    }

    // for create/update
    public UserDatabase(Guid id, UserBlank userBlank, byte[] password, string letters, Role role)
    {
        Id = id;
        FullName = userBlank.FullName;
        Username = userBlank.UserName; // not updates
        Email = userBlank.Email;
        Password = password;
        Letters = letters;
        ImageUrl = userBlank.ImageUrl;
        RoleId = (int) role;
    }
}