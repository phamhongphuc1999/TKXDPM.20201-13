// --------------------RENTAL BIKE APP-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//   Su Huu Vu Quang
//   Pham Hong Phuc
//   Tran Minh Quang
//   Ngo Minh Quang
//
//
// ------------------------------------------------------

using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace RentalBikeApp
{
    public static class Utilities
    {
        /// <summary>
        /// Convert date to string format: yyyy-mm-dd hh:mm:ss
        /// </summary>
        /// <param name="year">year of date to convert</param>
        /// <param name="mounth">mounth of date to convert</param>
        /// <param name="day">day of date to convert</param>
        /// <param name="hour">hour of date to convert</param>
        /// <param name="minute">minute of date to convert</param>
        /// <param name="second">second of date to convert</param>
        /// <returns>the string with format: yyyy-mm-dd hh:mm:ss</returns>
        /// <example>
        /// <code>
        /// string date = Utilities.ConvertDateToString(1999, 12, 04, 10, 50, 00);
        /// console.Write(date);
        /// </code>
        /// </example>
        public static string ConvertDateToString(int year, int mounth, int day, int hour, int minute, int second)
        {
            DateTime date = new DateTime(year, mounth, day, hour, minute, second);
            string result = date.ToString("u");
            int length = result.Length;
            return result.Substring(0, length - 1);
        }

        /// <summary>
        /// Convert date to string format: yyyy-mm-dd hh:mm:ss
        /// </summary>
        /// <param name="date">date want to convert</param>
        /// <returns>the string with format: yyyy-mm-dd hh:mm:ss</returns>
        /// <example>
        /// <code>
        /// string date = Utilities.ConvertDateToString(DateTime.Now);
        /// Console.Write(date);
        /// </code>
        /// </example>
        public static string ConvertDateToString(DateTime date)
        {
            string result = date.ToString("u");
            int length = result.Length;
            return result.Substring(0, length - 1);
        }

        /// <summary>
        /// Hash the specified string with MD5 hash code
        /// </summary>
        /// <param name="input">the string plaintext</param>
        /// <returns>the MD5 hash</returns>
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

        /// <summary>
        /// Sent a request to the specified url
        /// </summary>
        /// <param name="url">The url sent to</param>
        /// <param name="method">The http method of request</param>
        /// <param name="requestContent">The request's body, format json</param>
        /// <returns>The response with string format or exception message if cause error</returns>
        /// <exception cref="System.Exception">Throw when error</exception>
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

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        /// <summary>
        /// Set comboBox's height
        /// </summary>
        /// <param name="comboBoxHandle"></param>
        /// <param name="comboBoxDesiredHeight"></param>
        public static void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            const Int32 CB_SETITEMHEIGHT = 0x153;
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
    }
}
