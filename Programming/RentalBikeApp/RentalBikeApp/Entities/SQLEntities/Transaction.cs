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
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "BikeId is required")]
        [ForeignKey("Bike")]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "Deposit is required")]
        public int Deposit { get; set; }

        [Required(ErrorMessage = "RentalMoney is required")]
        public int RentalMoney { get; set; }

        [Required(ErrorMessage = "TotalTimeRent is required")]
        public int TotalTimeRent { get; set; }

        [Required(ErrorMessage = "DateTransaction is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateTransaction { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
