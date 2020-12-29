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
using static RentalBikeApp.Constant;
using System.Linq;

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provides functions to interact with BaseBike table in the database
    /// </summary>
    public class BaseBikeService: BaseService, IBikeService
    {
        /// <summary>
        /// contructor of BaseBikeService
        /// </summary>
        /// <param name="connecter">The instance representing connection to database</param>
        public BaseBikeService(SQLConnecter connecter) : base(connecter) { }

        /// <summary>
        /// Get bike by bike's id
        /// </summary>
        /// <param name="id">the bike's id you want to find</param>
        /// <returns>Return the bike with specified ID or null if not found</returns>
        public BaseBike GetBikeById(int id)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.Find(id);
            BaseBike result = null;
            if (baseBike.Category == "bike") result = new Bike(baseBike);
            else if (baseBike.Category == "tandem") result = new Tandem(baseBike);
            else if(baseBike.Category == "electric")
            {
                ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(baseBike.BikeId);
                result = new ElectricBike(baseBike, electricBike);
            }
            return result;
        }

        /// <summary>Get bike by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public BaseBike GetBikeByQRCode(string QRCode)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.SingleOrDefault(x => x.QRCode == QRCode);
            BaseBike result = null;
            if (baseBike.Category == "bike") result = new Bike(baseBike);
            else if (baseBike.Category == "tandem") result = new Tandem(baseBike);
            else if (baseBike.Category == "electric")
            {
                ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(baseBike.BikeId);
                result = new ElectricBike(baseBike, electricBike);
            }
            return result;
        }

        /// <summary>
        /// Filters a list bike in the station base on bike category
        /// </summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <param name="category"></param>
        /// <returns>Return the list base on bike category</returns>
        public List<BaseBike> GetListBikesInStation(int stationId, BikeCategory category)
        {
            IEnumerable<BaseBike> baseBikes = connecter.SqlData.BaseBikes.Where(x => x.StationId == stationId);
            if (category == BikeCategory.BIKE)
                baseBikes = baseBikes.Where(x => x.Category == "bike").Select(x => new Bike(x));
            else if (category == BikeCategory.TANDEM)
                baseBikes = baseBikes.Where(x => x.Category == "tandem").Select(x => new Tandem(x));
            else if (category == BikeCategory.ELECTRIC)
                baseBikes = baseBikes.Where(x => x.Category == "electric").Select(x =>
                {
                    ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(x.BikeId);
                    return new ElectricBike(x, electricBike);
                });
            return baseBikes.ToList();
        }

        /// <summary>
        /// Filters a list bike in the station base on bike category
        /// </summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<BaseBike> GetListBikesInStation(int stationId)
        {
            IEnumerable<BaseBike> baseBikes = connecter.SqlData.BaseBikes.Where(x => x.StationId == stationId);
            return baseBikes.ToList();
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="update">The update information</param>
        /// <returns>The bike information after updated</returns>
        public BaseBike UpdateBike(int bikeId, UpdateBikeInfo update)
        {
            BaseBike bike = connecter.SqlData.BaseBikes.Find(bikeId);
            bike.UpdateBike(update);
            int check = connecter.SqlData.SaveChanges();
            bike = connecter.SqlData.BaseBikes.Find(bikeId);
            if (check > 0) return bike;
            return null;
        }
    }
}
