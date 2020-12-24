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

namespace RentalBikeApp.Entities.APIEntities
{
    /// <summary>
    /// representing process transaction response
    /// </summary>
    public class ProcessTransactionResponse
    {
        /// <summary>
        /// error code of response
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// transaction information
        /// </summary>
        public TransactionInfo transaction { get; set; }
    }
}
