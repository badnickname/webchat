using System.Text.RegularExpressions;

namespace WebChat.Utility
{
    public static class StringExpansion
    {
        public static string RemoveHtmlTags(this string str)
        {
            return str.Replace("<", "").Replace(">", "");
        }

        public static string FillEmpty(this string str, string name)
        {
            return str.Length < 1 ? name : str.Trim();
        }

        public static string DeleteAdminName(this string str)
        {
            var rx = new Regex("^(A|A)dmin$");
            return rx.IsMatch(str) ? "Lier" : str;
        }
        
        public static string ReplaceName(this string str)
        {
            return str == "me" ? "Admin" : str;
        }
        
        public static string RemoveSpaces(this string str)
        {
            return str.Replace("\n", "");
        }
        
        public static string TrimSize(this string str, int size)
        {
            return str.Length > size ? str.Substring(0, size) : str;
        }
    }
}