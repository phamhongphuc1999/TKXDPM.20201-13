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
        public int BikeId { get; private set; }

        /// <summary>
        /// station id
        /// </summary>
        [Required(ErrorMessage = "StationId is required")]
        [ForeignKey("Station")]
        public int StationId { get; private set; }

        /// <summary>
        /// the date begin rent bike
        /// </summary>
        public DateTime? DateRent { get; private set; }

        /// <summary>
        /// the images of bike
        /// </summary>
        [Required(ErrorMessage = "Images is rquired")]
        public string Images { get; private set; }

        /// <summary>
        /// bike value
        /// </summary>
        [Range(0, Int32.MaxValue)]
        public int Value { get; private set; }

        /// <summary>
        /// bike qrcode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QRCode is required")]
        [StringLength(100)]
        public string QRCode { get; private set; }

        /// <summary>
        /// bike manufacturer
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Manufacturer is required")]
        [StringLength(200)]
        public string Manufacturer { get; private set; }

        /// <summary>
        /// bike status
        /// </summary>
        [Required(ErrorMessage = "BikeStatus is required")]
        public bool BikeStatus { get; private set; }

        /// <summary>
        /// Contructor of BaseBike
        /// </summary>
        public BaseBike() { }

        /// <summary>
        /// Contructor of BaseBike
        /// </summary>
        /// <param name="stationId">The id of station contain bike</param>
        /// <param name="value">The value of bike</param>
        /// <param name="qrcode">The qrcode of bike</param>
        /// <param name="manufacturer">The manufacture of bike</param>
        public BaseBike(int stationId, int value, string qrcode, string manufacturer)
        {
            this.StationId = stationId;
            this.Value = value;
            this.QRCode = qrcode;
            this.Manufacturer = manufacturer;
            this.BikeStatus = false;
        }

        /// <summary>
        /// Contructor of BaseBike
        /// </summary>
        /// <param name="bikeId">id of base bike</param>
        /// <param name="stationId">The id of station contain bike</param>
        /// <param name="value">The value of bike</param>
        /// <param name="qrcode">The qrcode of bike</param>
        /// <param name="manufacturer">The manufacture of bike</param>
        /// <param name="status">bike status</param>
        public BaseBike(int bikeId, int stationId, int value, string qrcode, string manufacturer, bool status = false)
        {
            this.BikeId = bikeId;
            this.StationId = stationId;
            this.Value = value;
            this.QRCode = qrcode;
            this.Manufacturer = manufacturer;
            this.BikeStatus = status;
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="update">the update bike information</param>
        /// <returns></returns>
        public BaseBike UpdateBike(UpdateBikeInfo update)
        {
            if (update.StationId > 0) this.StationId = update.StationId;
            if (update.DateRent != null) this.DateRent = update.DateRent;
            if (!string.IsNullOrEmpty(update.Images)) this.Images = update.Images;
            if (update.Value > 0) this.Value = update.Value;
            if (update.QRCode != null) this.QRCode = update.QRCode;
            if (update.Manufacturer != null) this.Manufacturer = update.Manufacturer;
            if (update.BikeStatus > 0) this.BikeStatus = true;
            if (update.BikeStatus < 0) this.BikeStatus = false;
            return this;
        }
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
        /// the date begin rent bike
        /// </summary>
        public DateTime? DateRent { get; set; }

        /// <summary>
        /// Images of bike
        /// </summary>
        public string Images { get; set; }

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
