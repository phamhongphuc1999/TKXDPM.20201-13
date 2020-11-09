using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public static string ConvertDateToString(DateTime date)
        {
            string result = date.ToString("u");
            int length = result.Length;
            return result.Substring(0, length - 1);
        }

        private static byte[] ObjectToByteArray(Object objectToSerialize)
        {
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, objectToSerialize);
                return fs.ToArray();
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Error occurred during serialization. Message: " +
                se.Message);
                return null;
            }
            finally
            {
                fs.Close();
            }
        }

        private static string ComputeHash(byte[] objectAsBytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            try
            {
                byte[] result = md5.ComputeHash(objectAsBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch { 
                Console.WriteLine("Hash has not been generated.");
                return null;
            }
        }

        public static String GenerateKey(Object sourceObject)
        {
            String hashString;

            if (sourceObject == null)
            {
                throw new ArgumentNullException("Null as parameter is not allowed");
            }
            else
            {
                try
                {
                    hashString = ComputeHash(ObjectToByteArray(sourceObject));
                    return hashString;
                }
                catch (AmbiguousMatchException ame)
                {
                    throw new ApplicationException("Could not definitely decide if object is serializable.Message:" + ame.Message);
                }
            }
        }

        public static string MD5Hash(object obj)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(ObjectToByteArray(obj));

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
