using System.Text.RegularExpressions;

namespace Common;

public static class StringUtils
{
    public static string ToKebabCase(string str)
    {
        return Regex.Replace(str, "(?<!^)([A-Z])", "-$1").ToLower();
    }
}
