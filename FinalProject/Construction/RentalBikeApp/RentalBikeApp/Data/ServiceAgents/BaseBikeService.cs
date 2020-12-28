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
    /// Provides functions to interact with BaseBike table in the database
    /// </summary>
    public class BaseBikeService: BaseService, IBikeService<BaseBike>
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
            return connecter.SqlData.BaseBikes.Find(id);
        }

        /// <summary>Get bike by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public BaseBike GetBikeByQRCode(string QRCode)
        {
            return connecter.SqlData.BaseBikes.SingleOrDefault(x => x.QRCode == QRCode);
        }

        /// <summary>Filters a list bike in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<BaseBike> GetListBikesInStation(int stationId)
        {
            return connecter.SqlData.BaseBikes.Where(x => x.StationId == stationId).ToList();
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="update">The update information</param>
        /// <param name="isUpdateDate">if isUpdateDate is true, the RentDate will be updated or not if isUpdateDate is false</param>
        /// <returns>The bike information after updated</returns>
        public BaseBike UpdateBike(int bikeId, UpdateBikeInfo update, bool isUpdateDate = false)
        {
            BaseBike bike = connecter.SqlData.BaseBikes.Find(bikeId);
            bike.UpdateBike(update, isUpdateDate);
            int check = connecter.SqlData.SaveChanges();
            bike = connecter.SqlData.BaseBikes.Find(bikeId);
            if (check > 0) return bike;
            return null;
        }
    }
}
