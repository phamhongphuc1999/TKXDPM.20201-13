using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Business.SQLServices
{
    public class CardService
    {
        private SQLConnecter connecter;

        public CardService()
        {
            connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
        }

        /// <summary>
        /// Get card information by owner
        /// </summary>
        /// <param name="ownerId">the owner's id</param>
        /// <returns>The instance represent by card</returns>
        public Card GetCardByOwner(int ownerId)
        {
            User owner = connecter.SqlData.Users.Find(ownerId);
            return connecter.SqlData.Cards.Find(owner.CardId);
        }
    }
}
