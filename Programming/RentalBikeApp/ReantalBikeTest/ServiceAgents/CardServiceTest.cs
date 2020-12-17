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
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Entities.SQLEntities;

namespace ReantalBikeTest.ServiceAgents
{
    [TestFixture]
    class CardServiceTest
    {
        private CardService cardService;

        [SetUp]
        public void Setup()
        {
            cardService = new CardService();
        }

        /// <summary>
        /// Test for case get card by exist card holder
        /// </summary>
        [Test]
        public void GetCardByExistOwnerTest()
        {
            Card card = cardService.GetCardByOwner("Group 13");
            Assert.IsNotNull(card);
        }

        /// <summary>
        /// Test for case get card by error card holder
        /// </summary>
        [Test]
        public void GetCardByErrorOwnerTest()
        {
            Card card = cardService.GetCardByOwner("123");
            Assert.IsNull(card);
        }

        /// <summary>
        /// Test for case get card by exist user
        /// </summary>
        [Test]
        public void GetCardByExistUser()
        {
            Card card = cardService.GetCardByUser(1);
            Assert.IsNotNull(card);
        }

        /// <summary>
        /// Test for case get card by error user
        /// </summary>
        [Test]
        public void GetCardByErrorUser()
        {
            Card card = cardService.GetCardByUser(0);
            Assert.IsNull(card);
        }
    }
}
