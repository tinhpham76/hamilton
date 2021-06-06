using System.Text.RegularExpressions;

namespace Core.Libs.Utils
{
    public class Validate
    {
        public static bool IsRequired(string text, bool getTrim = true)
        {
            if (text != null && getTrim)
                text = text.Trim();

            return !string.IsNullOrEmpty(text);
        }

        public static bool IsValidLength(string text, int? minLength = null, int? maxLength = null)
        {
            if (!Validate.IsRequired(text))
                return false;

            var isValidMinLength = !minLength.HasValue || text.Length >= minLength.Value;
            var isValidMaxLength = !maxLength.HasValue || text.Length <= maxLength.Value;

            return isValidMinLength && isValidMaxLength;
        }

        public static bool IsEmail(string text)
        {
            if (!Validate.IsRequired(text))
                return false;
                
            return Regex.IsMatch(text, RegexPatterns.Email);
        }

        public static bool IsPhone(string text)
        {
            if (!Validate.IsRequired(text))
                return false;
                
            return Regex.IsMatch(text, RegexPatterns.Phone);
        }
    }
}