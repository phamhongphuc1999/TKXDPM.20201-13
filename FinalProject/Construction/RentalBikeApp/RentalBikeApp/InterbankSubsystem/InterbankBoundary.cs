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

using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using RentalBikeApp.CustomException;

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
        /// <exception cref="UnrecognizedException"></exception>
        public async Task<string> SendRequest(string url, HttpMethod method, string requestContent = null)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage requestMessage = new HttpRequestMessage(method, url);
                if (requestContent != null)
                    requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
                string rcontent = await response.Content.ReadAsStringAsync();
                return rcontent;
            }
            catch
            {
                throw new UnrecognizedException();
            }
        }
    }
}
