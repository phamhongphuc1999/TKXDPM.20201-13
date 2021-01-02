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
using RentalBikeApp.Entities.SQLEntities;
using static RentalBikeApp.Program;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with rent bike screen
    /// </summary>
    public partial class RentBikeInfoForm : BaseForm
    {
        private BaseBike bike;

        /// <summary>
        /// contrructor of RentBikeInfoForm
        /// </summary>
        public RentBikeInfoForm(): base()
        {
            InitializeComponent("RentBikeInfoForm", "Rent Bike");
            DrawRentBikeInfoForm();
        }

        private void FillInfo(BaseBike bike)
        {
            rentBikeInfoPnl.Visible = true;
            this.bike = bike;
            rentBikeInfoQrCodeTxt.Text = bike.QRCode;
            int deposit = bike.CalculateDeposit();
            rentBikeInfoDepositTxt.Text = String.Format("{0:n0}", deposit);
        }

        /// <summary>
        /// Fill bike information in rent bike
        /// </summary>
        /// <param name="bike">The bike id of specified bike</param>
        public void FillRentBikeInfoForm(BaseBike bike)
        {
            FillInfo(bike);
            rentBikeInfoCategoryTxt.Text = "Xe đạp thường";
            rentBikeInfoLicenseTxt.Text = "Không có thông tin";
        }

        /// <summary>
        /// Fill bike information in rent bike
        /// </summary>
        /// <param name="bike">The bike id of specified bike</param>
        public void FillRentTandemInfoForm(BaseBike bike)
        {
            FillInfo(bike);
            rentBikeInfoCategoryTxt.Text = "Xe đạp đôi";
            rentBikeInfoLicenseTxt.Text = "Không có thông tin";
        }

        /// <summary>
        /// Fill bike information in rent bike
        /// </summary>
        /// <param name="bike">The bike id of specified bike</param>
        public void FillRentElectricInfoForm(BaseBike bike)
        {
            FillInfo(bike);
            ElectricBike electricBike = bike as ElectricBike;
            rentBikeInfoCategoryTxt.Text = "Xe đạp điện";
            rentBikeInfoLicenseTxt.Text = electricBike.LicensePlate;
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
        /// Handle click event RentBikeInfoRentThisBikeBut, display CardInformationForm
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeInfoRentThisBikeBut_Click(object sender, EventArgs e)
        {
            cardInformationForm.Show(this, this);
            cardInformationForm.FillCardInformation(bike);
            this.Hide();
        }

        /// <summary>
        /// Handle click event RentBikeInfoDetailBut, display detail information of bike
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeInfoDetailBut_Click(object sender, EventArgs e)
        {
            bikeDetailForm.Show(this);
            this.Hide();
        }
    }
}
