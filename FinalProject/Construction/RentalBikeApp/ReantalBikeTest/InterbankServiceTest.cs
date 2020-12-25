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
using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Threading.Tasks;
using static RentalBikeApp.Config.API_INFO;

namespace ReantalBikeTest
{
    /// <summary>
    /// Test for interbank service
    /// </summary>
    [TestFixture]
    public class InterbankServiceTest
    {
        private Card testCard;

        /// <summary>
        /// setup before test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            testCard = new Card
            {
                //CardId = 1, UserId = 1,
                //CardCode = "118609_group13_2020",
                //Owners = "Group 13",
                //CVV = "474", Bank = "Bank 2",
                //DateExpired = "1125",
                //AppCode = "Bi3TiyT5q00=",
                //SecurityKey = "B92s318KCwI="
            };
        }

        /// <summary>
        /// Test for case process transaction with zero amount
        /// </summary>
        [Test, Order(0)]
        public void ProcessTransactionErrorAmountTest()
        {
            Task<ProcessTransactionResponse> response = InterbankService.ProcessTransaction(testCard, COMMAND.PAY, 0, DateTime.Now, "Pay Deposit");
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
            Task<ProcessTransactionResponse> response = InterbankService.ProcessTransaction(testCard, COMMAND.PAY, 700000, DateTime.Now, "Pay Deposit");
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
            Task<ProcessTransactionResponse> response = InterbankService.ProcessTransaction(testCard, COMMAND.PAY, 700000, DateTime.Now, "Pay Deposit");
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
            Task<ResetResponse> response = InterbankService.ResetAccount(testCard);
            response.Wait();
            ResetResponse result = response.Result;
            Assert.AreEqual("00", result.errorCode);
        }
    }
}
