// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using NUnit.Framework;
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;

namespace ReantalBikeTest
{
    [TestFixture]
    class StationServiceTest
    {
        private StationService stationService;

        [SetUp]
        public void Setup()
        {
            stationService = new StationService();
        }
        [Test]
        public void GetListStation()
        {
            Station station = stationService.GetListStations();
            Assert.IsNotNull(station);
        }
    }
}
