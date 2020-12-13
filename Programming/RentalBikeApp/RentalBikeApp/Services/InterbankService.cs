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
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using RentalBikeApp.Entities.APIEntities;

namespace RentalBikeApp.Services
{
    public class InterbankService
    {
        /// <summary>Send request to API to process transaction</summary>
        /// <param name="body">The request's body</param>
        /// <param name="command">The definition of the request is for payment or refund</param>
        /// <returns>The process transaction response information</returns>
        public async Task<ProcessTransactionResponse> ProcessTransaction(ProcessTransactionRequest body, Config.API_INFO.COMMAND command)
        {
            if (command == Config.API_INFO.COMMAND.PAY) body.transaction.command = "pay";
            else body.transaction.command = "refund";
            string result = await Utilities.GetWebContent(Config.API_INFO.BASE_URL + Config.API_INFO.PROCESS_URL, 
                HttpMethod.Patch, JsonConvert.SerializeObject(body));
            ProcessTransactionResponse response = JsonConvert.DeserializeObject<ProcessTransactionResponse>(result);
            return response;
        }

        /// <summary>Send request to API to process transaction</summary>
        /// <param name="transactionInfo">Information of transaction</param>
        /// <param name="command">The definition of the request is for payment or refund</param>
        /// <param name="_version">The API's version</param>
        /// <param name="_appCode">The code use to authentication</param>
        /// <returns>The process transaction response information</returns>
        public async Task<ProcessTransactionResponse> ProcessTransaction(TransactionInfo transactionInfo, Config.API_INFO.COMMAND command, 
            string _version = "1.0.1", string _appCode = Config.API_INFO.KEY.APP_CODE)
        {
            if (command == Config.API_INFO.COMMAND.PAY) transactionInfo.command = "pay";
            else transactionInfo.command = "refund";
            ProcessTransactionRequest body = new ProcessTransactionRequest()
            {
                version = _version,
                transaction = transactionInfo,
                appCode = _appCode,
                hashCode = Utilities.MD5Hash(JsonConvert.SerializeObject(new {
                    secretKey = Config.API_INFO.KEY.SECRET_KEY,
                    transaction = transactionInfo
                }))
            };
            string result = await Utilities.GetWebContent(Config.API_INFO.BASE_URL + Config.API_INFO.PROCESS_URL,
                HttpMethod.Patch, JsonConvert.SerializeObject(body));
            ProcessTransactionResponse response = JsonConvert.DeserializeObject<ProcessTransactionResponse>(result);
            return response;
        }

        /// <summary>This function use for test API, it reset the balance in the account</summary>
        /// <param name="_cardCode"></param>
        /// <param name="_owner"></param>
        /// <param name="_cvvCode"></param>
        /// <param name="_dateExpired"></param>
        /// <returns>The reset response information</returns>
        public async Task<ResetResponse> ResetAccount(string _cardCode = Config.API_INFO.CARD_INFO.CARD_CODE, string _owner = Config.API_INFO.CARD_INFO.OWER,
            string _cvvCode = Config.API_INFO.CARD_INFO.CVV, string _dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED)
        {
            var body = new
            {
                cardCode = _cardCode,
                owner = _owner,
                cvvCode = _cvvCode,
                dateExpired = _dateExpired
            };
            string result = await Utilities.GetWebContent(Config.API_INFO.BASE_URL + Config.API_INFO.RESET_URL,
                HttpMethod.Patch, JsonConvert.SerializeObject(body));
            ResetResponse response = JsonConvert.DeserializeObject<ResetResponse>(result);
            return response;
        }

        /// <summary>
        /// Calculate rental fee for rental bike
        /// </summary>
        /// <param name="timeRent">The time that the user has rented the car</param>
        /// <param name="category">The category of rental bike</param>
        /// <returns>The rental money that use must rent</returns>
        public int CalculateFee(string timeRent, Config.SQL.BikeCategory category)
        {
            string[] times = timeRent.Split(':');
            double hour = Int64.Parse(times[0]);
            double minute = Int64.Parse(times[1]);
            double second = Int64.Parse(times[2]);
            double timeMinutes = 60 * hour + minute + Math.Abs(second / 60) - 10;
            if (category != Config.SQL.BikeCategory.BIKE) timeMinutes = 1.5 * timeMinutes;
            if (timeMinutes <= 0) return 0;
            timeMinutes -= 30;
            if (timeMinutes <= 0) return 10000;
            return (int)(10000 + Math.Abs(timeMinutes / 15));
        }
    }
}
