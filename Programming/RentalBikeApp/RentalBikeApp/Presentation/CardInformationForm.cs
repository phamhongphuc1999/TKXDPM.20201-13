// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class CardInformationForm : BaseForm
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

        private TransactionInformationForm _transactionInformationForm;
        public TransactionInformationForm transactionInformationForm
        {
            get { return _transactionInformationForm; }
            set { _transactionInformationForm = value; }
        }

        public CardInformationForm()
        {
            InitializeComponent("CardInformationForm", "Card Information");
            DrawBaseForm();
            DrawCardInformation();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        private void RentBikeBut_Click(object sender, System.EventArgs e)
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

        private void SubmitBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            _transactionInformationForm.FillTransactionInformation((int)but.Tag, new Card());
            _transactionInformationForm.Show(this);
            this.Hide();
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this, Config.RENT_BIKE.RENT_BIKE_INFO);
            this.Hide();
        }
    }
}
