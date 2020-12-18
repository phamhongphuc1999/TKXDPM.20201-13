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
using static RentalBikeApp.Program;

namespace RentalBikeApp.Bussiness
{
    public class RentBikeController
    {
        /// <summary>
        /// Get bike by qr code
        /// </summary>
        /// <param name="qrCode">the qrcode to get bike</param>
        /// <returns>The BaseBike representing the bike has qr code</returns>
        public BaseBike SubmitQrCode(string qrCode)
        {
            if (qrCode[0] == '0') return bikeService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '1') return tandemService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '2') return electricBikeService.GetBikeByQRCode(qrCode);
            else return null;
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
            if (card != null) Config.CARD_INFO = card;
            return card;
        }

        /// <summary>
        /// Create new transaction to save deposit transaction
        /// </summary>
        /// <param name="userId">The id of user</param>
        /// <param name="qrcode">The qr code of rental bike</param>
        /// <param name="deposit">The deposit of rental bike</param>
        /// <returns>The new transaction</returns>
        public Transaction CreateDepositTransaction(int userId, string qrcode, int deposit)
        {
            Transaction transaction = transactionService.InsertNewTransaction(userId, qrcode, deposit);
            return transaction;
        }

        /// <summary>
        /// Start renting bike
        /// </summary>
        public void BeginRentingBike(int bikeId)
        {
            rentBikeForm.rentBikeTmr.Start();
            if (Config.RENTAL_BIKE_CATEGORY == Config.SQL.BikeCategory.BIKE) bikeService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1 });
            else if (Config.RENTAL_BIKE_CATEGORY == Config.SQL.BikeCategory.ELECTRIC) electricBikeService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1 });
            else tandemService.UpdateBike(bikeId, new UpdateBikeInfo { BikeStatus = 1 });
        }
    }
}
