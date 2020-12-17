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
        /// 
        /// </summary>
        /// <param name="qrCode"></param>
        /// <returns></returns>
        public BaseBike SubmitQrCode(string qrCode)
        {
            if (qrCode[0] == '0') return bikeService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '1') return tandemService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '2') return electricBikeService.GetBikeByQRCode(qrCode);
            else return null;
        }

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

        public bool BeginRentingBike()
        {
            rentBikeForm.rentBikeTmr.Start();
            Station station = stationService.GetStationById(Config.RENTAL_BIKE.StationId);
            return stationService.UpdateNumberBike(Config.RENTAL_BIKE.StationId, station.NumberOfBike - 1);
        }
    }
}
