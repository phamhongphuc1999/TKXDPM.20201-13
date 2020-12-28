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
using System.Linq;

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provides functions to interact with electric bike in the database
    /// </summary>
    public class ElectricBikeService: BaseService, IBikeService<ElectricBike>
    {
        /// <summary>
        /// contructor of ElectricBikeService
        /// </summary>
        /// <param name="connecter">The instance representing connection to database</param>
        public ElectricBikeService(SQLConnecter connecter): base(connecter) { }

        /// <summary>Get bike by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public ElectricBike GetBikeByQRCode(string QRCode)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.SingleOrDefault(x => x.QRCode == QRCode);
            ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(baseBike.BikeId);
            return new ElectricBike(baseBike, electricBike);
        }

        /// <summary>Get bike by bike's id</summary>
        /// <param name="id">the bike's id you want to find</param>
        /// <returns>Return the bike with specified ID or null if not found</returns>
        public ElectricBike GetBikeById(int id)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.Find(id);
            ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(baseBike.BikeId);
            return new ElectricBike(baseBike, electricBike);
        }

        /// <summary>Filters a list bike in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<ElectricBike> GetListBikesInStation(int stationId)
        {
            IEnumerable<BaseBike> baseBike = connecter.SqlData.BaseBikes.Where(x => x.Category == "electric");
            List<ElectricBike> electricBikes = baseBike.Select(x =>
            {
                ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(x.BikeId);
                return new ElectricBike(x, electricBike);
            }).ToList();
            return electricBikes;
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="update">The update information</param>
        /// <param name="isUpdateDate">if isUpdateDate is true, the RentDate will be updated or not if isUpdateDate is false</param>
        /// <returns>The bike information after updated</returns>
        public ElectricBike UpdateBike(int bikeId, UpdateBikeInfo update, bool isUpdateDate = false)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.Find(bikeId);
            baseBike.UpdateBike(update, isUpdateDate);
            int check = connecter.SqlData.SaveChanges();
            baseBike = connecter.SqlData.BaseBikes.Find(bikeId);
            ElectricBikeTable electricBike = connecter.SqlData.ElectricBikes.Find(baseBike.BikeId);
            if (check > 0) new ElectricBike(baseBike, electricBike);
            return null;
        }
    }
}
