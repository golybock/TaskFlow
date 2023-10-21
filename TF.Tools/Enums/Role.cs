using System.ComponentModel.DataAnnotations;

namespace TF.Tools.Enums;

public enum Role
{
    [Display(Name = nameof(Admin))]
    Admin = 1,
    [Display(Name = nameof(Developer))]
    Developer = 2,
    [Display(Name = nameof(Viewer))]
    Viewer = 3
}