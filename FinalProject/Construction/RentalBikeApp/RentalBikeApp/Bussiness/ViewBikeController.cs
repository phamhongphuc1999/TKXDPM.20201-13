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

using RentalBikeApp.Data;
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using static RentalBikeApp.Constant;

namespace RentalBikeApp.Bussiness
{
    /// <summary>
    /// Provider flow for view bike
    /// </summary>
    public class ViewBikeController
    {
        private BaseBikeService bikeService;

        /// <summary>
        /// Contructor of ViewBikeController
        /// </summary>
        public ViewBikeController()
        {
            bikeService = new BaseBikeService(SQLConnecter.GetInstance());
        }

        /// <summary>
        /// Get bike information
        /// </summary>
        /// <param name="bikeId">The bike id you want to get information</param>
        /// <returns>The BaseBike representing the bike you want to get</returns>
        public BaseBike ViewBikeDetail(int bikeId)
        {
            BaseBike bike = bikeService.GetBikeById(bikeId);
            return bike;
        }

        /// <summary>
        /// Get list bike in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <param name="category"></param>
        /// <returns>The list bike</returns>
        public List<BaseBike> ViewListBikeInStation(int stationId, BikeCategory category)
        {
            List<BaseBike> bikes = bikeService.GetListBikesInStation(stationId, category);
            return bikes;
        }
    }
}
