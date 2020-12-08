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
    public class BaseBike
    {
        [Key]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "StationId is required")]
        [ForeignKey("Station")]
        public int StationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "QRCode is required")]
        [StringLength(100)]
        public string QRCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Manufacturer is required")]
        [StringLength(200)]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "BikeStatus is required")]
        public bool BikeStatus { get; set; }
    }
}
