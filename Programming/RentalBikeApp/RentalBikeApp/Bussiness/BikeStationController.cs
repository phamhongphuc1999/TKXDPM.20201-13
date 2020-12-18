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
using System.Linq;

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
        /// <returns>The BaseBike representing the bike you want to get</returns>
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
        /// <param name="bikeId">The bike id you want to get information</param>
        /// <param name="category">The bike type</param>
        /// <param name="stationName">Representing station name contain the bike</param>
        /// <param name="stationAddress">Repensting station address contain the bike</param>
        /// <returns>The BaseBike representing the bike you want to get</returns>
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

        /// <summary>
        /// Get bike information
        /// </summary>
        /// <param name="bikeId">The bike id you want to get information</param>
        /// <param name="category">The bike type</param>
        /// <returns>The BaseBike representing the bike you want to get</returns>
        public BaseBike ViewBikeDetail(int bikeId, BikeCategory category)
        {
            BaseBike bike = null;
            if (category == BikeCategory.BIKE) bike = bikeService.GetBikeById(bikeId);
            else if (category == BikeCategory.ELECTRIC) bike = electricBikeService.GetBikeById(bikeId);
            else if (category == BikeCategory.TANDEM) bike = tandemService.GetBikeById(bikeId);
            return bike;
        }

        /// <summary>
        /// Get list bike in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <param name="stationName">Representing station name contain the bike</param>
        /// <param name="stationAddress">Repensting station address contain the bike</param>
        /// <returns>The list bike</returns>
        public List<Bike> ViewListBikeInStation(int stationId, ref string stationName, ref string stationAddress)
        {
            Station station = stationService.GetStationById(stationId);
            List<Bike> bikes = bikeService.GetListBikesInStation(stationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return bikes.Where(x => !x.BikeStatus).ToList();
        }

        /// <summary>
        /// Get list electric bike in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <param name="stationName">Representing station name contain the bike</param>
        /// <param name="stationAddress">Repensting station address contain the bike</param>
        /// <returns>The list electric bike</returns>
        public List<ElectricBike> ViewListElectricBikeInStation(int stationId, ref string stationName, ref string stationAddress)
        {
            Station station = stationService.GetStationById(stationId);
            List<ElectricBike> electricBikes = electricBikeService.GetListBikesInStation(stationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return electricBikes.Where(x => !x.BikeStatus).ToList();
        }

        /// <summary>
        /// Get tandem in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <param name="stationName">Representing station name contain the bike</param>
        /// <param name="stationAddress">Repensting station address contain the bike</param>
        /// <returns>The list tandem</returns>
        public List<Tandem> ViewListTandemInStation(int stationId, ref string stationName, ref string stationAddress)
        {
            Station station = stationService.GetStationById(stationId);
            List<Tandem> tandems = tandemService.GetListBikesInStation(stationId);
            stationName = station.NameStation;
            stationAddress = station.AddressStation;
            return tandems.Where(x => !x.BikeStatus).ToList();
        }

        /// <summary>
        /// Get specified station information
        /// </summary>
        /// <param name="stationId">The station id you want to get</param>
        /// <returns>The station</returns>
        public Station ViewStationDetail(int stationId)
        {
            return stationService.GetStationById(stationId);
        }

        /// <summary>
        /// Get all of station in database
        /// </summary>
        /// <returns>The list stations</returns>
        public List<Station> ViewListStation()
        {
            List<Station> stations = stationService.GetListStations();
            return stations;
        }
    }
}
