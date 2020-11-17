using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;
using System.Linq;

namespace RentalBikeApp.Business.SQLServices
{
    public class UserService
    {
        private SQLConnecter connecter;

        public UserService()
        {
            connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
        }

        /// <summary>
        /// Insert new user in database
        /// </summary>
        /// <param name="newUser">user information to create new user</param>
        /// <returns>The User represent for new user</returns>
        public User InsertNewUser(User newUser)
        {
            User checkUser = connecter.SqlData.Users.SingleOrDefault(x => x.AccountName == newUser.AccountName);
            if (checkUser != null) return null;
            User user = new User()
            {
                CardId = newUser.CardId,
                UserName = newUser.UserName,
                AccountPassword = newUser.AccountPassword,
                AccountName = newUser.AccountName,
                CusAddress = newUser.CusAddress,
                Email = newUser.Email,
                Phone = newUser.Phone,
                Gender = newUser.Gender,
                AccountStatus = "enable"
            };
            connecter.SqlData.Users.Add(user);
            int check = connecter.SqlData.SaveChanges();
            if (check > 0) return user;
            else return null;
        }
    }
}
