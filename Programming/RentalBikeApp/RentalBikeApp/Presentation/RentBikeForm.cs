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
using RentalBikeApp.Services.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class RentBikeForm : BaseForm
    {
        private BikeService bikeService;
        private TandemService tandemService;
        private ElectricBikeService electricBikeService;

        public RentBikeForm()
        {
            bikeService = new BikeService();
            tandemService = new TandemService();
            electricBikeService = new ElectricBikeService();

            InitializeComponent("RentBikeForm", "Rent Bike");
            DrawBaseForm();
            DrawRentBikeInfoForm();
            DrawRentingBikeForm();
            DrawRentBikeForm();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
            prevFormBut.Click += PrevFormBut_Click;

            Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENT_BIKE;
            DisplayRentBike(Config.RENT_BIKE_STATUS);
        }

        /// <summary>
        /// Display rent bike form base on specified rent bike status
        /// </summary>
        /// <param name="rentBike">The specified rent bike status</param>
        private void DisplayRentBike(Config.RENT_BIKE rentBike)
        {
            if(rentBike == Config.RENT_BIKE.RENT_BIKE)
            {
                rentBikePnl.Visible = true;
                rentingBikePnl.Visible = false;
                rentBikeInfoPnl.Visible = false;
                rentBikeQrCodeTxt.Text = "";
            }
            else if(rentBike == Config.RENT_BIKE.RENTING_BIKE)
            {
                rentBikePnl.Visible = false;
                rentingBikePnl.Visible = true;
                rentBikeInfoPnl.Visible = false;
            }
            else
            {
                rentBikePnl.Visible = false;
                rentingBikePnl.Visible = false;
                rentBikeInfoPnl.Visible = true;
            }
        }

        /// <summary>
        /// Show rent bike form base on specified rent bike status and specified form's location
        /// </summary>
        /// <param name="form">The specified form</param>
        /// <param name="rentBike">The specified rent bike status</param>
        public void Show(Form form, Config.RENT_BIKE rentBike, BaseForm prevForm = null)
        {
            DisplayRentBike(rentBike);
            this.Show(form, prevForm);
        }

        /// <summary>
        /// Fill bike information in rent bike form when rent bike status is RENTING_BIKE
        /// </summary>
        /// <param name="bikeId">The bike id of specified bike</param>
        public void FillRentingBikeForm()
        {
            BaseBike bike = Config.RENTAL_BIKE;
            rentingQrCodeTxt.Text = bike.QRCode;
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
                rentingRemainPowerValueLbl.Text = $"${electricBike.Powers}%";
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
        public void FillRentBikeInfoForm((int, Config.SQL.BikeCategory) bikeInfo)
        {
            BaseBike bike;
            if (bikeInfo.Item2 == Config.SQL.BikeCategory.BIKE) bike = bikeService.GetBikeById(bikeInfo.Item1);
            else if (bikeInfo.Item2 == Config.SQL.BikeCategory.ELECTRIC) bike = electricBikeService.GetBikeById(bikeInfo.Item1);
            else bike = tandemService.GetBikeById(bikeInfo.Item1);
            rentBikeInfoQrCodeTxt.Text = bike.QRCode;
            int deposit = 40 * bike.Value / 100;
            if (bikeInfo.Item2 == Config.SQL.BikeCategory.BIKE)
            {
                rentBikeInfoCategoryTxt.Text = "Xe đạp thường";
                rentBikeInfoLicenseTxt.Text = "Không có thông tin";
            }
            else if (bikeInfo.Item2 == Config.SQL.BikeCategory.ELECTRIC)
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
            rentBikeInfoDetailBut.Tag = bikeInfo;
            rentBikeInfoRentThisBikeBut.Tag = bikeInfo;
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void HomePageBut_Click(object sender, EventArgs e)
        {
            homePageForm.RenderStationList(homePageForm.stationPnl);
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event PrevFormBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void PrevFormBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.PrevForm.Show(this);
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
                MessageBox.Show("Nhập mã qr code của xe muốn thuê");
                return;
            }
            BaseBike bike;
            if (qrCode[0] == '0') bike = bikeService.GetBikeByQRCode(qrCode);
            else if (qrCode[0] == '1') bike = tandemService.GetBikeByQRCode(qrCode);
            else bike = electricBikeService.GetBikeByQRCode(qrCode);
            if (bike == null)
            {
                MessageBox.Show("QrCode không hợp lệ");
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            bikeDetailForm.FillBikeInformation(bike);
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
            Button but = sender as Button;
            (int, Config.SQL.BikeCategory) bikeInfo = ((int, Config.SQL.BikeCategory))but.Tag;
            if (bikeInfo.Item2 == Config.SQL.BikeCategory.BIKE)
                Config.RENTAL_BIKE = bikeService.GetBikeById(bikeInfo.Item1);
            else if (bikeInfo.Item2 == Config.SQL.BikeCategory.ELECTRIC)
                Config.RENTAL_BIKE = electricBikeService.GetBikeById(bikeInfo.Item1);
            else Config.RENTAL_BIKE = tandemService.GetBikeById(bikeInfo.Item1);
            cardInformationForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event RentBikeInfoDetailBut, display detail information of bike
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeInfoDetailBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            (int, Config.SQL.BikeCategory) bikeInfo = ((int, Config.SQL.BikeCategory))but.Tag;
            BaseBike bike;
            if (bikeInfo.Item2 == Config.SQL.BikeCategory.BIKE)
                bike = bikeService.GetBikeById(bikeInfo.Item1);
            else if (bikeInfo.Item2 == Config.SQL.BikeCategory.ELECTRIC)
                bike = electricBikeService.GetBikeById(bikeInfo.Item1);
            else bike = tandemService.GetBikeById(bikeInfo.Item1);
            bikeDetailForm.FillBikeInformation(bike);
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
            Config.TIME_RENTAL_BIKE = String.Format("{0}:{1}:{2}", hour, minute.ToString("D2"), second.ToString("D2"));
            rentingTimedRentValueLbl.Text = Config.TIME_RENTAL_BIKE;
        }

        /// <summary>
        /// Handle click event RentingSelectReceiveStationBut, display ReturnBikeForm
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentingSelectReceiveStationBut_Click(object sender, EventArgs e)
        {
            returnBikeForm.Show(this);
            this.Hide();
        }
        #endregion
    }
}
