﻿// --------------------RENTAL BIKE APP-----------------
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
using System.Linq;
using System.Collections.Generic;

namespace RentalBikeApp.Data.ServiceAgents.BikeServices
{
    /// <summary>
    /// Provides functions to interact with bike in the database
    /// </summary>
    public class BikeService: IBikeService<Bike>
    {
        private SQLConnecter connecter;

        public BikeService(SQLConnecter connecter)
        {
            this.connecter = connecter;
        }

        /// <summary>Get bike by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public Bike GetBikeByQRCode(string QRCode)
        {
            return connecter.SqlData.Bikes.SingleOrDefault(x => x.QRCode == QRCode);
        }

        /// <summary>Get bike by bike's id</summary>
        /// <param name="id">the bike's id you want to find</param>
        /// <returns>Return the bike with specified ID or null if not found</returns>
        public Bike GetBikeById(int id)
        {
            return connecter.SqlData.Bikes.Find(id);
        }

        /// <summary>Filters a list bike in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<Bike> GetListBikesInStation(int stationId)
        {
            List<Bike> bikesList = connecter.SqlData.Bikes.Where(x => x.StationId == stationId).ToList();
            return bikesList;
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="update">The update information</param>
        /// <returns>The bike information after updated</returns>
        public Bike UpdateBike(int bikeId, UpdateBikeInfo update)
        {
            Bike bike = connecter.SqlData.Bikes.Find(bikeId);
            if (update.StationId > 0) bike.StationId = update.StationId;
            if (update.Value > 0) bike.Value = update.Value;
            if (update.QRCode != null) bike.QRCode = update.QRCode;
            if (update.Manufacturer != null) bike.Manufacturer = update.Manufacturer;
            if (update.BikeStatus > 0) bike.BikeStatus = true;
            if (update.BikeStatus < 0) bike.BikeStatus = false;
            int check = connecter.SqlData.SaveChanges();
            bike = connecter.SqlData.Bikes.Find(bikeId);
            if (check > 0) return bike;
            return null;
        }
    }
}
