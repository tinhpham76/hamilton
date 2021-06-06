using System;
using System.Security.Cryptography;
using System.Text;

namespace Core.Libs.Utils
{
    public class Hash
    {
        public static string HmacSha256ToBase64(string originalData, string secretKey)
        {
            return Hash.hmacSha256(originalData, secretKey, true);
        }

        public static string HmacSha256(string originalData, string secretKey)
        {
            return Hash.hmacSha256(originalData, secretKey, false);
        }
        
        private static string hmacSha256(string originalData, string secretKey, bool toBase64)
        {
            var hashed = string.Empty;

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(originalData));

                hashed = toBase64
                    ? Convert.ToBase64String(hash)
                    : BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

            return hashed;
        }

        public static string HmacSha1(string originalData, string secretKey)
        {
            var hashed = string.Empty;

            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey)))
            {
                var data = hmac.ComputeHash(Encoding.UTF8.GetBytes(originalData));

                var sb = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("x2"));

                hashed = sb.ToString();
            }

            return hashed;
        }

        public static string Md5(string originalData)
        {
            var hashed = string.Empty;

            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(originalData));

                var sb = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("x2"));

                hashed = sb.ToString();
            }

            return hashed;
        }
    }
}