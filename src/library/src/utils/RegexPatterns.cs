namespace Core.Libs.Utils
{
    public class RegexPatterns
    {
        public const string Email = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        public const string Phone = "(01|02|03|07|08|09|84)[\\d\\,\\.\\s\\(\\)\\-_]{6,}";
    }
}