using System;
using System.Collections.Generic;
using System.Text;
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

        [Test]
        public void GetCardByOwnerTest()
        {
            Card card = cardService.GetCardByOwner(1);
            Assert.IsNotNull(card);
        }
    }
}
