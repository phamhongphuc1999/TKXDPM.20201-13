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
using static RentalBikeApp.Program;
using static RentalBikeApp.Constant;
using RentalBikeApp.Entities.SQLEntities;
using System.Drawing;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with bike detail screen
    /// </summary>
    public partial class BikeDetailForm : BaseForm
    {
        private BaseBike bike;
        private BikeCategory category;

        /// <summary>
        /// contructor of BikeDetailForm
        /// </summary>
        public BikeDetailForm(): base()
        {
            InitializeComponent("BikeDetailForm", "Bike Detail");
            DrawBikeDetail();
        }

        /// <summary>
        /// Display bike information
        /// </summary>
        /// <param name="bike">The bike information</param>
        /// <param name="stationName">The station name contain this bike</param>
        /// <param name="stationAddress">The station address contain this bike</param>
        public void FillBikeInformation(BaseBike bike, string stationName, string stationAddress)
        {
            stationRtb.Text = $"{stationName}\n{stationAddress}";
            qrCodeTxt.Text = bike.QRCode;
            manufactureTxt.Text = bike.Manufacturer;
            avatarPb.Image = Image.FromFile(bike.Images);
            if (bike.BikeStatus)
            {
                statusBikeLbl.Text = "Renting";
                statusBikeLbl.BackColor = Color.Red;
                viewRentingBut.Visible = true;
                rentThisBikeBut.Visible = false;
            }
            else
            {
                statusBikeLbl.Text = "Available";
                statusBikeLbl.BackColor = Color.Green;
                viewRentingBut.Visible = false;
                rentThisBikeBut.Visible = true;
            }
            if (bike.Category == "bike")
            {
                categoryBikeTxt.Text = "Xe đạp thường";
                powerTxt.Text = "Không có thông tin";
                licenceTxt.Text = "Không có thông tin";
                this.category = BikeCategory.BIKE;
            }
            else if (bike.Category == "tandem")
            {
                categoryBikeTxt.Text = "Xe đạp đôi";
                powerTxt.Text = "Không có thông tin";
                licenceTxt.Text = "Không có thông tin";
                this.category = BikeCategory.TANDEM;
            }
            else
            {
                ElectricBike electric = bike as ElectricBike;
                categoryBikeTxt.Text = "Xe đạp điện";
                powerTxt.Text = $"{electric.Powers}%";
                licenceTxt.Text = electric.LicensePlate;
                this.category = BikeCategory.ELECTRIC;
            }
            this.bike = bike;
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void RentBikeBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.DisplayRentbikeQrcode();
            rentBikeForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void HomePageBut_Click(object sender, EventArgs e)
        {
            homePageForm.RenderStationList();
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event RentThisBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentThisBikeBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.FillRentBikeInfoForm(this.bike.BikeId, this.category);
            rentBikeForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event ViewRentingBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void ViewRentingBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.FillRentingBikeForm(bike);
            rentBikeForm.Show(this, this);
            this.Hide();
        }
    }
}
