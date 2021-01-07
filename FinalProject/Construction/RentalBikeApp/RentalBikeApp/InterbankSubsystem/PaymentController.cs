﻿// --------------------RENTAL BIKE APP-----------------
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
using RentalBikeApp.Entities.InterbankEntities;
using RentalBikeApp.Entities.SQLEntities;
using static RentalBikeApp.InterbankSubsystem.InterbankConstant;
using RentalBikeApp.CustomException;

namespace RentalBikeApp.InterbankSubsystem
{
    /// <summary>
    /// Privider functions for process API
    /// </summary>
    public class PaymentController : IPayment
    {
        private InterbankBoundary boundary;

        /// <summary>
        /// contructor of PaymentController
        /// </summary>
        public PaymentController()
        {
            boundary = new InterbankBoundary();
        }

        private InterbankResponse MakeResponse(string result)
        {
            InterbankResponse response = JsonConvert.DeserializeObject<InterbankResponse>(result);
            switch (response.errorCode)
            {
                case "00":
                    return response;
                case "01":
                    throw new InvalidCardException();
                case "02":
                    throw new NotEnoughBalanceException();
                case "03":
                    throw new InternalServerErrorException();
                case "04":
                    throw new SuspiciousTransactionException();
                case "05":
                    throw new NotEnoughTransactionInfoException();
                case "06":
                    throw new InvalidVersionException();
                case "07":
                    throw new InvalidTransactionAmountException();
                default:
                    throw new UnrecognizedException();
            }
        }

        /// <summary>
        /// Send transaction to server
        /// </summary>
        /// <param name="card">The card information</param>
        /// <param name="amount">The amount of transaction</param>
        /// <param name="date">Date time transaction processed</param>
        /// <param name="transactionContent">Note of transaction</param>
        /// <param name="_version">Version of API, default 1.0.1</param>
        /// <returns>The transaction response information</returns>
        /// <exception cref="PaymentException"></exception>
        public async Task<InterbankResponse> Pay(Card card, int amount, DateTime date, string transactionContent, string _version = "1.0.1")
        {
            TransactionInfo info = new TransactionCardInfo
            (
                "pay", card.CardCode, card.Owners,
                card.CVV, card.DateExpired,
                transactionContent, amount,
                Utilities.ConvertDateToString(date)
            );
            ProcessTransactionRequest body = new ProcessTransactionRequest
            (
                _version, info, card.AppCode,
                Utilities.MD5Hash(JsonConvert.SerializeObject(new
                {
                    secretKey = card.SecurityKey,
                    transaction = info
                }))
            );
            string result = await boundary.SendRequest(BASE_URL + PROCESS_URL, HttpMethod.Patch, JsonConvert.SerializeObject(body));
            return MakeResponse(result);
        }

        /// <summary>
        /// Send transaction to server
        /// </summary>
        /// <param name="card">The card information</param>
        /// <param name="amount">The amount of transaction</param>
        /// <param name="date">Date time transaction processed</param>
        /// <param name="transactionContent">Note of transaction</param>
        /// <param name="_version">Version of API, default 1.0.1</param>
        /// <returns>The transaction response information</returns>
        /// <exception cref="PaymentException"></exception>
        public async Task<InterbankResponse> Refund(Card card, int amount, DateTime date, string transactionContent, string _version = "1.0.1")
        {
            TransactionInfo info = new TransactionCardInfo
            (
                "refund", card.CardCode, card.Owners,
                card.CVV, card.DateExpired,
                transactionContent, amount,
                Utilities.ConvertDateToString(date)
            );
            ProcessTransactionRequest body = new ProcessTransactionRequest
            (
                _version, info, card.AppCode,
                Utilities.MD5Hash(JsonConvert.SerializeObject(new
                {
                    secretKey = card.SecurityKey,
                    transaction = info
                }))
            );
            string result = await boundary.SendRequest(BASE_URL + PROCESS_URL, HttpMethod.Patch, JsonConvert.SerializeObject(body));
            return MakeResponse(result);
        }

        /// <summary>This function use for test API, it reset the balance in the account</summary>
        /// <param name="card">the card information</param>
        /// <returns>The reset response information</returns>
        /// <exception cref="PaymentException"></exception>
        public async Task<InterbankResponse> ResetAccount(Card card)
        {
            var body = new
            {
                cardCode = card.CardCode,
                owner = card.Owners,
                cvvCode = card.CVV,
                dateExpired = card.DateExpired
            };
            string result = await boundary.SendRequest(BASE_URL + RESET_URL, HttpMethod.Patch, JsonConvert.SerializeObject(body));
            return MakeResponse(result);
        }
    }
}
