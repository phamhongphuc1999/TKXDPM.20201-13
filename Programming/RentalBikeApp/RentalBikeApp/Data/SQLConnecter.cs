using Microsoft.EntityFrameworkCore;
using RentalBikeApp.Entities.SQLEntities;

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

        public SQLData SqlData
        {
            get { return sqlData; }
        }

        public DbContextOptionsBuilder<SQLData> Option
        {
            get { return option; }
        }

        public SQLData SqlData1 { get => sqlData; set => sqlData = value; }
        public DbContextOptionsBuilder<SQLData> Option1 { get => option; set => option = value; }
    }
}
