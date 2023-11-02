using System.ComponentModel.DataAnnotations;

namespace TF.BlankModels.Models.User;

public class UserBlank
{
    [Required]
    public String FullName { get; set; } = null!;
    [Required]
    public String UserName { get; set; } = null!;
    [Required]
    public String Email { get; set; } = null!;

    public String? Password { get; set; }

    public String? ImageUrl { get; set; }
}