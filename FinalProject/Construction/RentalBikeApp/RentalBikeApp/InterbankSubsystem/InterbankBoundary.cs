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

namespace RentalBikeApp.InterbankSubsystem
{
    internal class InterbankBoundary
    {
        /// <summary>
        /// Sent a request to the specified url
        /// </summary>
        /// <param name="url">The url sent to</param>
        /// <param name="method">The http method of request</param>
        /// <param name="requestContent">The request's body, format json</param>
        /// <returns>The response with string format or exception message if cause error</returns>
        /// <exception cref="System.Exception">Throw when error</exception>
        public async Task<string> SendRequest(string url, HttpMethod method, string requestContent = null)
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
