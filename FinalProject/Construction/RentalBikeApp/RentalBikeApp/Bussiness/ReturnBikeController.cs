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
using RentalBikeApp.Data.ServiceAgents.BikeServices;
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
        /// Calculate rental fee for rental bike
        /// </summary>
        /// <param name="timeRent">The time that the user has rented the car</param>
        /// <param name="category">The category of rental bike</param>
        /// <returns>The rental money that use must rent</returns>
        public int CalculateFee(string timeRent, Config.SQL.BikeCategory category)
        {
            string[] times = timeRent.Split(':');
            double hour = Int64.Parse(times[0]);
            double minute = Int64.Parse(times[1]);
            double second = Int64.Parse(times[2]);
            double timeMinutes = 60 * hour + minute + Math.Abs(second / 60) - 10;
            if (category != Config.SQL.BikeCategory.BIKE) timeMinutes = 1.5 * timeMinutes;
            if (timeMinutes <= 0) return 0;
            timeMinutes -= 30;
            if (timeMinutes <= 0) return 10000;
            return (int)(10000 + Math.Abs(timeMinutes / 15));
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
            if (station.NumberOfBike > (bikes + electrics + tandems)) return true;
            return false;
        }

        /// <summary>
        /// Update bike status after rent bike
        /// </summary>
        /// <param name="stationId">The return station</param>
        /// <param name="category">The type of bike</param>
        /// <returns></returns>
        public void UpdateStationAfterReturnbike(int stationId, Config.SQL.BikeCategory category)
        {
            if (category == Config.SQL.BikeCategory.BIKE) bikeService.UpdateBike(Config.RENTAL_BIKE.BikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 });
            else if (category == Config.SQL.BikeCategory.ELECTRIC) electricBikeService.UpdateBike(Config.RENTAL_BIKE.BikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 });
            else tandemService.UpdateBike(Config.RENTAL_BIKE.BikeId, new UpdateBikeInfo { StationId = stationId, BikeStatus = -1 });
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
