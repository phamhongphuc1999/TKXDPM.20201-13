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
using static RentalBikeApp.Program;

namespace RentalBikeApp.Data.ServiceAgents
{
    public class ElectricBikeService
    {
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
    }
}
