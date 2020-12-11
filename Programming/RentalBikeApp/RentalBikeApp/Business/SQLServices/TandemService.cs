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

namespace RentalBikeApp.Business.SQLServices
{
    public class TandemService
    {
        /// <summary>Get tandem by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public Tandem GetBikeByQRCode(string QRCode)
        {
            return connecter.SqlData.Tandems.SingleOrDefault(x => x.QRCode == QRCode);
        }

        /// <summary>Get tandem by tandem's id</summary>
        /// <param name="id">the bike's id you want to find</param>
        /// <returns>Return the bike with specified ID or null if not found</returns>
        public Tandem GetBikeById(int id)
        {
            return connecter.SqlData.Tandems.Find(id);
        }

        /// <summary>Filters a list tandem in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<Tandem> GetListBikesInStation(int stationId)
        {
            List<Tandem> bikesList = connecter.SqlData.Tandems.Where(x => x.StationId == stationId).ToList();
            return bikesList;
        }
    }
}
