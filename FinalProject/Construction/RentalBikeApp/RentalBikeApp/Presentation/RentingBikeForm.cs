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
using System.Drawing;
using static RentalBikeApp.Program;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with rent bike screen
    /// </summary>
    public partial class RentingBikeForm : BaseForm
    {
        private RentBikeController rentBikeController;
        private BaseBike bike;

        /// <summary>
        /// contructor of RentingBikeForm
        /// </summary>
        public RentingBikeForm(): base()
        {
            rentBikeController = new RentBikeController();

            InitializeComponent("RentingBikeForm", "Rent Bike");
            DrawRentingBikeForm();
        }

        /// <summary>
        /// start timer
        /// </summary>
        public void StartTimer()
        {
            if (!rentBikeTmr.Enabled) rentBikeTmr.Start();
        }

        /// <summary>
        /// stop timer
        /// </summary>
        public void StopTimer()
        {
            if (rentBikeTmr.Enabled) rentBikeTmr.Stop();
        }

        /// <summary>
        /// Get total time rent
        /// </summary>
        /// <returns>The string representing total time rent</returns>
        public string GetTotalTimeRent()
        {
            return rentingTimedRentValueLbl.Text;
        }

        /// <summary>
        /// Fill bike information in rent bike form when rent bike status is RENTING_BIKE
        /// </summary>
        /// <param name="bike">the rental bike information</param>
        public void FillRentingBikeForm(BaseBike bike)
        {
            this.bike = bike;
            this.StartTimer();
            rentingBikePnl.Visible = true;
            DateTime begin = rentBikeController.GetBeginDate(this.bike.BikeId);
            rentingTimedRentValueLbl.Text = Utilities.SubtractDate(DateTime.Now, begin);
            rentingQrCodeTxt.Text = bike.QRCode;
            rentingAvatarPb.Image = Image.FromFile(bike.Images);
            if (bike is Bike)
            {
                rentingCategoryTxt.Text = "Xe đạp thường";
                rentingRemainPowerValueLbl.Text = "Không có thông tin";
                rentingLicenseTxt.Text = "Không có thông tin";
            }
            else if (bike is ElectricBike)
            {
                ElectricBike electricBike = bike as ElectricBike;
                rentingCategoryTxt.Text = "Xe đạp điện";
                rentingRemainPowerValueLbl.Text = $"{electricBike.Powers}%";
                rentingLicenseTxt.Text = electricBike.LicensePlate;
            }
            else
            {
                rentingCategoryTxt.Text = "Xe đạp đôi";
                rentingRemainPowerValueLbl.Text = "Không có thông tin";
                rentingLicenseTxt.Text = "Không có thông tin";
            }
            rentingManufactureTxt.Text = bike.Manufacturer;
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
        /// Handle tick event of timer, count the rental time
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeTmr_Tick(object sender, EventArgs e)
        {
            string[] times = rentingTimedRentValueLbl.Text.Split(':');
            int second = Int32.Parse(times[2]);
            int minute = Int32.Parse(times[1]);
            int hour = Int32.Parse(times[0]);
            second += 1;
            minute += (second / 60);
            second = second % 60;
            hour += (minute / 60);
            minute = minute % 60;
            rentingTimedRentValueLbl.Text = String.Format("{0}:{1}:{2}", hour, minute.ToString("D2"), second.ToString("D2"));
        }

        /// <summary>
        /// Handle click event RentingSelectReceiveStationBut, display ReturnBikeForm
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentingSelectReceiveStationBut_Click(object sender, EventArgs e)
        {
            returnBikeForm.ReadRentalBike(this.bike);
            returnBikeForm.Show(this, this);
            this.Hide();
        }
    }
}
