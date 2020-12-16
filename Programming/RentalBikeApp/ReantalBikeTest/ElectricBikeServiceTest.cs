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
using System.Collections.Generic;

namespace ReantalBikeTest
{
    [TestFixture]
    class ElectricBikeServiceTest
    {
        private ElectricBikeService electricBikeService;

        [SetUp]
        public void Setup()
        {
            electricBikeService = new ElectricBikeService();
        }

        /// <summary>
        /// Test for get bike by QR Code
        /// </summary>
        [Test]
        public void GetBikeByQRCodeTest()
        {
            ElectricBike electricBike = electricBikeService.GetBikeByQRCode(" ");
            Assert.IsNotNull(electricBike);
        }

        /// <summary>
        /// Test for get bike by id
        /// </summary>
        [Test]
        public void GetBikeByIdTest()
        {
            ElectricBike electricBike = electricBikeService.GetBikeById(1);
            Assert.IsNotNull(electricBike);
        }

        /// <summary>
        /// Test for get list bike in the station
        /// </summary>
        [Test]
        public void GetListBikesInStationTest()
        {
            List<ElectricBike> electricBikes = electricBikeService.GetListBikesInStation(1);
            Assert.IsTrue(electricBikes.Count > 0);
        }
    }
}
