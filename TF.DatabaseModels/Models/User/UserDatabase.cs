using TF.Tools.Enums;

namespace TF.DatabaseModels.Models.User;

public class UserDatabase
{
    public Guid Id { get; set; }

    public String FullName { get; set; }

    public String Username { get; set; }

    public String Email { get; set; }

    public Byte[] Password { get; set; }

    public String Letters { get; set; }

    public String? ImageUrl { get; set; }

    public Role RoleId { get; set; }

    public Boolean Deleted { get; set; }

    public UserDatabase(){}

    public UserDatabase(Guid id, string fullName, string username, string email, byte[] password, string letters, string? imageUrl, Role roleId, bool deleted)
    {
        Id = id;
        FullName = fullName;
        Username = username;
        Email = email;
        Password = password;
        Letters = letters;
        ImageUrl = imageUrl;
        RoleId = roleId;
        Deleted = deleted;
    }
}