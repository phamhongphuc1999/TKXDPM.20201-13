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
using System.Windows.Forms;
using static RentalBikeApp.Program;
using RentalBikeApp.Entities.SQLEntities;
using System.Drawing;

namespace RentalBikeApp.Presentation
{
    public partial class BikeDetailForm : BaseForm
    {
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
            stationRtb.Text = string.Format("{0}\n{1}", stationName, stationAddress);
            qrCodeTxt.Text = bike.QRCode;
            manufactureTxt.Text = bike.Manufacturer;
            if (bike.BikeStatus)
            {
                statusBikeLbl.Text = "Renting";
                statusBikeLbl.BackColor = Color.Red;
            }
            else
            {
                statusBikeLbl.Text = "Availiable";
                statusBikeLbl.BackColor = Color.Green;
            }
            if (bike is Bike)
            {
                categoryBikeTxt.Text = "Xe đạp thường";
                powerTxt.Text = "Không có thông tin";
                licenceTxt.Text = "Không có thông tin";
                rentThisBikeBut.Tag = (bike.BikeId, Config.SQL.BikeCategory.BIKE);
            }
            else if (bike is Tandem)
            {
                categoryBikeTxt.Text = "Xe đạp đôi";
                powerTxt.Text = "Không có thông tin";
                licenceTxt.Text = "Không có thông tin";
                rentThisBikeBut.Tag = (bike.BikeId, Config.SQL.BikeCategory.TANDEM);
            }
            else
            {
                ElectricBike electric = bike as ElectricBike;
                categoryBikeTxt.Text = "Xe đạp điện";
                powerTxt.Text = $"{electric.Powers}%";
                licenceTxt.Text = electric.LicensePlate;
                rentThisBikeBut.Tag = (bike.BikeId, Config.SQL.BikeCategory.ELECTRIC);
            }
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void RentBikeBut_Click(object sender, EventArgs e)
        {
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
            homePageForm.RenderStationList(homePageForm.stationPnl);
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
            if(statusBikeLbl.BackColor == Color.Red)
            {
                MessageBox.Show("Xe đang được thuê, vui lòng chọn xe khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Button rentThisBikeBut = sender as Button;
            (int, Config.SQL.BikeCategory) bikeInfo = ((int, Config.SQL.BikeCategory))rentThisBikeBut.Tag;
            if(Config.RENT_BIKE_STATUS != Config.RENT_BIKE.RENTING_BIKE)
            {
                rentBikeForm.FillRentBikeInfoForm(bikeInfo);
                rentBikeForm.Show(this, Config.RENT_BIKE.RENT_BIKE_INFO, this);
            }
            else
            {
                rentBikeForm.FillRentingBikeForm();
                rentBikeForm.Show(this, Config.RENT_BIKE.RENTING_BIKE, this);
            }
            this.Hide();
        }
    }
}
