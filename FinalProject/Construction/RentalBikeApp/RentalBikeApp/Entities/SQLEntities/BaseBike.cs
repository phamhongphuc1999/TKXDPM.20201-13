using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    /// <summary>
    /// this class entend for all of bike in program
    /// </summary>
    public class BaseBike
    {
        [Key]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "StationId is required")]
        [ForeignKey("Station")]
        public int StationId { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Value { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "QRCode is required")]
        [StringLength(100)]
        public string QRCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Manufacturer is required")]
        [StringLength(200)]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "BikeStatus is required")]
        public bool BikeStatus { get; set; }
    }

    /// <summary>
    /// this class use to save update information bike
    /// </summary>
    public class UpdateBikeInfo
    {
        public int StationId { get; set; }

        public int Value { get; set; }

        public string QRCode { get; set; }

        public string Manufacturer { get; set; }

        public int BikeStatus { get; set; }
    }
}
