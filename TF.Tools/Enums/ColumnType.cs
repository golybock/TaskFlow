using System.ComponentModel.DataAnnotations;

namespace TF.Tools.Enums;

public enum ColumnType
{
    [Display(Name = nameof(BackLog))]
    BackLog = 1,
    [Display(Name = nameof(InWork))]
    InWork = 2,
    [Display(Name = nameof(WorkDone))]
    WorkDone = 3
}