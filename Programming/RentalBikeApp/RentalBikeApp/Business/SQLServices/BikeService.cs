using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;
using System.Linq;
using System.Collections.Generic;

namespace RentalBikeApp.Business.SQLServices
{
    public class BikeService
    {
        private SQLConnecter connecter;

        public BikeService()
        {
            connecter = new SQLConnecter();
        }

        /// <summary>Get bike by QR code</summary>
        /// <param name="QRCode">QR Code you want to find</param>
        /// <returns>Return the bike with specified QR Code or null if not found</returns>
        public Bike GetBikeByQRCode(string QRCode)
        {
            Bike bike = connecter.SqlData.Bikes.SingleOrDefault(x => x.QRCode == QRCode);
            return bike;
        }

        /// <summary>Filters a list bike in the station base on bike category</summary>
        /// <param name="stationId">The station you want to filter list of bike</param>
        /// <param name="bikeCategory">the bike category you want to filter</param>
        /// <returns>Return the list base on bike category</returns>
        public List<Bike> GetListBikesInStation(int stationId, Config.SQL.BikeCategory bikeCategory = Config.SQL.BikeCategory.ALL)
        {
            List<Bike> bikesList = connecter.SqlData.Bikes.Where(x => x.StationId == stationId).ToList();
            if (bikeCategory == Config.SQL.BikeCategory.ALL) return bikesList;
            else if (bikeCategory == Config.SQL.BikeCategory.BIKE)
                return bikesList.Where(x => x.Category == "bike").ToList();
            else if (bikeCategory == Config.SQL.BikeCategory.ELECTRIC)
                return bikesList.Where(x => x.Category == "electric").ToList();
            else return bikesList.Where(x => x.Category == "tandem").ToList();
        }
    }
}
