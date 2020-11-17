using Microsoft.EntityFrameworkCore;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Data
{
    public class SQLConnecter
    {
        private SQLData sqlData;
        private DbContextOptionsBuilder<SQLData> option;

        public SQLConnecter(string CONNECT_STRING)
        {
            option = new DbContextOptionsBuilder<SQLData>();
            option.UseSqlServer(CONNECT_STRING);
            sqlData = new SQLData(option.Options);
        }

        public SQLData SqlData
        {
            get { return sqlData; }
        }

        public DbContextOptionsBuilder<SQLData> Option
        {
            get { return option; }
        }
    }
}
