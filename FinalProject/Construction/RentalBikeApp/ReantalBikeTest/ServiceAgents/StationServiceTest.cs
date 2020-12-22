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
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;

namespace ReantalBikeTest.ServiceAgents
{
    [TestFixture]
    class StationServiceTest
    {
        private SQLConnecter connecter = SQLConnecter.GetInstance();
        private StationService stationService;

        [SetUp]
        public void Setup()
        {
            stationService = new StationService(connecter);
        }

        /// <summary>
        /// Test for get list station
        /// </summary>
        [Test]
        public void GetListStationsTest()
        {
            List<Station> stations = stationService.GetListStations();
            Assert.IsTrue(stations.Count > 0);
        }

        /// <summary>
        /// Test for get station by id
        /// </summary>
        [Test]
        public void GetStationByIdTest()
        {
            Station station = stationService.GetStationById(1);
            Assert.IsNotNull(station);   
        }

        /// <summary>
        /// Test for get station by name
        /// </summary>
        [Test]
        public void GetStationByNameTest()
        {
            Station station = stationService.GetStationByName("Station 1");
            Assert.IsNotNull(station);
        }

        /// <summary>
        /// Test for get station by not exist name
        /// </summary>
        [Test]
        public void GetStationByNotExistNameTest()
        {
            Station station = stationService.GetStationByName("abc");
            Assert.IsNull(station);
        }
    }
}
