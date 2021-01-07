﻿// --------------------RENTAL BIKE APP-----------------
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

namespace RentalBikeApp.Entities.InterbankEntities
{
    /// <summary>
    /// representing process transaction response
    /// </summary>
    public class ProcessTransactionResponse : InterbankResponse
    {
        /// <summary>
        /// transaction information
        /// </summary>
        public TransactionInfo transaction { get; protected set; }

        /// <summary>
        /// contructor of ProcessTransactionResponse
        /// </summary>
        /// <param name="errorCode">The response error code</param>
        /// <param name="transaction">The transaction information</param>
        public ProcessTransactionResponse(string errorCode, TransactionInfo transaction) : base(errorCode)
        {
            this.transaction = transaction;
        }
    }
}
