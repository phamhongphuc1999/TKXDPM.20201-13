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

namespace RentalBikeApp
{
    /// <summary>
    /// this class provider contants for program
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// This static class use to config connect to sql server
        /// </summary>
        public static class SQL
        {
            /// <summary>
            /// connect string of sql data
            /// </summary>
            //private static string SQL_CONNECT_STRING = "Data Source=.\\MSSQLSERVER123;Initial Catalog=RentalBike;Integrated Security=True";
            // private static string SQL_CONNECT_STRING = "Data Source=.\\SQLEXPRESS;Initial Catalog=RentalBike;Integrated Security=True;";
            //public const string SQL_CONNECT_STRING = "Data Source=.\\SQLEXPRESS;Initial Catalog=RentalBike;Integrated Security=True";
            public const string SQL_CONNECT_STRING = "data source=DESKTOP-TM16V8B\\SQLEXPRESS;initial catalog=RentalBike;user id=sa;password=phamhongphuc;MultipleActiveResultSets=True;";
            //public const string SQL_CONNECT_STRING = "Server=tcp:ecobike.database.windows.net,1433;Initial Catalog=RentalBike;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            ///<value>
            ///enum define category bike
            ///</value>
            public enum BikeCategory
            {
                /// <summary>
                /// representing of electric bike
                /// </summary>
                ELECTRIC,
                /// <summary>
                /// representing of tandem
                /// </summary>
                TANDEM,
                /// <summary>
                /// representing of bike
                /// </summary>
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
            public const string BASE_URL = "https://ecopark-system-api.herokuapp.com";

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
            public enum COMMAND
            {
                /// <summary>
                /// use when transaction for pay money
                /// </summary>
                PAY, 
                /// <summary>
                /// use when transaction for refund deposit
                /// </summary>
                REFUND
            }

            /// <summary>
            /// error code
            /// </summary>
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

        ///<value>
        /// enum use to define the transaction form status
        ///</value>
        public enum TRANSACTION_STATUS
        {
            /// <summary>
            /// transaction with status ren bike
            /// </summary>
            RENT_BIKE,
            /// <summary>
            /// transaction with status pay
            /// </summary>
            PAY
        }

        /// <summary>
        /// use for valid qr code
        /// </summary>
        public const string QRValid = @"^[0,1,2][0-9]{8}";
    }
}
