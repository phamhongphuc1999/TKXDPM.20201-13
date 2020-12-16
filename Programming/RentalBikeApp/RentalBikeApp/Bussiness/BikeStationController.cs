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
using static RentalBikeApp.Config.SQL;

namespace RentalBikeApp.Bussiness
{
    public class BikeStationController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qrcode"></param>
        /// <param name="stationName"></param>
        /// <param name="stationAddress"></param>
        /// <returns></returns>
        public BaseBike ViewBikeDetail(string qrcode, ref string stationName, ref string stationAddress)
        {
            BaseBike bike = null;
            if (qrcode[0] == '0') bike = bikeService.GetBikeByQRCode(qrcode);
            else if (qrcode[0] == '1') bike = tandemService.GetBikeByQRCode(qrcode);
            else if (qrcode[0] == '2') bike = electricBikeService.GetBikeByQRCode(qrcode);
            if (bike == null) return null;
            Station station = stationService.GetStationById(bike.StationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return bike;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bikeId"></param>
        /// <param name="category"></param>
        /// <param name="stationName"></param>
        /// <param name="stationAddress"></param>
        /// <returns></returns>
        public BaseBike ViewBikeDetail(int bikeId, BikeCategory category, ref string stationName, ref string stationAddress)
        {
            BaseBike bike = null;
            if (category == BikeCategory.BIKE) bike = bikeService.GetBikeById(bikeId);
            else if (category == BikeCategory.ELECTRIC) bike = electricBikeService.GetBikeById(bikeId);
            else if (category == BikeCategory.TANDEM) bike = tandemService.GetBikeById(bikeId);
            if (bike == null) return null;
            Station station = stationService.GetStationById(bike.StationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return bike;
        }

        public Station ViewStationDetail(int stationId)
        {
            return stationService.GetStationById(stationId);
        }
    }
}
