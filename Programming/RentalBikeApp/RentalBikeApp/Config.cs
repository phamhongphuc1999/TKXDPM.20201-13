using System;

namespace RentalBikeApp
{
    public static class Config
    {
        public static class SQL
        {
            private const string USERNAME = "sa";
            private const string PASSWORD = "phamhongphuc";

            public static string SQL_CONNECT_STRING = String.Format("data source=DESKTOP-TM16V8B\\SQLEXPRESS;initial catalog=VegeFood;user id={0};password={1};MultipleActiveResultSets=True;", USERNAME, PASSWORD);
        }
    }
}
