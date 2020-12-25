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
    /// reqresenting the tandem table in database
    /// </summary>
    [Table("Tandem")]
    public class Tandem: BaseBike
    {
        /// <summary>
        /// Contructor of Tandem
        /// </summary>
        public Tandem() : base() { }

        /// <summary>
        /// Contructor of Tandem
        /// </summary>
        /// <param name="stationId">The id of station contain bike</param>
        /// <param name="value">The value of bike</param>
        /// <param name="qrcode">The qrcode of bike</param>
        /// <param name="manufacturer">The manufacture of bike</param>
        public Tandem(int stationId, int value, string qrcode, string manufacturer) : base(stationId, value, qrcode, manufacturer) { }
    }
}
