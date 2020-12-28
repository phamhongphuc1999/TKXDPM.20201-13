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
using static RentalBikeApp.Program;
using static RentalBikeApp.Constant.SQL;

namespace RentalBikeApp.Bussiness
{
    /// <summary>
    /// Provider flow for rent bike 
    /// </summary>
    public class RentBikeController
    {
        private BikeService bikeService;
        private TandemService tandemService;
        private ElectricBikeService electricBikeService;
        private StationService stationService;
        private CardService cardService;
        private TransactionService transactionService;

        /// <summary>
        /// contructor of RentBikeController
        /// </summary>
        public RentBikeController()
        {
            bikeService = new BikeService(SQLConnecter.GetInstance());
            tandemService = new TandemService(SQLConnecter.GetInstance());
            electricBikeService = new ElectricBikeService(SQLConnecter.GetInstance());
            stationService = new StationService(SQLConnecter.GetInstance());
            cardService = new CardService(SQLConnecter.GetInstance());
            transactionService = new TransactionService(SQLConnecter.GetInstance());
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
            BaseBike bike = null;
            if (qrCode[0] == '0') bike = bikeService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '1') bike = tandemService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '2') bike = electricBikeService.GetBikeByQRCode(qrCode);
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
        /// <param name="category">the bike category</param>
        public void BeginRentingBike(int bikeId, BikeCategory category)
        {
            rentBikeForm.StartTimer();
            if (category == BikeCategory.BIKE) bikeService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1, DateRent = DateTime.Now }, true);
            else if (category == BikeCategory.ELECTRIC) electricBikeService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1, DateRent = DateTime.Now }, true);
            else tandemService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1, DateRent = DateTime.Now }, true);
        }
    }
}
