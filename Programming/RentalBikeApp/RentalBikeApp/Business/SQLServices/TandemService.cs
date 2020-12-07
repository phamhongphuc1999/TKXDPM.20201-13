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
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Linq;

namespace RentalBikeApp.Business.SQLServices
{
    public class TandemService
    {
        private SQLConnecter connecter;

        public TandemService()
        {
            connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
        }

        public Tandem GetBikeByQRCode(string QRCode)
        {
            return connecter.SqlData.Tandems.SingleOrDefault(x => x.QRCode == QRCode);
        }

        public Tandem GetBikeById(int id)
        {
            return connecter.SqlData.Tandems.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public List<Tandem> GetListBikesInStation(int stationId)
        {
            List<Tandem> bikesList = connecter.SqlData.Tandems.Where(x => x.StationId == stationId).ToList();
            return bikesList;
        }
    }
}
