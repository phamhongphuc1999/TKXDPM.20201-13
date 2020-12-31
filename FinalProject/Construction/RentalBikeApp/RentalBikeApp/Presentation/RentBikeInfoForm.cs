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

using RentalBikeApp.Bussiness;
using RentalBikeApp.Entities.SQLEntities;
using System;
using static RentalBikeApp.Constant;
using static RentalBikeApp.Program;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with rent bike screen
    /// </summary>
    public partial class RentBikeInfoForm : BaseForm
    {
        private ViewBikeController viewBikeController;
        private BaseBike bike;

        /// <summary>
        /// contrructor of RentBikeInfoForm
        /// </summary>
        public RentBikeInfoForm(): base()
        {
            viewBikeController = new ViewBikeController();

            InitializeComponent("RentBikeInfoForm", "Rent Bike");
            DrawRentBikeInfoForm();
        }

        /// <summary>
        /// Fill bike information in rent bike form when rent bike status is RENT_BIKE_INFO
        /// </summary>
        /// <param name="bikeId">The bike id of specified bike</param>
        /// <param name="category">the bike category</param>
        public void FillRentBikeInfoForm(int bikeId, BikeCategory category)
        {
            rentBikeInfoPnl.Visible = true;
            bike = viewBikeController.ViewBikeDetail(bikeId);
            rentBikeInfoQrCodeTxt.Text = bike.QRCode;
            int deposit = bike.CalculateDeposit();
            if (category == BikeCategory.BIKE)
            {
                rentBikeInfoCategoryTxt.Text = "Xe đạp thường";
                rentBikeInfoLicenseTxt.Text = "Không có thông tin";
            }
            else if (category == BikeCategory.ELECTRIC)
            {
                ElectricBike electricBike = bike as ElectricBike;
                rentBikeInfoCategoryTxt.Text = "Xe đạp điện";
                rentBikeInfoLicenseTxt.Text = electricBike.LicensePlate;
            }
            else
            {
                rentBikeInfoCategoryTxt.Text = "Xe đạp đôi";
                rentBikeInfoLicenseTxt.Text = "Không có thông tin";
            }
            rentBikeInfoDepositTxt.Text = String.Format("{0:n0}", deposit);
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
            this.bike = viewBikeController.ViewBikeDetail(this.bike.BikeId);
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
