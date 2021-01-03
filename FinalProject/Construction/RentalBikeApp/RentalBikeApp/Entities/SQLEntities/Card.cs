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
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    /// <summary>
    /// reqresenting the Cards table in database
    /// </summary>
    [Table("Cards")]
    public class Card
    {
        /// <summary>
        /// card id
        /// </summary>
        [Key]
        public int CardId { get; private set; }

        /// <summary>
        /// id of user has this card
        /// </summary>
        [Required]
        [ForeignKey("User")]
        public int UserId { get; private set; }

        /// <summary>
        /// bank publish card
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bank is required")]
        [StringLength(100)]
        public string Bank { get; private set; }

        /// <summary>
        /// card code
        /// </summary>
        [Required(ErrorMessage = "CardCode is required")]
        [StringLength(50)]
        public string CardCode { get; private set; }

        /// <summary>
        /// owner of card
        /// </summary>
        [Required(ErrorMessage = "Owners is required")]
        [StringLength(50)]
        public string Owners { get; private set; }

        /// <summary>
        /// card cvv
        /// </summary>
        [Required(ErrorMessage = "CVV is required")]
        [StringLength(10)]
        public string CVV { get; private set; }

        /// <summary>
        /// date expired of card
        /// </summary>
        [Required(ErrorMessage = "DateExpired is required")]
        [StringLength(10)]
        public string DateExpired { get; private set; }

        /// <summary>
        /// card app code
        /// </summary>
        [Required(ErrorMessage = "AppCode is required")]
        [StringLength(50)]
        public string AppCode { get; private set; }

        /// <summary>
        /// card security key
        /// </summary>
        [Required(ErrorMessage = "SecurityKey is required")]
        [StringLength(50)]
        public string SecurityKey { get; private set; }

        /// <summary>
        /// contructor of Card
        /// </summary>
        public Card() { }

        /// <summary>
        /// contructor of Card
        /// </summary>
        /// <param name="userId">id of user has this card</param>
        /// <param name="bank">bank publish card</param>
        /// <param name="cardCode">card code</param>
        /// <param name="owner">owner of card</param>
        /// <param name="cvv">card cvv</param>
        /// <param name="dateExpired">date expired of card</param>
        /// <param name="appCode">card app code</param>
        /// <param name="securityKey">card security key</param>
        public Card(int userId, string bank, string cardCode, string owner, string cvv, string dateExpired, string appCode, string securityKey)
        {
            this.UserId = userId;
            this.Bank = bank;
            this.CardCode = cardCode;
            this.Owners = owner;
            this.CVV = cvv;
            this.DateExpired = dateExpired;
            this.AppCode = appCode;
            this.SecurityKey = securityKey;
        }
    }
}
