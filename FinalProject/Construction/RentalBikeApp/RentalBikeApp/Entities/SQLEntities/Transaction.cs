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
        public int TransactionId { get; private set; }

        /// <summary>
        /// user id
        /// </summary>
        [Required(ErrorMessage = "UserId is required")]
        [ForeignKey("User")]
        public int UserId { get; private set; }

        /// <summary>
        /// bike id
        /// </summary>
        [Required(ErrorMessage = "BikeId is required")]
        [ForeignKey("Bike")]
        public int BikeId { get; private set; }

        /// <summary>
        /// deposit
        /// </summary>
        [Required(ErrorMessage = "Deposit is required")]
        public int Deposit { get; private set; }

        /// <summary>
        /// rental money for rent bike
        /// </summary>
        [Required(ErrorMessage = "RentalMoney is required")]
        public int RentalMoney { get; private set; }

        /// <summary>
        /// time to rent
        /// </summary>
        [Required(ErrorMessage = "TotalTimeRent is required")]
        public int TotalTimeRent { get; private set; }

        /// <summary>
        /// date transaction
        /// </summary>
        [Required(ErrorMessage = "DateTransaction is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateTransaction { get; private set; }

        /// <summary>
        /// note
        /// </summary>
        [StringLength(100)]
        public string Note { get; private set; }

        /// <summary>
        /// Contructor of transaction
        /// </summary>
        /// <param name="userId">The id of user who process transaction</param>
        /// <param name="bikeId">The id of rental bike</param>
        /// <param name="deposit">The deposit of transaction</param>
        public Transaction(int userId, int bikeId, int deposit)
        {
            this.UserId = userId;
            this.BikeId = bikeId;
            this.Deposit = deposit;
            this.RentalMoney = 0;
            this.TotalTimeRent = 0;
            this.DateTransaction = DateTime.Now;
        }

        /// <summary>
        /// Update transaction
        /// </summary>
        /// <param name="rentalMoney">The rental money of transaction</param>
        /// <param name="totalTimeRent">The total time rent of transaction</param>
        /// <param name="note">The note of transaction</param>
        /// <returns>The transaction before updated</returns>
        public void UpdateTransaction(int rentalMoney, int totalTimeRent, string note)
        {
            this.RentalMoney = rentalMoney;
            this.TotalTimeRent = totalTimeRent;
            this.DateTransaction = DateTime.Now;
            this.Note = note;
        }
    }
}
