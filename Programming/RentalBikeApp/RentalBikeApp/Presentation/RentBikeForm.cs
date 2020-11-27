// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.Windows.Forms;
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class RentBikeForm : BaseForm
    {
        private BikeService bikeService;
        private StationService stationService;

        private HomePageForm _homePageForm;
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        private BikeDetailForm _bikeDetailForm;
        public BikeDetailForm bikeDetailForm
        {
            get { return _bikeDetailForm; }
            set { _bikeDetailForm = value; }
        }

        private CardInformationForm _cardInformationForm;
        public CardInformationForm cardInformationForm
        {
            get { return _cardInformationForm; }
            set { _cardInformationForm = value; }
        }

        private ReturnBikeForm _returnBikeForm;
        public ReturnBikeForm returnBikeForm
        {
            get { return _returnBikeForm; }
            set { _returnBikeForm = value; }
        }

        public RentBikeForm()
        {
            bikeService = new BikeService();
            stationService = new StationService();

            InitializeComponent("RentBikeForm", "Rent Bike");
            DrawBaseForm();
            DrawRentBikeInfoForm();
            DrawRentingBikeForm();
            DrawRentBikeForm();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;

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
        public void Show(Form form, Config.RENT_BIKE rentBike)
        {
            DisplayRentBike(rentBike);
            this.Show(form);
        }

        /// <summary>
        /// Fill bike information in rent bike form when rent bike status is RENTING_BIKE
        /// </summary>
        /// <param name="bikeId">The bike id of specified bike</param>
        private void FillRentingBikeForm(int bikeId)
        {
            Bike bike = bikeService.GetBikeById(bikeId);
            rentingQrCodeTxt.Text = bike.QRCode;
            rentingCategoryTxt.Text = Config.BIKE_CATEGORY[bike.Category];
            if (bike.Category != "electric") rentingRemainPowerValueLbl.Text = "Không có thông tin";
            else rentingRemainPowerValueLbl.Text = "100%";
            rentingLicenseTxt.Text = (bike.LicensePlate == "") ? "Không có thông tin" : bike.LicensePlate;
            rentingManufactureTxt.Text = bike.Manufacturer;
        }

        /// <summary>
        /// Fill bike information in rent bike form when rent bike status is RENT_BIKE_INFO
        /// </summary>
        /// <param name="bikeId">The bike id of specified bike</param>
        private void FillRentBikeInfoForm(int bikeId)
        {
            Bike bike = bikeService.GetBikeById(bikeId);
            rentBikeInfoQrCodeTxt.Text = bike.QRCode;
            rentBikeInfoCategoryTxt.Text = Config.BIKE_CATEGORY[bike.Category];
            rentBikeInfoLicenseTxt.Text = (bike.LicensePlate == "") ? "Không có thông tin" : bike.LicensePlate;
            rentBikeInfoDepositTxt.Text = "1000";
            rentBikeInfoDetailBut.Tag = bike.BikeId;
            rentBikeInfoRentThisBikeBut.Tag = bike.BikeId;
        }

        /// <summary>
        /// Fill bike information in rent bike form base on specified rent bike status
        /// </summary>
        /// <param name="bikeId">The bike id of specified bike</param>
        /// <param name="rentBike">The specified rent bike status</param>
        public void FillRentBikeForm(int bikeId, Config.RENT_BIKE rentBike)
        {
            if (rentBike == Config.RENT_BIKE.RENTING_BIKE) FillRentingBikeForm(bikeId);
            else if (rentBike == Config.RENT_BIKE.RENT_BIKE_INFO) FillRentBikeInfoForm(bikeId);
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
        }

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        #region Rent bike handle event
        private void RentBikeRentBut_Click(object sender, EventArgs e)
        {
            string qrCode = rentBikeQrCodeTxt.Text;
            if (qrCode == "")
            {
                MessageBox.Show("Nhập mã qr code của xe muốn thuê");
                return;
            }
            Bike bike = bikeService.GetBikeByQRCode(qrCode);
            if (bike == null)
            {
                MessageBox.Show("QrCode không hợp lệ");
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            Station station = stationService.GetStationById(bike.StationId);
            _bikeDetailForm.FillBikeInformation(station, bike);
            _bikeDetailForm.Show(this);
            this.Hide();
        }
        #endregion

        #region Rent bike information handle event
        private void RentBikeInfoRentThisBikeBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            cardInformationForm.submitBut.Tag = but.Tag;
            cardInformationForm.Show(this);
            this.Hide();
        }

        private void RentBikeInfoDetailBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Bike bike = bikeService.GetBikeById((int)but.Tag);
            Station station = stationService.GetStationById(bike.StationId);
            bikeDetailForm.FillBikeInformation(station, bike);
            bikeDetailForm.Show(this);
            this.Hide();
        }
        #endregion

        #region Renting bike handle event
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

        private void RentingSelectReceiveStationBut_Click(object sender, EventArgs e)
        {
            _returnBikeForm.Show(this);
            this.Hide();
        }
        #endregion
    }
}
