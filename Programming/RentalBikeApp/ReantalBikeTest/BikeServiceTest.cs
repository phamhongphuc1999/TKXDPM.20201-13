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
using System.Collections.Generic;

namespace ReantalBikeTest
{
    [TestFixture]
    class BikeServiceTest
    {
        private BikeService bikeService;

        [SetUp]
        public void Setup()
        {
            bikeService = new BikeService();
        }

        [Test]
        public void GetBikeByQRCodeTest()
        {
            BaseBike bike = bikeService.GetBikeByQRCode("000000001");
            Assert.IsNotNull(bike);
        }

        [Test]
        public void GetBikeByIdTest()
        {
            BaseBike bike = bikeService.GetBikeById(1);
            Assert.IsNotNull(bike);
        }

        //[Test]
        //public void GetListAllBikesInStationTest()
        //{
        //    List<BaseBike> bikes = bikeService.GetListBikesInStation(1);
        //    Assert.IsTrue(bikes.Count > 0);
        //}

        //[Test]
        //public void GetListElectricBikesInStationTest()
        //{
        //    List<BaseBike> bikes = bikeService.GetListBikesInStation(1, RentalBikeApp.Config.SQL.BikeCategory.ELECTRIC);
        //    Assert.IsTrue(bikes.Count > 0);
        //}
    }
}
