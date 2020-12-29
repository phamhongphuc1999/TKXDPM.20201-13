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
    /// reqresenting the ElectricBike table in database
    /// </summary>
    [Table("ElectricBike")]
    public class ElectricBikeTable
    {
        /// <summary>
        /// bike id
        /// </summary>
        [Key]
        public int BikeId { get; private set; }

        /// <summary>
        /// remain of power
        /// </summary>
        public int Powers { get; private set; }

        /// <summary>
        /// the license plate
        /// </summary>
        public string LicensePlate { get; private set; }
    }
    /// <summary>
    /// representing the electric bike table in database
    /// </summary>
    public class ElectricBike: BaseBike
    {
        /// <summary>
        /// remain of power
        /// </summary>
        [Required]
        public int Powers { get; private set; }

        /// <summary>
        /// the license plate of bike
        /// </summary>
        [Required]
        public string LicensePlate { get; private set; }

        /// <summary>
        /// Contructor of ElectricBike
        /// </summary>
        public ElectricBike(): base() { }

        /// <summary>
        /// Contructor of ElectricBike
        /// </summary>
        /// <param name="bike">The base bike information</param>
        /// <param name="electricBike">The specified electric bike information</param>
        public ElectricBike(BaseBike bike, ElectricBikeTable electricBike): base(bike)
        {
            this.Powers = electricBike.Powers;
            this.LicensePlate = electricBike.LicensePlate;
        }
    }
}
