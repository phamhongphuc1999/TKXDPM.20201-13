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
using RentalBikeApp.Data;
using RentalBikeApp.Data.ServiceAgents.BikeServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;

namespace ReantalBikeTest.ServiceAgents
{
    [TestFixture]
    class ElectricBikeServiceTest
    {
        private SQLConnecter connecter = SQLConnecter.GetInstance();
        private ElectricBikeService electricBikeService;

        [SetUp]
        public void Setup()
        {
            electricBikeService = new ElectricBikeService(connecter);
        }

        /// <summary>
        /// Test for get bike by QR Code
        /// </summary>
        [Test]
        public void GetBikeByQRCodeTest()
        {
            ElectricBike electricBike = electricBikeService.GetBikeByQRCode("200000001");
            Assert.IsTrue(electricBike is ElectricBike);
        }

        /// <summary>
        /// Test for get bike by not exist QR Code
        /// </summary>
        [Test]
        public void GetBikeByNotExistQRcodeTest()
        {
            ElectricBike electricBike = electricBikeService.GetBikeByQRCode("200000000");
            Assert.IsNull(electricBike);
        }

        /// <summary>
        /// Test for get bike by id
        /// </summary>
        [Test]
        public void GetBikeByIdTest()
        {
            ElectricBike electricBike = electricBikeService.GetBikeById(1);
            Assert.IsTrue(electricBike is ElectricBike);
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

        /// <summary>
        /// Test for update bike
        /// </summary>
        [Test]
        public void UpdateBikeTest()
        {
            UpdateBikeInfo update = new UpdateBikeInfo()
            {
                Manufacturer = "A"
            };
            ElectricBike bike = electricBikeService.UpdateBike(1, update);
            Assert.IsTrue(bike.Manufacturer == "A");
        }
    }
}
