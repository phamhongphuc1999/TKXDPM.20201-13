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
    /// 
    /// </summary>
    public class TransactionCardInfo: TransactionInfo
    {
        /// <summary>
        /// transaction command
        /// </summary>
        [Required]
        public string command { get; private set; }

        /// <summary>
        /// card code
        /// </summary>
        [Required]
        public string cardCode { get; private set; }

        /// <summary>
        /// card owner
        /// </summary>
        [Required]
        public string owner { get; private set; }

        /// <summary>
        /// card cvv code
        /// </summary>
        [Required]
        public string cvvCode { get; private set; }

        /// <summary>
        /// card date expired
        /// </summary>
        [Required]
        public string dateExpired { get; private set; }

        /// <summary>
        /// transaction content(option)
        /// </summary>
        [Required]
        public string transactionContent { get; private set; }

        /// <summary>
        /// transaction amount money
        /// </summary>
        [Required]
        public int amount { get; private set; }

        /// <summary>
        /// date of transaction created
        /// </summary>
        [Required]
        public string createdAt { get; private set; }

        /// <summary>
        /// contructor of TransactionCardInfo
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cardCode"></param>
        /// <param name="owner"></param>
        /// <param name="cvvCode"></param>
        /// <param name="dateExpired"></param>
        /// <param name="transactionContent"></param>
        /// <param name="amount"></param>
        /// <param name="createdAt"></param>
        public TransactionCardInfo(string command, string cardCode, string owner, string cvvCode, string dateExpired, string transactionContent, int amount, string createdAt): base()
        {
            this.command = command;
            this.cardCode = cardCode;
            this.owner = owner;
            this.cvvCode = cvvCode;
            this.dateExpired = dateExpired;
            this.transactionContent = transactionContent;
            this.amount = amount;
            this.createdAt = createdAt;
        }
    }
}
