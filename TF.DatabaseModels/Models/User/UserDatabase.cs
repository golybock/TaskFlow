using TF.Tools.Enums;

namespace TF.DatabaseModels.Models.User;

public class UserDatabase
{
    public Guid Id { get; set; }

    public String FullName { get; set; } = null!;

    public String Username { get; set; } = null!;

    public String Email { get; set; } = null!;

    public Byte[] Password { get; set; } = null!;

    public String Letters { get; set; } = null!;

    public String? ImageUrl { get; set; }

    public Role RoleId { get; set; }

    public Boolean Deleted { get; set; }
}