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
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class BikeDetailForm : BaseForm
    {
        private StationService stationService;

        private HomePageForm _homePageForm;
        /// <value>
        /// get or set the HomePageForm representing the home page screen
        /// </value>
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        private RentBikeForm _rentBikeForm;
        /// <value>
        /// get or set the RentBikeForm representing the rent bike form
        /// </value>
        public RentBikeForm rentBikeForm
        {
            get { return _rentBikeForm; }
            set { _rentBikeForm = value; }
        }

        private ListBikeForm _listBikeForm;
        /// <value>
        /// get or set the ListBikeForm representing the list bike screen
        /// </value>
        public ListBikeForm listBikeForm
        {
            get { return _listBikeForm; }
            set { _listBikeForm = value; }
        }

        public BikeDetailForm()
        {
            stationService = new StationService();

            InitializeComponent("BikeDetailForm", "Bike Detail");
            DrawBaseForm();
            DrawBikeDetail();

            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
            prevFormBut.Click += PrevFormBut_Click;
        }

        /// <summary>
        /// Fill bike form with bike's information and station's information
        /// </summary>
        /// <param name="bike">The specified bike</param>
        public void FillBikeInformation(BaseBike bike)
        {
            Station station = stationService.GetStationById(bike.StationId);
            stationRtb.Text = string.Format("{0}\n{1}", station.NameStation, station.AddressStation);
            qrCodeTxt.Text = bike.QRCode;
            manufactureTxt.Text = bike.Manufacturer;
            if(bike is Bike)
            {
                categoryBikeTxt.Text = "Xe đạp thường";
                powerTxt.Text = "Không có thông tin";
                licenceTxt.Text = "Không có thông tin";
                rentThisBikeBut.Tag = (bike.BikeId, Config.SQL.BikeCategory.BIKE);
            }
            else if(bike is Tandem)
            {
                Tandem tandem = bike as Tandem;
                categoryBikeTxt.Text = "Xe đạp đôi";
                powerTxt.Text = "Không có thông tin";
                licenceTxt.Text = tandem.LicensePlate;
                rentThisBikeBut.Tag = (bike.BikeId, Config.SQL.BikeCategory.TANDEM);
            }
            else
            {
                ElectricBike electric = bike as ElectricBike;
                categoryBikeTxt.Text = "Xe đạp điện";
                powerTxt.Text = $"{electric.Powers}%";
                licenceTxt.Text = "Không có thông tin";
                rentThisBikeBut.Tag = (bike.BikeId, Config.SQL.BikeCategory.ELECTRIC);
            }
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
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
            this.PrevForm.Show(this, this);
        }

        /// <summary>
        /// Handle click event RentThisBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentThisBikeBut_Click(object sender, EventArgs e)
        {
            Button rentThisBikeBut = sender as Button;
            (int, Config.SQL.BikeCategory) bikeInfo = ((int, Config.SQL.BikeCategory))rentThisBikeBut.Tag;
            if(Config.RENT_BIKE_STATUS != Config.RENT_BIKE.RENTING_BIKE)
            {
                _rentBikeForm.FillRentBikeInfoForm(bikeInfo);
                _rentBikeForm.Show(this, Config.RENT_BIKE.RENT_BIKE_INFO);
            }
            else
            {
                _rentBikeForm.FillRentingBikeForm();
                _rentBikeForm.Show(this, Config.RENT_BIKE.RENTING_BIKE);
            }
            this.Hide();
        }
    }
}
