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
    /// reqresenting the Bikes table in database
    /// </summary>
    [Table("Bikes")]
    public class BikeTable
    {
        /// <summary>
        /// bike id
        /// </summary>
        [Key]
        public int BikeId { get; private set; }
    }

    /// <summary>
    /// representing the bikes table in database
    /// </summary>
    public class Bike: BaseBike
    {
        /// <summary>
        /// Contructor of Bike
        /// </summary>
        /// <param name="bike">the bike information</param>
        public Bike(BaseBike bike): base(bike) { }
    }
}
