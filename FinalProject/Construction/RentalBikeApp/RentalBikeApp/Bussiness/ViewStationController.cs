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

using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Data;

namespace RentalBikeApp.Bussiness
{
    /// <summary>
    /// Provider flow for view detail station
    /// </summary>
    public class ViewStationController
    {
        private StationService stationService;

        /// <summary>
        /// Contructor of ViewStationController
        /// </summary>
        public ViewStationController()
        {
            stationService = new StationService(SQLConnecter.GetInstance());
        }

        /// <summary>
        /// Get specified station information
        /// </summary>
        /// <param name="stationId">The station id you want to get</param>
        /// <returns>The station</returns>
        public Station ViewStationDetail(int stationId)
        {
            return stationService.GetStationById(stationId);
        }

        /// <summary>
        /// Get all of station in database
        /// </summary>
        /// <returns>The list stations</returns>
        public List<Station> ViewListStation()
        {
            List<Station> stations = stationService.GetListStations();
            return stations;
        }
    }
}
