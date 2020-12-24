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

namespace RentalBikeApp.Data.ServiceAgents.BikeServices
{
    /// <summary>
    /// Provides functions to interact with electric bike in the database
    /// </summary>
    public class ElectricBikeService: IBikeService<ElectricBike>
    {
        private SQLConnecter connecter;

        /// <summary>
        /// contructor of ElectricBikeService
        /// </summary>
        /// <param name="connecter">The connecter</param>
        public ElectricBikeService(SQLConnecter connecter)
        {
            this.connecter = connecter;
        }

        /// <summary>Get bike by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public ElectricBike GetBikeByQRCode(string QRCode)
        {
            return connecter.SqlData.ElectricBikes.SingleOrDefault(x => x.QRCode == QRCode);
        }

        /// <summary>Get bike by bike's id</summary>
        /// <param name="id">the bike's id you want to find</param>
        /// <returns>Return the bike with specified ID or null if not found</returns>
        public ElectricBike GetBikeById(int id)
        {
            return connecter.SqlData.ElectricBikes.Find(id);
        }

        /// <summary>Filters a list bike in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<ElectricBike> GetListBikesInStation(int stationId)
        {
            List<ElectricBike> bikesList = connecter.SqlData.ElectricBikes.Where(x => x.StationId == stationId).ToList();
            return bikesList;
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="update">The update information</param>
        /// <returns>The bike information after updated</returns>
        public ElectricBike UpdateBike(int bikeId, UpdateBikeInfo update)
        {
            ElectricBike bike = connecter.SqlData.ElectricBikes.Find(bikeId);
            if (update.StationId > 0) bike.StationId = update.StationId;
            if (update.Value > 0) bike.Value = update.Value;
            if (update.QRCode != null) bike.QRCode = update.QRCode;
            if (update.Manufacturer != null) bike.Manufacturer = update.Manufacturer;
            if (update.BikeStatus > 0) bike.BikeStatus = true;
            if (update.BikeStatus < 0) bike.BikeStatus = false;
            int check = connecter.SqlData.SaveChanges();
            bike = connecter.SqlData.ElectricBikes.Find(bikeId);
            if (check > 0) return bike;
            return null;
        }
    }
}
