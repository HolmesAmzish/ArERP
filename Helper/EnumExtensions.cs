using System.ComponentModel.DataAnnotations;

namespace ArERP.Helper;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        if (value == null) return string.Empty;

        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        if (memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attrs.Length > 0)
            {
                return ((DisplayAttribute)attrs[0]).Name ?? value.ToString();
            }
        }

        return value.ToString();
    }
}