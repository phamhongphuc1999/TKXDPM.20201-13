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
    /// Provides functions to interact with tandem in the database
    /// </summary>
    public class TandemService: BaseService, IBikeService<Tandem>
    {
        /// <summary>
        /// contructor of TandemService
        /// </summary>
        /// <param name="connecter">The connecter</param>
        public TandemService(SQLConnecter connecter): base(connecter) { }

        /// <summary>Get tandem by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public Tandem GetBikeByQRCode(string QRCode)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.SingleOrDefault(x => x.QRCode == QRCode);
            return new Tandem(baseBike);
        }

        /// <summary>Get tandem by tandem's id</summary>
        /// <param name="id">the bike's id you want to find</param>
        /// <returns>Return the bike with specified ID or null if not found</returns>
        public Tandem GetBikeById(int id)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.Find(id);
            return new Tandem(baseBike);
        }

        /// <summary>Filters a list tandem in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <returns>Return the list base on bike category</returns>
        public List<Tandem> GetListBikesInStation(int stationId)
        {
            IEnumerable<BaseBike> bikesList = connecter.SqlData.BaseBikes.Where(x => x.Category == "tandem");
            List<Tandem> tandems = bikesList.Select(x => new Tandem(x)).ToList();
            return tandems;
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="update">The update information</param>
        /// <param name="isUpdateDate">if isUpdateDate is true, the RentDate will be updated or not if isUpdateDate is false</param>
        /// <returns>The bike information after updated</returns>
        public Tandem UpdateBike(int bikeId, UpdateBikeInfo update, bool isUpdateDate = false)
        {
            BaseBike baseBike = connecter.SqlData.BaseBikes.Find(bikeId);
            baseBike.UpdateBike(update, isUpdateDate);
            int check = connecter.SqlData.SaveChanges();
            baseBike = connecter.SqlData.BaseBikes.Find(bikeId);
            if (check > 0) new Tandem(baseBike);
            return null;
        }
    }
}
