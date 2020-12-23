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
    /// reqresenting the stations table in database
    /// </summary>
    [Table("Stations")]
    public class Station
    {
        /// <summary>
        /// station id
        /// </summary>
        [Key]
        public int StationId { get; set; }

        /// <summary>
        /// name of station
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "NameStation is required")]
        [StringLength(200)]
        public string NameStation { get; set; }

        /// <summary>
        /// address of station
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressStation is required")]
        [StringLength(200)]
        public string AddressStation { get; set; }

        /// <summary>
        /// area of station
        /// </summary>
        [Required(ErrorMessage = "AreaStaion is required")]
        public int AreaStaion { get; set; }

        /// <summary>
        /// maximute number of bike in station
        /// </summary>
        [Required(ErrorMessage = "NumberOfBike is required")]
        public int NumberOfBike { get; set; }

        /// <summary>
        /// note
        /// </summary>
        [StringLength(100)]
        public string Note { get; set; }
    }
}
