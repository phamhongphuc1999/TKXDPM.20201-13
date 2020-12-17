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

using NUnit.Framework;
using RentalBikeApp;
using RentalBikeApp.Entities.APIEntities;
using System;
using System.Threading.Tasks;

namespace ReantalBikeTest
{
    [TestFixture]
    public class InterbankServiceTest
    {
        /// <summary>
        /// Test for case process transaction with zero amount
        /// </summary>
        [Test, Order(0)]
        public void ProcessTransactionErrorAmountTest()
        {
            TransactionInfo info = new TransactionInfo()
            {
                cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                owner = Config.API_INFO.CARD_INFO.OWER,
                cvvCode = Config.API_INFO.CARD_INFO.CVV,
                dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                transactionContent = "Pay Deposit",
                amount = 0,
                createdAt = Utilities.ConvertDateToString(DateTime.Now)
            };
            Task<ProcessTransactionResponse> response = InterbankService.ProcessTransaction(info, Config.API_INFO.COMMAND.PAY);
            response.Wait();
            ProcessTransactionResponse result = response.Result;
            Assert.AreEqual("05", result.errorCode);
        }

        /// <summary>
        /// Test for process correct transaction
        /// </summary>
        [Test, Order(1)]
        public void ProcessTransactionSuccessTest()
        {
            TransactionInfo info = new TransactionInfo()
            {
                cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                owner = Config.API_INFO.CARD_INFO.OWER,
                cvvCode = Config.API_INFO.CARD_INFO.CVV,
                dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                transactionContent = "Pay Deposit",
                amount = 700000,
                createdAt = Utilities.ConvertDateToString(DateTime.Now)
            };
            Task<ProcessTransactionResponse> response = InterbankService.ProcessTransaction(info, Config.API_INFO.COMMAND.PAY);
            response.Wait();
            ProcessTransactionResponse result = response.Result;
            Assert.AreEqual("00", result.errorCode);
        }

        /// <summary>
        /// Test for case process transaction with not enough money
        /// </summary>
        [Test, Order(2)]
        public void ProcessTransactionNotEnoughMoneyTest()
        {
            TransactionInfo info = new TransactionInfo()
            {
                cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                owner = Config.API_INFO.CARD_INFO.OWER,
                cvvCode = Config.API_INFO.CARD_INFO.CVV,
                dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                transactionContent = "Pay Deposit",
                amount = 700000,
                createdAt = Utilities.ConvertDateToString(DateTime.Now)
            };
            Task<ProcessTransactionResponse> response = InterbankService.ProcessTransaction(info, Config.API_INFO.COMMAND.PAY);
            response.Wait();
            ProcessTransactionResponse result = response.Result;
            Assert.AreEqual("02", result.errorCode);
        }

        /// <summary>
        /// Test for API reset account
        /// </summary>
        [Test, Order(3)]
        public void ResetAccountTest()
        {
            Task<ResetResponse> response = InterbankService.ResetAccount();
            response.Wait();
            ResetResponse result = response.Result;
            Assert.AreEqual("00", result.errorCode);
        }
    }
}
