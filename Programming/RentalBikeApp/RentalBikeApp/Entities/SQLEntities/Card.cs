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

        [Required(ErrorMessage = "ExpirationDate is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExpirationDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "SecurityCode is required")]
        [StringLength(10)]
        public string SecurityCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PrivateToken is required")]
        [StringLength(100)]
        public string PrivateToken { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
