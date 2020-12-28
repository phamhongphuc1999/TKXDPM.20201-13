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
    [Table("Tandem")]
    public class TandemTable
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int BikeId { get; set; }
    }

    /// <summary>
    /// reqresenting the tandem table in database
    /// </summary>
    public class Tandem: BaseBike
    {
        /// <summary>
        /// Contructor of Tandem
        /// </summary>
        public Tandem() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bike"></param>
        public Tandem(BaseBike bike): base(bike) { }
    }
}
