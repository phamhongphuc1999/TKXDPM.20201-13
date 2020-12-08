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
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace ReantalBikeTest
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
        /// Test for case get card by card holder
        /// </summary>
        [Test]
        public void GetCardByOwnerTest()
        {
            Card card = cardService.GetCardByOwner("Group 13");
            Assert.IsNotNull(card);
        }
    }
}
