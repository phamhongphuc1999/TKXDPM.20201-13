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
        [Required]
        public string command { get; set; }

        [Required]
        public string cardCode { get; set; }

        [Required]
        public string owner { get; set; }

        [Required]
        public string cvvCode { get; set; }

        [Required]
        public string dateExpired { get; set; }

        [Required]
        public string transactionContent { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public string createdAt { get; set; }
    }
}
