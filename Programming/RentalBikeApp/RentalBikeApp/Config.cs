using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp
{
    public static class Config
    {
        //Config for SQL server
        public static class SQL
        {
            //private static string _SQL_CONNECT_STRING = "Data Source=.\\MSSQLSERVER123;Initial Catalog=RentalBike;Integrated Security=True";
            private static string _SQL_CONNECT_STRING = "data source=DESKTOP-TM16V8B\\SQLEXPRESS;initial catalog=RentalBike;user id=sa;password=phamhongphuc;MultipleActiveResultSets=True;";

            public static string SQL_CONNECT_STRING
            {
                get { return _SQL_CONNECT_STRING; }
            }

            public enum BikeCategory
            {
                ELECTRIC,
                TANDEM,
                BIKE,
                ALL
            }
        }

        //Config for API
        public static class API_INFO
        {
            public const string BASE_URL = " https://ecopark-system-api.herokuapp.com";
            public const string PROCESS_URL = "/api/card/processTransaction";
            public const string RESET_URL = "/api/card/reset-balance";

            public static class CARD_INFO
            {
                public const string CARD_CODE = "118609_group13_2020";
                public const string OWER = "Group 13";
                public const string CVV = "474";
                public const string DATE_EXPIRED = "1125";
            }

            public enum COMMAND
            {
                PAY, REFUND
            }

            public static class KEY
            {
                public const string APP_CODE = "Bi3TiyT5q00=";
                public const string SECRET_KEY = "B92s318KCwI=";
            }
        }

        public static Station CURRENT_STATION;

        public enum RENT_BIKE
        {
            RENT_BIKE,
            RENTING_BIKE,
            RENT_BIKE_INFO
        }

        public static RENT_BIKE RENT_BIKE_STATUS;
    }
}
