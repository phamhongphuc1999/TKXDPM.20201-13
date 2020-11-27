// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System.Collections.Generic;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp
{
    public static class Config
    {
        /// <summary>
        /// This static class use to config connect to sql server
        /// </summary>
        public static class SQL
        {
            //private static string _SQL_CONNECT_STRING = "Data Source=.\\MSSQLSERVER123;Initial Catalog=RentalBike;Integrated Security=True";
            private static string _SQL_CONNECT_STRING = "data source=DESKTOP-TM16V8B\\SQLEXPRESS;initial catalog=RentalBike;user id=sa;password=phamhongphuc;MultipleActiveResultSets=True;";

            ///<value>
            ///get the value of sql server connect string
            ///</value>
            public static string SQL_CONNECT_STRING
            {
                get { return _SQL_CONNECT_STRING; }
            }

            ///<value>
            ///enum define category bike
            ///</value>
            ///<remarks>
            ///ELECTRIC: represent electric bike
            ///TANDEM: represent tandem
            ///BIKE: represent normal bike
            ///</remarks>
            public enum BikeCategory
            {
                ELECTRIC,
                TANDEM,
                BIKE,
                ALL
            }
        }

        /// <summary>
        /// provide the api's information
        /// </summary>
        public static class API_INFO
        {
            /// <value>
            /// get api base url
            /// </value>
            public const string BASE_URL = " https://ecopark-system-api.herokuapp.com";

            /// <value>
            /// get sub api process transaction url
            /// </value>
            public const string PROCESS_URL = "/api/card/processTransaction";

            /// <value>
            /// get sub apj reset balance url
            /// </value>
            public const string RESET_URL = "/api/card/reset-balance";

            ///<value>
            ///enum use to define the command in request when call process transaction API
            ///</value>
            ///<remarks>
            ///PAY: API call to pay rental money
            ///REFUND: API call to refund money
            ///</remarks>
            public enum COMMAND
            {
                PAY, REFUND
            }

            public static Dictionary<string, string> ERROR_CODE = new Dictionary<string, string>()
            {
                {"01", "Thẻ không hợp lệ" },
                {"02", "Thẻ không đủ số dư" },
                {"03", "Internal Server Error" },
                {"04", "Giao dịch bị nghi ngờ gian lận" },
                {"05", "Không đủ thông tin giao dịch" },
                {"06", "Thiếu thông tin version" },
                {"07", "Số tiền không hợp lệ" }
            };

            /// <summary>
            /// This static class provide information of card
            /// </summary>
            public static class CARD_INFO
            {
                /// <value>
                /// get value of card code
                /// </value>
                public const string CARD_CODE = "118609_group13_2020";

                /// <value>
                /// get value of owner card
                /// </value>
                public const string OWER = "Group 13";

                /// <value>
                /// get value of CVV
                /// </value>
                public const string CVV = "474";

                /// <value>
                /// get value of card expiration date
                /// </value>
                public const string DATE_EXPIRED = "1125";
            }

            /// <summary>
            /// this static class provide information of key
            /// </summary>
            public static class KEY
            {
                public const string APP_CODE = "Bi3TiyT5q00=";
                public const string SECRET_KEY = "B92s318KCwI=";
            }
        }

        ///<value>Get current station</value>
        public static Station CURRENT_STATION;

        ///<value>
        /// enum use to define the transaction form status
        ///</value>
        ///<remarks>
        ///REN_BIKE: when the user complete fill card information and press permit button, the transaction form status to RENT_BIKE
        ///PAY: when the user choose a station to return bike, the transaction form status is PAY
        ///</remarks>
        public enum TRANSACTION_STATUS
        {
            RENT_BIKE,
            PAY
        }

        ///<value>
        /// enum use to define the rent bike form status
        ///</value>
        ///<remarks>
        ///RENT_BIKE: rent bike form will display QRcode screen
        ///RENTING_BIKE: the status of rent bike form when user is renting bike
        ///RENT_BIKE_INFO: rent bike form will display some information bike that use want to rent
        ///</remarks>
        public enum RENT_BIKE
        {
            RENT_BIKE,
            RENTING_BIKE,
            RENT_BIKE_INFO
        }

        /// <value>
        /// Translate bike category
        /// </value>
        public static Dictionary<string, string> BIKE_CATEGORY = new Dictionary<string, string>()
        {
            {"bike", "Xe đạp thường" },
            {"electric", "Xe đạp điện" },
            {"tandem", "Xe đạp đôi" }
        };

        /// <value>
        /// Define bike deposit base on bike category
        /// </value>
        public static Dictionary<string, int> BIKE_DEPOSIT = new Dictionary<string, int>()
        {
            {"bike", 400000 },
            {"electric", 700000 },
            {"tandem", 550000 }
        };

        ///<Value>get current rent bike form status</Value>
        public static RENT_BIKE RENT_BIKE_STATUS;
    }
}
