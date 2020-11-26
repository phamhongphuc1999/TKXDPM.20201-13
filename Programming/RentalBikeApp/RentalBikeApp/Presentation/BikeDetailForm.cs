// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.Windows.Forms;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class BikeDetailForm : BaseForm
    {
        private HomePageForm _homePageForm;
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        private RentBikeForm _rentBikeForm;
        public RentBikeForm rentBikeForm
        {
            get { return _rentBikeForm; }
            set { _rentBikeForm = value; }
        }

        private ListBikeForm _listBikeForm;
        public ListBikeForm listBikeForm
        {
            get { return _listBikeForm; }
            set { _listBikeForm = value; }
        }

        public BikeDetailForm()
        {
            InitializeComponent("BikeDetailForm", "Bike Detail");
            DrawBaseForm();
            DrawBikeDetail();

            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        /// <summary>
        /// Fill bike form with bike's information and station's information
        /// </summary>
        /// <param name="station">The station contain the specified bike</param>
        /// <param name="bike">The specified bike</param>
        public void FillBikeInformation(Station station, Bike bike)
        {
            stationRtb.Text = string.Format("{0}\n{1}", station.NameStation, station.AddressStation);
            qrCodeTxt.Text = bike.QRCode;
            manufactureTxt.Text = bike.Manufacturer;
            categoryBikeTxt.Text = Config.BIKE_CATEGORY[bike.Category];
            powerTxt.Text = (bike.Category == "electric") ? "100%" : "Không có thông tin";
            licenceTxt.Text = (bike.LicensePlate == "") ? "Không có thông tin" : bike.LicensePlate;
            rentThisBikeBut.Tag = bike.BikeId;
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        private void RentThisBikeBut_Click(object sender, EventArgs e)
        {
            Button rentThisBikeBut = sender as Button;
            int bikeId = (int)rentThisBikeBut.Tag;
            if(Config.RENT_BIKE_STATUS != Config.RENT_BIKE.RENTING_BIKE)
            {
                _rentBikeForm.FillRentBikeForm(bikeId, Config.RENT_BIKE.RENT_BIKE_INFO);
                _rentBikeForm.Show(this, Config.RENT_BIKE.RENT_BIKE_INFO);
            }
            else
            {
                _rentBikeForm.FillRentBikeForm(bikeId, Config.RENT_BIKE.RENTING_BIKE);
                _rentBikeForm.Show(this, Config.RENT_BIKE.RENTING_BIKE);
            }
            this.Hide();
        }

        private void ReturnListBikeBut_Click(object sender, EventArgs e)
        {
            _listBikeForm.Show(this);
            this.Hide();
        }
    }
}
