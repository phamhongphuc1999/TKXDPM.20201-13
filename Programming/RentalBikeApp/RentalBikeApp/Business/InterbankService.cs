// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using Newtonsoft.Json;
using RentalBikeApp.Entities.APIEntities;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalBikeApp.Business
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
        public ResetResponse ResetAccount(string _cardCode = Config.API_INFO.CARD_INFO.CARD_CODE, string _owner = Config.API_INFO.CARD_INFO.OWER,
            string _cvvCode = Config.API_INFO.CARD_INFO.CVV, string _dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED)
        {
            var body = new
            {
                cardCode = _cardCode,
                owner = _owner,
                cvvCode = _cvvCode,
                dateExpired = _dateExpired
            };
            Task<string> result = Utilities.GetWebContent(Config.API_INFO.BASE_URL + Config.API_INFO.RESET_URL,
                HttpMethod.Patch, JsonConvert.SerializeObject(body));
            ResetResponse response = JsonConvert.DeserializeObject<ResetResponse>(result.Result);
            return response;
        }
    }
}
