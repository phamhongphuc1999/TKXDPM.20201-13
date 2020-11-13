using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Linq;

namespace RentalBikeApp.Business.SQLServices
{
    public class StationService: SQLConnecter
    {
        public StationService(): base() { }

        /// <summary>get list stations</summary>
        /// <returns>the list of station</returns>
        public List<Station> GetListStations()
        {
            return SqlData.Stations.ToList();
        }

        /// <summary>Get station base on it's id</summary>
        /// <param name="stationId">the station id you want to find</param>
        /// <returns>the specified station</returns>
        public Station GetStationById(int stationId)
        {
            return SqlData.Stations.Find(stationId);
        }

        /// <summary></summary>
        /// <param name="nameStation"></param>
        /// <returns></returns>
        public Station GetStationByName(string nameStation)
        {
            return SqlData.Stations.SingleOrDefault(x => x.NameStation == nameStation);
        }
    }
}
