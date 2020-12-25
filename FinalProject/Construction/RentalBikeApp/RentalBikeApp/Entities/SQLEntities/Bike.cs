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

using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    /// <summary>
    /// representing the bikes table in database
    /// </summary>
    [Table("Bikes")]
    public class Bike: BaseBike
    {
        /// <summary>
        /// Contructor of Bike
        /// </summary>
        public Bike(): base() { }

        /// <summary>
        /// Contructor of Bike
        /// </summary>
        /// <param name="stationId">The id of station contain bike</param>
        /// <param name="value">The value of bike</param>
        /// <param name="qrcode">The qrcode of bike</param>
        /// <param name="manufacturer">The manufacture of bike</param>
        public Bike(int stationId, int value, string qrcode, string manufacturer): base(stationId, value, qrcode, manufacturer) { }
    }
}
