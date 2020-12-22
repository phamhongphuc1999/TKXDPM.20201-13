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
    class TandemServiceTest
    {
        private SQLConnecter connecter = SQLConnecter.GetInstance();
        private TandemService tandemService;

        [SetUp]
        public void Setup()
        {
            tandemService = new TandemService(connecter);
        }

        /// <summary>
        /// Test for get bike by QR Code
        /// </summary>
        [Test]
        public void GetBikeByQRCodeTest()
        {
            Tandem tandem = tandemService.GetBikeByQRCode("100000001");
            Assert.IsNotNull(tandem);
        }

        /// <summary>
        /// Test for get bike by not exist QR Code
        /// </summary>
        [Test]
        public void GetBikeByNotExistQRCodeTest()
        {
            Tandem tandem = tandemService.GetBikeByQRCode("100000000");
            Assert.IsNull(tandem);
        }

        /// <summary>
        /// Test for get bike by id
        /// </summary>
        [Test]
        public void GetBikeByIdTest()
        {
            Tandem tandem = tandemService.GetBikeById(1);
            Assert.IsNotNull(tandem);
        }

        /// <summary>
        /// Test for get list bike in the station
        /// </summary>
        [Test]
        public void GetListBikesInStationTest()
        {
            List <Tandem> tandems = tandemService.GetListBikesInStation(1);
            Assert.IsTrue(tandems.Count > 0);
        }

        /// <summary>
        /// Test for update bike
        /// </summary>
        [Test]
        public void UpdateBikeTest()
        {
            UpdateBikeInfo update = new UpdateBikeInfo
            {
                Manufacturer = "ABC"
            };
            Tandem bike = tandemService.UpdateBike(1, update);
            Assert.IsTrue(bike.Manufacturer == "ABC");
        }
    }
}
