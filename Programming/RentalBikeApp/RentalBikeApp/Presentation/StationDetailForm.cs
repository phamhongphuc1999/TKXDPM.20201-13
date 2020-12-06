// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System;

namespace RentalBikeApp.Presentation
{
    public partial class StationDetailForm : BaseForm
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
        /// get or set the RentBikeForm representing the rent bike screen
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

        public StationDetailForm()
        {
            stationService = new StationService();

            InitializeComponent("StationDetailForm", "Station Detail");
            DrawBaseForm();
            DrawStationDetail();
            rentBikeBut.Click += RentBikeBut_Click;
            homePageBut.Click += HomePageBut_Click;
            prevFormBut.Click += PrevFormBut_Click;
        }

        /// <summary>
        /// Fill station information in StationDetailForm
        /// </summary>
        /// <param name="station">The station is displayed</param>
        public void FillStationDetail(Station station)
        {
            nameTxt.Text = station.NameStation;
            addressTxt.Text = station.AddressStation;
            areaTxt.Text = station.AreaStaion.ToString();
            numberTxt.Text = station.NumberOfBike.ToString();
            distanceTxt.Text = "100 m";
            timeTxt.Text = "10";

            bikeBut.Tag = station.StationId;
            electricBut.Tag = station.StationId;
            tandemBut.Tag = station.StationId;
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
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this, Config.RENT_BIKE_STATUS, this);
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

        /// <summary>
        /// Handle click event TandemBut, display the list of tandems in this station
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void TandemBut_Click(object sender, EventArgs e)
        {
            Station station = stationService.GetStationById((int)tandemBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.TANDEM);
            listBikeForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event ElectricBut, display the list of electric bikes in this station
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void ElectricBut_Click(object sender, EventArgs e)
        {
            Station station = stationService.GetStationById((int)electricBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event BikeBut, display list of normal bike in this station
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void BikeBut_Click(object sender, EventArgs e)
        {
            Station station = stationService.GetStationById((int)bikeBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.BIKE);
            listBikeForm.Show(this, this);
            this.Hide();
        }
    }
}
