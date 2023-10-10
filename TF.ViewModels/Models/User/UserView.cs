using TF.Tools.Enums;

namespace TF.ViewModels.Models.User;

public class UserView
{
    public Guid Id { get; set; }

    public String FullName { get; set; } = null!;

    public String Username { get; set; } = null!;

    public String Email { get; set; } = null!;

    public String Letters { get; set; } = null!;

    public String? ImageUrl { get; set; }

    public Role Role { get; set; }
}