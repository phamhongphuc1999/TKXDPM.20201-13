using System;
using System.Security.Cryptography;
using System.Text;

namespace TestAPI.Entity
{
    public static class Utility
    {
        public static string ConvertDateToString(int year, int mounth, int day, int hour, int minute, int second)
        {
            DateTime date = new DateTime(year, mounth, day, hour, minute, second);
            string result = date.ToString("u");
            int length = result.Length;
            return result.Substring(0, length - 1);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
