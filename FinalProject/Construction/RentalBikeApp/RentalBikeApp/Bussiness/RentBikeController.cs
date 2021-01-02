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

using System;
using RentalBikeApp.Data;
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Entities.SQLEntities;
using static RentalBikeApp.Constant;
using static RentalBikeApp.Program;

namespace RentalBikeApp.Bussiness
{
    /// <summary>
    /// Provider flow for rent bike 
    /// </summary>
    public class RentBikeController
    {
        private BaseBikeService bikeService;
        private StationService stationService;
        private CardService cardService;
        private TransactionService transactionService;

        /// <summary>
        /// contructor of RentBikeController
        /// </summary>
        public RentBikeController()
        {
            bikeService = new BaseBikeService(SQLConnecter.GetInstance());
            stationService = new StationService(SQLConnecter.GetInstance());
            cardService = new CardService(SQLConnecter.GetInstance());
            transactionService = new TransactionService(SQLConnecter.GetInstance());
        }

        /// <summary>
        /// Calculate rental fee for rental bike
        /// </summary>
        /// <param name="timeRent">The time that the user has rented the car</param>
        /// <param name="category">The category of rental bike</param>
        /// <returns>The rental money that use must rent</returns>
        public int CalculateFee(string timeRent, BikeCategory category)
        {
            string[] times = timeRent.Split(':');
            double hour = Int64.Parse(times[0]);
            double minute = Int64.Parse(times[1]);
            double second = Int64.Parse(times[2]);
            double timeMinutes = 60 * hour + minute + Math.Abs(second / 60) - 10;
            if (category != BikeCategory.BIKE) timeMinutes = 1.5 * timeMinutes;
            if (timeMinutes <= 0) return 0;
            timeMinutes -= 30;
            if (timeMinutes <= 0) return 10000;
            return (int)(10000 + Math.Abs(timeMinutes / 15));
        }

        /// <summary>
        /// Get bike by qrcode and save name and address of station contain this bike
        /// </summary>
        /// <param name="qrCode">The qr code to get bike</param>
        /// <param name="stationName">The string save name of station</param>
        /// <param name="stationAddress">The string save address of station</param>
        /// <returns>The BaseBike representing the bike has qr code</returns>
        public BaseBike SubmitQrCode(string qrCode, ref string stationName, ref string stationAddress)
        {
            BaseBike bike = bikeService.GetBikeByQRCode(qrCode);
            if (bike == null) return null;
            Station station = stationService.GetStationById(bike.StationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return bike;
        }

        /// <summary>
        /// Get card information
        /// </summary>
        /// <param name="owner">The card owner</param>
        /// <returns>The Card contain card information</returns>
        public Card GetCardInformation(string owner)
        {
            Card card = cardService.GetCardByOwner(owner);
            return card;
        }

        /// <summary>
        /// Create new transaction to save deposit transaction
        /// </summary>
        /// <param name="userId">The id of user</param>
        /// <param name="bikeId">The id of rental bike</param>
        /// <param name="deposit">The deposit of rental bike</param>
        /// <returns>The new transaction</returns>
        public Transaction CreateDepositTransaction(int userId, int bikeId, int deposit)
        {
            Transaction transaction = transactionService.InsertNewTransaction(userId, bikeId, deposit);
            return transaction;
        }

        /// <summary>
        /// Start renting bike
        /// </summary>
        /// <param name="bikeId">bike id</param>
        public void BeginRentingBike(int bikeId)
        {
            rentingBikeForm.StartTimer();
            bikeService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1 });
        }

        /// <summary>
        /// get begin rent bike
        /// </summary>
        /// <param name="bikeId">bike id</param>
        /// <returns>The begin date</returns>
        public DateTime GetBeginDate(int bikeId)
        {
            Transaction transaction = transactionService.GetProcessTransaction(bikeId);
            return transaction.BeginAt;
        }
    }
}
