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

namespace RentalBikeApp.Entities.InterbankEntities
{
    /// <summary>
    /// representing process transaction response
    /// </summary>
    public class ProcessTransactionResponse: InterbankResponse
    {
        /// <summary>
        /// transaction information
        /// </summary>
        public TransactionInfo transaction { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="transaction"></param>
        public ProcessTransactionResponse(string errorCode, TransactionInfo transaction): base(errorCode)
        {
            this.transaction = transaction;
        }
    }
}
