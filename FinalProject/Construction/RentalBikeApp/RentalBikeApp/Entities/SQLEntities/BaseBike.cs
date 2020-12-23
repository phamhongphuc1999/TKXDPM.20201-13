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
        /// <summary>
        /// bike id
        /// </summary>
        [Key]
        public int BikeId { get; set; }

        /// <summary>
        /// station id
        /// </summary>
        [Required(ErrorMessage = "StationId is required")]
        [ForeignKey("Station")]
        public int StationId { get; set; }

        /// <summary>
        /// bike value
        /// </summary>
        [Range(0, Int32.MaxValue)]
        public int Value { get; set; }

        /// <summary>
        /// bike qrcode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QRCode is required")]
        [StringLength(100)]
        public string QRCode { get; set; }

        /// <summary>
        /// bike manufacturer
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Manufacturer is required")]
        [StringLength(200)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// bike status
        /// </summary>
        [Required(ErrorMessage = "BikeStatus is required")]
        public bool BikeStatus { get; set; }
    }

    /// <summary>
    /// this class use to save update information bike
    /// </summary>
    public class UpdateBikeInfo
    {
        /// <summary>
        /// station id contain bike
        /// </summary>
        public int StationId { get; set; }

        /// <summary>
        /// bike value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// bike qrcode
        /// </summary>
        public string QRCode { get; set; }

        /// <summary>
        /// bike manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// bike status
        /// </summary>
        public int BikeStatus { get; set; }
    }
}
