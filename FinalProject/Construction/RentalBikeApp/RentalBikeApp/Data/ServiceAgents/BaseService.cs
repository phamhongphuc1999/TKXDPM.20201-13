namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provider function to interact tables in database
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// the instance representing connection to database
        /// </summary>
        protected SQLConnecter connecter;

        /// <summary>
        /// contructor of BaseService
        /// </summary>
        /// <param name="connecter">the instance representing connection to database</param>
        public BaseService(SQLConnecter connecter)
        {
            this.connecter = connecter;
        }
    }
}
