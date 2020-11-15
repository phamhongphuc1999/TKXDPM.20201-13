using RentalBikeApp.Entities.SQLEntities;
using System;

namespace RentalBikeApp
{
    public static class Config
    {
        public static class SQL
        {
            private const string SOURCE = "DESKTOP-TM16V8B\\SQLEXPRESS";
            private const string NAME_DATABASE = "RentalBike";
            private const string USERNAME = "sa";
            private const string PASSWORD = "phamhongphuc";
            private static string _SQL_CONNECT_STRING = String.Format("data source={0};initial catalog={1};user id={2};password={3};MultipleActiveResultSets=True;", SOURCE, NAME_DATABASE, USERNAME, PASSWORD);

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
    }
}
