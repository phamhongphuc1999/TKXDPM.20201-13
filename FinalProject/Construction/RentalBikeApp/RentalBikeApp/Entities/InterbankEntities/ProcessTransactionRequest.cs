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

using System.ComponentModel.DataAnnotations;

namespace RentalBikeApp.Entities.InterbankEntities
{
    /// <summary>
    /// representing the process transaction information body in request
    /// </summary>
    public class ProcessTransactionRequest
    {
        /// <summary>
        /// The version of API
        /// </summary>
        [Required]
        public string version { get; private set; }

        /// <summary>
        /// The transaction information
        /// </summary>
        [Required]
        public TransactionInfo transaction { get; private set; }

        /// <summary>
        /// The app code of card
        /// </summary>
        [Required]
        public string appCode { get; private set; }

        /// <summary>
        /// hash for invalid information of request
        /// </summary>
        [Required]
        public string hashCode { get; private set; }

        /// <summary>
        /// contructor of ProcessTransactionRequest
        /// </summary>
        /// <param name="version">The specified version of transaction</param>
        /// <param name="transaction">The transaction information</param>
        /// <param name="appCode">The app code</param>
        /// <param name="hashCode">The hash code</param>
        public ProcessTransactionRequest(string version, TransactionInfo transaction, string appCode, string hashCode)
        {
            this.version = version;
            this.transaction = transaction;
            this.appCode = appCode;
            this.hashCode = hashCode;
        }
    }
}
