using System.ComponentModel.DataAnnotations;
using TF.Tools.Enums;

namespace TF.BlankModels.Models.User;

public class UserBlank
{
    [Required]
    public String FullName { get; set; } = null!;
    [Required]
    [MinLength(3)]
    public String UserName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public String Email { get; set; } = null!;

    public String? Password { get; set; }

    public String? ImageUrl { get; set; }

    public Role Role { get; set; }
}