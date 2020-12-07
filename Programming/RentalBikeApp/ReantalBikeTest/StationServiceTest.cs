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
        public void GetListStationsTest()
        {
            List<Station> stations = stationService.GetListStations();
            Assert.IsTrue(stations.Count > 0);
        }
        [Test]
        public void GetStationByIdTest()
        {
            Station station = stationService.GetStationById(1);
            Assert.IsNotNull(station);   
        }
        [Test]
        public void GetStationByNameTest()
        {
            Station station = stationService.GetStationByName("B");
            Assert.IsNotNull(station);
        }
    }
}
