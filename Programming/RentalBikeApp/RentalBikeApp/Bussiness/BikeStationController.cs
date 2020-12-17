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
using System.Collections.Generic;

namespace RentalBikeApp.Bussiness
{
    public class BikeStationController
    {
        /// <summary>
        /// Get bike information
        /// </summary>
        /// <param name="qrcode">The qrcode you want to get information</param>
        /// <param name="stationName">representing station name contain the bike</param>
        /// <param name="stationAddress">representing station address contain the bike</param>
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
        /// Get bike information
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

        public BaseBike ViewBikeDetail(int bikeId, BikeCategory category)
        {
            BaseBike bike = null;
            if (category == BikeCategory.BIKE) bike = bikeService.GetBikeById(bikeId);
            else if (category == BikeCategory.ELECTRIC) bike = electricBikeService.GetBikeById(bikeId);
            else if (category == BikeCategory.TANDEM) bike = tandemService.GetBikeById(bikeId);
            return bike;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="stationName"></param>
        /// <param name="stationAddress"></param>
        /// <returns></returns>
        public List<Bike> ViewListBikeInStation(int stationId, ref string stationName, ref string stationAddress)
        {
            Station station = stationService.GetStationById(stationId);
            List<Bike> bikes = bikeService.GetListBikesInStation(stationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return bikes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="stationName"></param>
        /// <param name="stationAddress"></param>
        /// <returns></returns>
        public List<ElectricBike> ViewListElectricBikeInStation(int stationId, ref string stationName, ref string stationAddress)
        {
            Station station = stationService.GetStationById(stationId);
            List<ElectricBike> electricBikes = electricBikeService.GetListBikesInStation(stationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return electricBikes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="stationName"></param>
        /// <param name="stationAddress"></param>
        /// <returns></returns>
        public List<Tandem> ViewListTandemInStation(int stationId, ref string stationName, ref string stationAddress)
        {
            Station station = stationService.GetStationById(stationId);
            List<Tandem> tandems = tandemService.GetListBikesInStation(stationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return tandems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public Station ViewStationDetail(int stationId)
        {
            return stationService.GetStationById(stationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Station> ViewListStation()
        {
            List<Station> stations = stationService.GetListStations();
            return stations;
        }
    }
}
