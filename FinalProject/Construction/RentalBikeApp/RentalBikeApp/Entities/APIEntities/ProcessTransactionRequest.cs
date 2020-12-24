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

namespace RentalBikeApp.Entities.APIEntities
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
        public string version { get; set; }

        /// <summary>
        /// The transaction information
        /// </summary>
        [Required]
        public TransactionInfo transaction { get; set; }

        /// <summary>
        /// The app code of card
        /// </summary>
        [Required]
        public string appCode { get; set; }

        /// <summary>
        /// hash for invalid information of request
        /// </summary>
        [Required]
        public string hashCode { get; set; }
    }
}
