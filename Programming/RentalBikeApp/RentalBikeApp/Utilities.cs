using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentalBikeApp
{
    public static class Utilities
    {
        public static string ConvertDateToString(int year, int mounth, int day, int hour, int minute, int second)
        {
            DateTime date = new DateTime(year, mounth, day, hour, minute, second);
            string result = date.ToString("u");
            int length = result.Length;
            return result.Substring(0, length - 1);
        }

        public static string ConvertDateToString(DateTime date)
        {
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

        public static async Task<string> GetWebContent(string url, HttpMethod method, string requestContent = null)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(method, url);
                if (requestContent != null)
                    requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
                string rcontent = await response.Content.ReadAsStringAsync();
                return rcontent;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
