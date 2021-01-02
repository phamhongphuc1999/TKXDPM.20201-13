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
using RentalBikeApp.Entities.InterbankEntities;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.InterbankSubsystem;
using System;
using System.Threading.Tasks;

namespace ReantalBikeTest
{
    /// <summary>
    /// Test for interbank service
    /// </summary>
    [TestFixture]
    public class InterbankServiceTest
    {
        private Card testCard;
        private PaymentController paymentController;

        /// <summary>
        /// setup before test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            testCard = new Card
            (
                1, "118609_group13_2020",
                "Group 13", "474", "Bank 2",
                "1125", "Bi3TiyT5q00=", "B92s318KCwI="
            );

            paymentController = new PaymentController();
        }

        /// <summary>
        /// Test for case process transaction with zero amount
        /// </summary>
        [Test, Order(0)]
        public void ProcessTransactionErrorAmountTest()
        {
            Task<InterbankResponse> response = paymentController.Pay(testCard, 0, DateTime.Now, "Pay Deposit");
            response.Wait();
            InterbankResponse result = response.Result;
            Assert.AreEqual("05", result.errorCode);
        }

        /// <summary>
        /// Test for process correct transaction
        /// </summary>
        [Test, Order(1)]
        public void ProcessTransactionSuccessTest()
        {
            Task<InterbankResponse> response = paymentController.Pay(testCard, 700000, DateTime.Now, "Pay Deposit");
            response.Wait();
            InterbankResponse result = response.Result;
            Assert.AreEqual("00", result.errorCode);
        }

        /// <summary>
        /// Test for case process transaction with not enough money
        /// </summary>
        [Test, Order(2)]
        public void ProcessTransactionNotEnoughMoneyTest()
        {
            Task<InterbankResponse> response = paymentController.Pay(testCard, 700000, DateTime.Now, "Pay Deposit");
            response.Wait();
            InterbankResponse result = response.Result;
            Assert.AreEqual("02", result.errorCode);
        }

        /// <summary>
        /// Test for API reset account
        /// </summary>
        [Test, Order(3)]
        public void ResetAccountTest()
        {
            Task<InterbankResponse> response = paymentController.ResetAccount(testCard);
            response.Wait();
            InterbankResponse result = response.Result;
            Assert.AreEqual("00", result.errorCode);
        }
    }
}
