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
    /// representing the electric bike table in database
    /// </summary>
    [Table("ElectricBike")]
    public class ElectricBike: BaseBike
    {
        /// <summary>
        /// remain of power
        /// </summary>
        [Required]
        public int Powers { get; set; }

        /// <summary>
        /// the license plate of bike
        /// </summary>
        [Required]
        public string LicensePlate { get; set; }
    }
}
