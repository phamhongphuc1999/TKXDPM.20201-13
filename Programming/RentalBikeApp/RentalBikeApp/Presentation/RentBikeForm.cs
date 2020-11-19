// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;

namespace RentalBikeApp.Presentation
{
    public partial class RentBikeForm : BaseForm
    {
        private HomePageForm _homePageForm;
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        public RentBikeForm()
        {
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
    }
}
