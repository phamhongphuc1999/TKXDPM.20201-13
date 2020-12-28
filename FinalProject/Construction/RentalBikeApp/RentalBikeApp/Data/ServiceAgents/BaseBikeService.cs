using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Linq;

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseBikeService: BaseService, IBikeService<BaseBike>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connecter"></param>
        public BaseBikeService(SQLConnecter connecter) : base(connecter) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseBike GetBikeById(int id)
        {
            return connecter.SqlData.BaseBikes.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qrcode"></param>
        /// <returns></returns>
        public BaseBike GetBikeByQRCode(string qrcode)
        {
            return connecter.SqlData.BaseBikes.SingleOrDefault(x => x.QRCode == qrcode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public List<BaseBike> GetListBikesInStation(int stationId)
        {
            return connecter.SqlData.BaseBikes.Where(x => x.StationId == stationId).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bikeId"></param>
        /// <param name="update"></param>
        /// <param name="isUpdateDate"></param>
        /// <returns></returns>
        public BaseBike UpdateBike(int bikeId, UpdateBikeInfo update, bool isUpdateDate = false)
        {
            BaseBike bike = connecter.SqlData.BaseBikes.Find(bikeId);
            bike.UpdateBike(update, isUpdateDate);
            int check = connecter.SqlData.SaveChanges();
            bike = connecter.SqlData.BaseBikes.Find(bikeId);
            if (check > 0) return bike;
            return null;
        }
    }
}
