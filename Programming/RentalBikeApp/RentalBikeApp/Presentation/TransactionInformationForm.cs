// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class TransactionInformationForm : BaseForm
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

        public void FillTransactionInformation(int bikeId, Card card)
        {
            depositTxt.Text = "111";
            rentalMoneyTxt.Text = "111";
            remainMoneyTxt.Text = "111";
            transactionDateTxt.Text = Utilities.ConvertDateToString(DateTime.Now);
            permitBut.Tag = bikeId;
        }

        public TransactionInformationForm()
        {
            InitializeComponent("TransactionInformationForm", "Transaction Information");
            DrawBaseForm();
            DrawTransactionInformationForm();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        private void RentBikeBut_Click(object sender, System.EventArgs e)
        {
            _rentBikeForm.Show();
            this.Show();
        }

        private void HomePageBut_Click(object sender, System.EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show();
            this.Hide();
        }

        private void PermitBut_Click(object sender, System.EventArgs e)
        {
            Button but = sender as Button;
            Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENTING_BIKE;
            _rentBikeForm.FillRentBikeForm((int)but.Tag, Config.RENT_BIKE_STATUS);
            _rentBikeForm.rentBikeTmr.Start();
            _rentBikeForm.Show(this, Config.RENT_BIKE_STATUS);
            this.Hide();
        }
    }
}
