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

using System;
using System.ComponentModel.DataAnnotations;

namespace RentalBikeApp.Entities.APIEntities
{
    /// <summary>
    /// representing the transaction information in body of transaction request
    /// </summary>
    [Serializable]
    public class TransactionInfo
    {
        /// <summary>
        /// transaction command
        /// </summary>
        [Required]
        public string command { get; set; }

        /// <summary>
        /// card code
        /// </summary>
        [Required]
        public string cardCode { get; set; }

        /// <summary>
        /// card owner
        /// </summary>
        [Required]
        public string owner { get; set; }

        /// <summary>
        /// card cvv code
        /// </summary>
        [Required]
        public string cvvCode { get; set; }

        /// <summary>
        /// card date expired
        /// </summary>
        [Required]
        public string dateExpired { get; set; }

        /// <summary>
        /// transaction content(option)
        /// </summary>
        [Required]
        public string transactionContent { get; set; }

        /// <summary>
        /// transaction amount money
        /// </summary>
        [Required]
        public int amount { get; set; }

        /// <summary>
        /// date of transaction created
        /// </summary>
        [Required]
        public string createdAt { get; set; }
    }
}
