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
using System.Collections.Generic;
using System.Linq;
using static RentalBikeApp.Program;

namespace RentalBikeApp.Business.SQLServices
{
    public class StationService
    {
        /// <summary>get list stations</summary>
        /// <returns>the list of station</returns>
        public List<Station> GetListStations()
        {
            return connecter.SqlData.Stations.ToList();
        }

        /// <summary>Get station base on it's id</summary>
        /// <param name="stationId">the station id you want to find</param>
        /// <returns>the specified station</returns>
        public Station GetStationById(int stationId)
        {
            return connecter.SqlData.Stations.Find(stationId);
        }

        /// <summary></summary>
        /// <param name="nameStation"></param>
        /// <returns></returns>
        public Station GetStationByName(string nameStation)
        {
            return connecter.SqlData.Stations.SingleOrDefault(x => x.NameStation == nameStation);
        }
    }
}
