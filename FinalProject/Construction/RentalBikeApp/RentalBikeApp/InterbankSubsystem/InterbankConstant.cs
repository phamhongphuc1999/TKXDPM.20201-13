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

namespace RentalBikeApp.InterbankSubsystem
{
    internal static class InterbankConstant
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
    }
}
