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
using System;
using System.Collections.Generic;

namespace ReantalBikeTest
{
    [TestFixture]
    class TandemServiceTest
    {
        private TandemService tandemService;
        [SetUp]
        public void Setup()
        {
            tandemService = new TandemService();
        }
        [Test]
        public void GetBikeByQRCodeTest()
        {
            Tandem tandem = tandemService.GetBikeByQRCode(" ");
            Assert.IsNotNull(tandem);
        }
        [Test]
        public void GetBikeByIdTest()
        {
            Tandem tandem = tandemService.GetBikeById(1);
            Assert.IsNotNull(tandem);
        }
        [Test]
        public void GetListBikesInStationTest()
        {
            List < Tandem > tandems = tandemService.GetListBikesInStation(1);
            Assert.IsTrue(tandems.Count > 0);
        }

    }
}
