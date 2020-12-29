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
        private BaseBikeService bikeService;
        private StationService stationService;
        private TransactionService transactionService;

        /// <summary>
        /// contructor of ReturnBikeController
        /// </summary>
        public ReturnBikeController()
        {
            bikeService = new BaseBikeService(SQLConnecter.GetInstance());
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
            return station.NumberOfBike > bikes;
        }

        /// <summary>
        /// Update bike status after rent bike
        /// </summary>
        /// <param name="stationId">The return station</param>
        /// <param name="bikeId">id of rental bike</param>
        /// <returns></returns>
        public void UpdateStationAfterReturnbike(int stationId, int bikeId)
        {
            bikeService.UpdateBike(bikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 }, true);
        }

        /// <summary>
        /// Update transaction when user end of rent bike
        /// </summary>
        /// <param name="bikeId">The rental bike id</param>
        /// <param name="rentalMoney">The reantal money</param>
        /// <param name="content">The transaction content</param>
        /// <returns></returns>
        public Transaction UpdatePaymentTransaction(int bikeId, int rentalMoney, string content = "")
        {
            Transaction transaction = transactionService.GetProcessTransaction(bikeId);
            bool check = transactionService.UpdateTransaction(transaction.TransactionId, rentalMoney, DateTime.Now, content);
            if (!check) return null;
            transaction = transactionService.GetTransactionById(transaction.TransactionId);
            return transaction;
        }
    }
}
