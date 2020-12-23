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
    /// <summary>
    /// reqresenting the transactions table in database
    /// </summary>
    [Table("Transactions")]
    public class Transaction
    {
        /// <summary>
        /// transaction id
        /// </summary>
        [Key]
        public int TransactionId { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        [Required(ErrorMessage = "UserId is required")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// bike id
        /// </summary>
        [Required(ErrorMessage = "BikeId is required")]
        [ForeignKey("Bike")]
        public string BikeQrCode { get; set; }

        /// <summary>
        /// deposit
        /// </summary>
        [Required(ErrorMessage = "Deposit is required")]
        public int Deposit { get; set; }

        /// <summary>
        /// rental money for rent bike
        /// </summary>
        [Required(ErrorMessage = "RentalMoney is required")]
        public int RentalMoney { get; set; }

        /// <summary>
        /// time to rent
        /// </summary>
        [Required(ErrorMessage = "TotalTimeRent is required")]
        public int TotalTimeRent { get; set; }

        /// <summary>
        /// date transaction
        /// </summary>
        [Required(ErrorMessage = "DateTransaction is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateTransaction { get; set; }

        /// <summary>
        /// note
        /// </summary>
        [StringLength(100)]
        public string Note { get; set; }
    }
}
