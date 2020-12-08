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
    [Table("Cards")]
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bank is required")]
        [StringLength(100)]
        public string Bank { get; set; }

        [Required(ErrorMessage = "CardCode is required")]
        [StringLength(50)]
        public string CardCode { get; set; }

        [Required(ErrorMessage = "Owners is required")]
        [StringLength(50)]
        public string Owners { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        [StringLength(10)]
        public string CVV { get; set; }

        [Required(ErrorMessage = "DateExpired is required")]
        [StringLength(10)]
        public string DateExpired { get; set; }

        [Required(ErrorMessage = "AppCode is required")]
        [StringLength(50)]
        public string AppCode { get; set; }

        [Required(ErrorMessage = "SecurityKey is required")]
        [StringLength(50)]
        public string SecurityKey { get; set; }
    }
}
