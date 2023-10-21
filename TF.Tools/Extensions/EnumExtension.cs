﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TF.Tools.Extensions;

public static class EnumExtension
{
    public static string? GetDisplayName(this Enum @enum)
    {
        return @enum.GetType()
            .GetMember(@enum.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
    }
}