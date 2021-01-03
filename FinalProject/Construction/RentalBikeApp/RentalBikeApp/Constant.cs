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

namespace RentalBikeApp
{
    /// <summary>
    /// this class provider contants for program
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// connect string of sql data
        /// </summary>
        //private static string SQL_CONNECT_STRING = "Data Source=.\\MSSQLSERVER123;Initial Catalog=RentalBike;Integrated Security=True";
        // private static string SQL_CONNECT_STRING = "Data Source=.\\SQLEXPRESS;Initial Catalog=RentalBike;Integrated Security=True;";
        //public const string SQL_CONNECT_STRING = "Data Source=.\\SQLEXPRESS;Initial Catalog=RentalBike;Integrated Security=True";
        //public const string SQL_CONNECT_STRING = "Data Source=DESKTOP-G8MLPP4\\SQLEXPRESS;Initial Catalog=RentalBike;Integrated Security=True";
        public const string SQL_CONNECT_STRING = "data source=DESKTOP-TM16V8B\\SQLEXPRESS;initial catalog=RentalBike;user id=sa;password=phamhongphuc;MultipleActiveResultSets=True;";

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

        /// <summary>
        /// use for valid qr code
        /// </summary>
        public const string QRValid = @"^[0,1,2][0-9]{8}";
    }
}
