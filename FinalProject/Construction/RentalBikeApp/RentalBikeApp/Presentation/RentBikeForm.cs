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
using static RentalBikeApp.Constant.SQL;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Bussiness;
using System.Drawing;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with rent bike screen
    /// </summary>
    public partial class RentBikeForm : BaseForm
    {
        private BikeCategory category;
        private BaseBike bike;

        private BikeStationController bikeStationController;
        private RentBikeController rentBikeController;

        /// <summary>
        /// contructor of RentBikeForm
        /// </summary>
        public RentBikeForm(): base()
        {
            bikeStationController = new BikeStationController();
            rentBikeController = new RentBikeController();

            InitializeComponent("RentBikeForm", "Rent Bike");
            DrawRentBikeInfoForm();
            DrawRentingBikeForm();
            DrawRentBikeForm();
        }

        /// <summary>
        /// start timer
        /// </summary>
        public void StartTimer()
        {
            if(!rentBikeTmr.Enabled) rentBikeTmr.Start();
        }

        /// <summary>
        /// stop timer
        /// </summary>
        public void StopTimer()
        {
            if(rentBikeTmr.Enabled) rentBikeTmr.Stop();
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
        public void FillRentingBikeForm(BaseBike bike = null)
        {
            if (bike == null) bike = this.bike;
            else this.bike = bike;
            this.StartTimer();
            rentBikePnl.Visible = false;
            rentingBikePnl.Visible = true;
            rentBikeInfoPnl.Visible = false;
            if (bike.DateRent != null)
                rentingTimedRentValueLbl.Text = Utilities.SubtractDate(DateTime.Now, (DateTime)bike.DateRent);
            else rentingTimedRentValueLbl.Text = "0:00:00";
            rentingQrCodeTxt.Text = bike.QRCode;
            rentingAvatarPb.Image = Image.FromFile(bike.Images);
            if(bike is Bike)
            {
                rentingCategoryTxt.Text = "Xe đạp thường";
                rentingRemainPowerValueLbl.Text = "Không có thông tin";
                rentingLicenseTxt.Text = "Không có thông tin";
            }
            else if(bike is ElectricBike)
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
        /// Fill bike information in rent bike form when rent bike status is RENT_BIKE_INFO
        /// </summary>
        /// <param name="bikeId">The bike id of specified bike</param>
        /// <param name="category">the bike category</param>
        public void FillRentBikeInfoForm(int bikeId, Constant.SQL.BikeCategory category)
        {
            rentBikePnl.Visible = false;
            rentingBikePnl.Visible = false;
            rentBikeInfoPnl.Visible = true;
            bike = bikeStationController.ViewBikeDetail(bikeId, category);
            this.category = category;
            rentBikeInfoQrCodeTxt.Text = bike.QRCode;
            int deposit = 40 * bike.Value / 100;
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
        /// display screen to user fill rental bike qrcode
        /// </summary>
        public void DisplayRentbikeQrcode()
        {
            rentBikePnl.Visible = true;
            rentingBikePnl.Visible = false;
            rentBikeInfoPnl.Visible = false;
            rentBikeQrCodeTxt.Text = "";
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
            DisplayRentbikeQrcode();
        }

        #region Rent bike handle event
        /// <summary>
        /// Handle click event RentBikeRentBut, if user enter correct or code, display detail information of bike have this qr code
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeRentBut_Click(object sender, EventArgs e)
        {
            string qrCode = rentBikeQrCodeTxt.Text;
            if (qrCode == "")
            {
                MessageBox.Show("Nhập mã xe bạn muốn tìm kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Utilities.InvlidString(Constant.QRValid, qrCode))
            {
                MessageBox.Show($"QRCode không hợp lệ\nQRCode là dãy số có chín chữ số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            string stationName = "", stationAddress = "";
            BaseBike bike = rentBikeController.SubmitQrCode(qrCode, ref stationName, ref stationAddress);
            if (bike == null)
            {
                MessageBox.Show($"Không tìm thấy xe có mã qr code {qrCode}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            if (bike.BikeStatus)
            {
                MessageBox.Show($"Xe đang được thuê, vui lòng chọn xe khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            bikeDetailForm.FillBikeInformation(bike, stationName, stationAddress);
            bikeDetailForm.Show(this);
            this.Hide();
        }
        #endregion

        #region Rent bike information handle event
        /// <summary>
        /// Handle click event RentBikeInfoRentThisBikeBut, display CardInformationForm
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeInfoRentThisBikeBut_Click(object sender, EventArgs e)
        {
            this.bike = bikeStationController.ViewBikeDetail(this.bike.BikeId, this.category);
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
        #endregion

        #region Renting bike handle event
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
        #endregion
    }
}
