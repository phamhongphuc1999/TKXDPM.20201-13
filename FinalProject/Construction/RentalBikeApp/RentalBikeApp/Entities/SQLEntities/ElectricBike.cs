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
    /// 
    /// </summary>
    [Table("ElectricBike")]
    public class ElectricBikeTable
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int BikeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Powers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LicensePlate { get; set; }
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
        public int Powers { get; set; }

        /// <summary>
        /// the license plate of bike
        /// </summary>
        [Required]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Contructor of ElectricBike
        /// </summary>
        public ElectricBike(): base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bike"></param>
        /// <param name="electricBike"></param>
        public ElectricBike(BaseBike bike, ElectricBikeTable electricBike): base(bike)
        {
            this.Powers = electricBike.Powers;
            this.LicensePlate = electricBike.LicensePlate;
        }
    }
}
