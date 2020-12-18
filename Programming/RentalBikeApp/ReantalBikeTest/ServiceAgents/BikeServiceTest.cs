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
using RentalBikeApp.Data;
using RentalBikeApp.Data.ServiceAgents.BikeServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;

namespace ReantalBikeTest.ServiceAgents
{
    [TestFixture]
    class BikeServiceTest
    {
        private SQLConnecter connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
        private BikeService bikeService;

        [SetUp]
        public void Setup()
        {
            bikeService = new BikeService(connecter);
        }

        /// <summary>
        /// Test for case get bike with correct QR Code
        /// </summary>
        [Test]
        public void GetBikeByQRCodeTest()
        {
            Bike bike = bikeService.GetBikeByQRCode("000000001");
            Assert.IsTrue(bike is Bike);
        }

        /// <summary>
        /// Test for case get bike with not exist QR Code
        /// </summary>
        [Test]
        public void GetBikeWithNotExistQRCodeTest()
        {
            Bike bike = bikeService.GetBikeByQRCode("000000000");
            Assert.IsNull(bike);
        }

        /// <summary>
        /// Test for case get bike by id
        /// </summary>
        [Test]
        public void GetBikeByIdTest()
        {
            Bike bike = bikeService.GetBikeById(1);
            Assert.IsTrue(bike is Bike);
        }

        /// <summary>
        /// Test for case get all bike in the station
        /// </summary>
        [Test]
        public void GetListAllBikesInStationTest()
        {
            List<Bike> bikes = bikeService.GetListBikesInStation(1);
            Assert.IsTrue(bikes.Count > 0);
        }
    }
}
