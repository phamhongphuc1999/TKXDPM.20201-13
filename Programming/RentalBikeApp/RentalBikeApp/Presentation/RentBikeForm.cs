// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Windows.Forms;

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

            DisplayRentBike();
        }

        public void DisplayRentBike()
        {
            if(Config.RENT_BIKE_STATUS == Config.RENT_BIKE.RENT_BIKE)
            {
                rentBikePnl.Visible = true;
                rentingBikePnl.Visible = false;
                rentBikeInfoPnl.Visible = false;
            }
            else if(Config.RENT_BIKE_STATUS == Config.RENT_BIKE.RENTING_BIKE)
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

        public void FillRentBikeForm()
        {

        }

        public void FillRentingBikeForm()
        {

        }

        public void FillRentBikeInfoForm()
        {

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

        private void RentBikeRentBut_Click(object sender, EventArgs e)
        {
            string qrCode = rentBikeQrCodeTxt.Text;
            if(qrCode == "")
            {
                MessageBox.Show("Nhập mã qr code của xe muốn thuê");
                return;
            }
            Bike bike = bikeService.GetBikeByQRCode(qrCode);
            if(bike == null)
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
    }
}
