using System.Text.RegularExpressions;

namespace XML4PFR.Extensions
{
    public static class StringEx
    {
        public static string Clean(this string value)
        {
            return Regex.Replace(value.Trim(), "\\s|-|\\.|_", string.Empty);
        }
    }
}
