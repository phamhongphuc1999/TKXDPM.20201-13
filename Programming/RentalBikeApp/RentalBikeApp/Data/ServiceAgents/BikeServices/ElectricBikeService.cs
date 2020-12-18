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
    public class ElectricBikeService: IBikeService<ElectricBike>
    {
        private SQLConnecter connecter;

        public ElectricBikeService(SQLConnecter connecter)
        {
            this.connecter = connecter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        public ElectricBike GetBikeByQRCode(string QRCode)
        {
            return connecter.SqlData.ElectricBikes.SingleOrDefault(x => x.QRCode == QRCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ElectricBike GetBikeById(int id)
        {
            return connecter.SqlData.ElectricBikes.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public List<ElectricBike> GetListBikesInStation(int stationId)
        {
            List<ElectricBike> bikesList = connecter.SqlData.ElectricBikes.Where(x => x.StationId == stationId).ToList();
            return bikesList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bikeId"></param>
        /// <param name="update"></param>
        /// <returns></returns>
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
