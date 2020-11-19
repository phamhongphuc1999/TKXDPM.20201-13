// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("Stations")]
    public class Station
    {
        [Key]
        public int StationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "NameStation is required")]
        [StringLength(200)]
        public string NameStation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressStation is required")]
        [StringLength(200)]
        public string AddressStation { get; set; }

        [Required(ErrorMessage = "AreaStaion is required")]
        public int AreaStaion { get; set; }

        [Required(ErrorMessage = "NumberOfBike is required")]
        public int NumberOfBike { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
