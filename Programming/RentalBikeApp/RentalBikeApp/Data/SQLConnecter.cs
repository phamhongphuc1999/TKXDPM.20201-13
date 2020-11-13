using Microsoft.EntityFrameworkCore;
using RentalBikeApp.Entities;

namespace RentalBikeApp.Data
{
    public class SQLConnecter
    {
        private SQLData sqlData;
        private DbContextOptionsBuilder<SQLData> option;

        public SQLConnecter()
        {
            option = new DbContextOptionsBuilder<SQLData>();
            option.UseSqlServer(Config.SQL.SQL_CONNECT_STRING);
            sqlData = new SQLData(option.Options);
        }
    }
}
