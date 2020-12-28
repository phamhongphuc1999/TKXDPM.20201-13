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

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    /// <summary>
    /// Representing the BaseBike table in database
    /// </summary>
    [Table("BaseBike")]
    public class BaseBike
    {
        /// <summary>
        /// bike id
        /// </summary>
        [Key]
        public int BikeId { get; protected set; }

        /// <summary>
        /// station id
        /// </summary>
        [Required(ErrorMessage = "StationId is required")]
        [ForeignKey("Station")]
        public int StationId { get; protected set; }

        /// <summary>
        /// the date begin rent bike
        /// </summary>
        public DateTime? DateRent { get; protected set; }

        /// <summary>
        /// the images of bike
        /// </summary>
        [Required(ErrorMessage = "Images is rquired")]
        public string Images { get; protected set; }

        /// <summary>
        /// bike category
        /// </summary>
        [Required(ErrorMessage = "Category is requires")]
        public string Category { get; protected set; }

        /// <summary>
        /// bike value
        /// </summary>
        [Range(0, Int32.MaxValue)]
        public int Value { get; protected set; }

        /// <summary>
        /// bike qrcode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QRCode is required")]
        [StringLength(100)]
        public string QRCode { get; protected set; }

        /// <summary>
        /// bike manufacturer
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Manufacturer is required")]
        [StringLength(200)]
        public string Manufacturer { get; protected set; }

        /// <summary>
        /// bike status
        /// </summary>
        [Required(ErrorMessage = "BikeStatus is required")]
        public bool BikeStatus { get; protected set; }

        /// <summary>
        /// Contructor of BaseBike
        /// </summary>
        public BaseBike() { }

        /// <summary>
        /// Contructor of BaseBike
        /// </summary>
        /// <param name="bikeId">id of bike</param>
        /// <param name="stationId">id of station</param>
        /// <param name="value">value of bike</param>
        /// <param name="qrcode">qrcode of bike</param>
        /// <param name="manufacturer">bike namufacturer</param>
        /// <param name="bikeStatus">the bike status</param>
        public BaseBike(int bikeId, int stationId, int value, string qrcode, string manufacturer, bool bikeStatus = false)
        {
            this.BikeId = bikeId;
            this.StationId = stationId;
            this.Value = value;
            this.QRCode = qrcode;
            this.Manufacturer = manufacturer;
            this.BikeStatus = bikeStatus;
        }

        /// <summary>
        /// Contructor of BaseBike
        /// </summary>
        /// <param name="bike">bike information</param>
        public BaseBike(BaseBike bike)
        {
            this.BikeId = bike.BikeId;
            this.StationId = bike.StationId;
            this.Value = bike.Value;
            this.QRCode = bike.QRCode;
            this.Manufacturer = bike.Manufacturer;
            this.Images = bike.Images;
            this.DateRent = bike.DateRent;
            this.BikeStatus = bike.BikeStatus;
            this.Category = bike.Category;
        }

        /// <summary>
        /// Update bike information
        /// </summary>
        /// <param name="update">the update bike information</param>
        /// <param name="isUpdateDate">if isUpdateDate is true, the RentDate will be updated or not if isUpdateDate is false</param>
        /// <returns>the bike before updated</returns>
        public BaseBike UpdateBike(UpdateBikeInfo update, bool isUpdateDate = false)
        {
            if (update.StationId > 0) this.StationId = update.StationId;
            if (isUpdateDate) this.DateRent = update.DateRent;
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
