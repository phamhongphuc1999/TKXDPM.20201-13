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
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Linq;

namespace RentalBikeApp.Bussiness
{
    /// <summary>
    /// Provider flow for return bike
    /// </summary>
    public class ReturnBikeController
    {
        private BikeService bikeService;
        private TandemService tandemService;
        private ElectricBikeService electricBikeService;
        private StationService stationService;
        private TransactionService transactionService;

        /// <summary>
        /// contructor of ReturnBikeController
        /// </summary>
        public ReturnBikeController()
        {
            bikeService = new BikeService(SQLConnecter.GetInstance());
            tandemService = new TandemService(SQLConnecter.GetInstance());
            electricBikeService = new ElectricBikeService(SQLConnecter.GetInstance());
            stationService = new StationService(SQLConnecter.GetInstance());
            transactionService = new TransactionService(SQLConnecter.GetInstance());
        }

        /// <summary>
        /// Check availability position in station
        /// </summary>
        /// <param name="stationId">The station id</param>
        /// <returns>true if exist availiability position or false if not</returns>
        public bool CheckStation(int stationId)
        {
            Station station = stationService.GetStationById(stationId);
            int bikes = bikeService.GetListBikesInStation(stationId).Where(x => !x.BikeStatus).ToList().Count;
            int tandems = tandemService.GetListBikesInStation(stationId).Where(x => !x.BikeStatus).ToList().Count;
            int electrics = electricBikeService.GetListBikesInStation(stationId).Where(x => !x.BikeStatus).ToList().Count;
            return station.NumberOfBike > (bikes + electrics + tandems);
        }

        /// <summary>
        /// Update bike status after rent bike
        /// </summary>
        /// <param name="stationId">The return station</param>
        /// <param name="bikeId">id of rental bike</param>
        /// <param name="category">The type of bike</param>
        /// <returns></returns>
        public void UpdateStationAfterReturnbike(int stationId, int bikeId, Constant.SQL.BikeCategory category)
        {
            if (category == Constant.SQL.BikeCategory.BIKE) bikeService.UpdateBike(bikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 }, true);
            else if (category == Constant.SQL.BikeCategory.ELECTRIC) electricBikeService.UpdateBike(bikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 }, true);
            else tandemService.UpdateBike(bikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 }, true);
        }

        /// <summary>
        /// Update transaction when user end of rent bike
        /// </summary>
        /// <param name="transactionId">The trasction id</param>
        /// <param name="rentalMoney">The reantal money</param>
        /// <param name="content">The transaction content</param>
        /// <returns></returns>
        public Transaction UpdatePaymentTransaction(int transactionId, int rentalMoney, string content = "")
        {
            bool check = transactionService.UpdateTransaction(transactionId, rentalMoney, DateTime.Now, content);
            if (!check) return null;
            Transaction transaction = transactionService.GetTransactionById(transactionId);
            return transaction;
        }
    }
}
