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

        /// <summary>
        /// Contructor of ElectricBike
        /// </summary>
        /// <param name="stationId">The id of station contain bike</param>
        /// <param name="value">The value of bike</param>
        /// <param name="qrcode">The qrcode of bike</param>
        /// <param name="manufacturer">The manufacture of bike</param>
        /// <param name="power">The remain power of bike</param>
        /// <param name="licensePlate">The license of bike</param>
        public ElectricBike(int stationId, int value, string qrcode, string manufacturer, int power, string licensePlate) : base(stationId, value, qrcode, manufacturer)
        {
            this.Powers = power;
            this.LicensePlate = licensePlate;
        }
    }
}
