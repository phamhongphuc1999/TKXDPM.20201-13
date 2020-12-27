using RentalBikeApp.Data;
using RentalBikeApp.Data.ServiceAgents;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using static RentalBikeApp.Constant.SQL;

namespace RentalBikeApp.Bussiness
{
    /// <summary>
    /// Provider flow for view bike
    /// </summary>
    public class ViewBikeController
    {
        private StationService stationService;
        private BikeService bikeService;
        private TandemService tandemService;
        private ElectricBikeService electricBikeService;

        /// <summary>
        /// Contructor of ViewBikeController
        /// </summary>
        public ViewBikeController()
        {
            stationService = new StationService(SQLConnecter.GetInstance());
            bikeService = new BikeService(SQLConnecter.GetInstance());
            tandemService = new TandemService(SQLConnecter.GetInstance());
            electricBikeService = new ElectricBikeService(SQLConnecter.GetInstance());
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
            if (bike == null) return null;
            return bike;
        }

        /// <summary>
        /// Get list bike in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <returns>The list bike</returns>
        public List<Bike> ViewListBikeInStation(int stationId)
        {
            List<Bike> bikes = bikeService.GetListBikesInStation(stationId);
            return bikes;
        }

        /// <summary>
        /// Get list electric bike in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <returns>The list electric bike</returns>
        public List<ElectricBike> ViewListElectricBikeInStation(int stationId)
        {
            List<ElectricBike> electricBikes = electricBikeService.GetListBikesInStation(stationId);
            return electricBikes;
        }

        /// <summary>
        /// Get tandem in specified station
        /// </summary>
        /// <param name="stationId">The station id you want to get list bike</param>
        /// <returns>The list tandem</returns>
        public List<Tandem> ViewListTandemInStation(int stationId)
        {
            List<Tandem> tandems = tandemService.GetListBikesInStation(stationId);
            return tandems;
        }

        /// <summary>
        /// Get detail information os station
        /// </summary>
        /// <param name="stationId">The station id</param>
        /// <returns>The station information</returns>
        public Station GetDetailStationContainbike(int stationId)
        {
            return stationService.GetStationById(stationId);
        }
    }
}
