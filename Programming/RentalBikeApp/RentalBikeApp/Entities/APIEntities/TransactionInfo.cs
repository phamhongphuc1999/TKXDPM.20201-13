// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.ComponentModel.DataAnnotations;

namespace RentalBikeApp.Entities.APIEntities
{
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
