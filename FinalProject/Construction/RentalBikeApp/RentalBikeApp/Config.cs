// --------------------RENTAL BIKE APP-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//   Su Huu Vu Quang
//   Pham Hong Phuc
//   Tran Minh Quang
//   Ngo Minh Quang
//
//
// ------------------------------------------------------

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
            //private static string SQL_CONNECT_STRING = "Data Source=.\\MSSQLSERVER123;Initial Catalog=RentalBike;Integrated Security=True";
            // private static string SQL_CONNECT_STRING = "Data Source=.\\SQLEXPRESS;Initial Catalog=RentalBike;Integrated Security=True;";
            //public const string SQL_CONNECT_STRING = "Data Source=.\\MSSQLSERVER123;Initial Catalog=RentalBike;Integrated Security=True";
            public const string SQL_CONNECT_STRING = "data source=DESKTOP-TM16V8B\\SQLEXPRESS;initial catalog=RentalBike;user id=sa;password=phamhongphuc;MultipleActiveResultSets=True;";
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
                BIKE
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
        }

        ///<Value>get current rent bike form status</Value>
        public static RENT_BIKE RENT_BIKE_STATUS;

        public static SQL.BikeCategory RENTAL_BIKE_CATEGORY;

        ///<Value>get current rental bike</Value>
        public static BaseBike RENTAL_BIKE;

        /// <value>
        /// Get the time rental bike
        /// </value>
        public static string TIME_RENTAL_BIKE;

        ///<Value>get current card information</Value>
        public static Card CARD_INFO;

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

        public const string QRValid = @"^[0,1,2][0-9]{8}";
    }
}
