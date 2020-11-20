// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class StationDetailForm : BaseForm
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

        private StationService stationService;

        public StationDetailForm()
        {
            stationService = new StationService();

            InitializeComponent("StationDetailForm", "Station Detail");
            DrawBaseForm();
            DrawStationDetail();
            rentBikeBut.Click += RentBikeBut_Click;
            homePageBut.Click += HomePageBut_Click;
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

        private void HomePageBut_Click(object sender, System.EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        private void RentBikeBut_Click(object sender, System.EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void TandemBut_Click(object sender, System.EventArgs e)
        {
            Station station = stationService.GetStationById((int)tandemBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.TANDEM);
            listBikeForm.Show(this);
            this.Hide();
        }

        private void ElectricBut_Click(object sender, System.EventArgs e)
        {
            Station station = stationService.GetStationById((int)electricBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show(this);
            this.Hide();
        }

        private void BikeBut_Click(object sender, System.EventArgs e)
        {
            Station station = stationService.GetStationById((int)bikeBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.BIKE);
            listBikeForm.Show(this);
            this.Hide();
        }

        private void ReturnHomePageBut_Click(object sender, System.EventArgs e)
        {
            _homePageForm.Show(this);
            this.Hide();
        }
    }
}
