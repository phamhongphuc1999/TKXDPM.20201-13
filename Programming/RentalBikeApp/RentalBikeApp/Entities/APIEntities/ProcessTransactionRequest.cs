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
    public class ProcessTransactionRequest
    {
        [Required]
        public string version { get; set; }

        [Required]
        public TransactionInfo transaction { get; set; }

        [Required]
        public string appCode { get; set; }

        [Required]
        public string hashCode { get; set; }
    }
}
