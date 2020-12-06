// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using RentalBikeApp.Entities.SQLEntities;
using System;

namespace RentalBikeApp.Presentation
{
    public partial class CardInformationForm : BaseForm
    {
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

        private TransactionInformationForm _transactionInformationForm;
        /// <value>
        /// get or set the TransactionInformationForm representing the transaction information screen
        /// </value>
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
            prevFormBut.Click += PrevFormBut_Click;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrevFormBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.PrevForm.Show(this);
        }

        /// <summary>
        /// Handle click event SubmitBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void SubmitBut_Click(object sender, EventArgs e)
        {
            _transactionInformationForm.FillTransactionInformationWhenRentBike(new Card());
            _transactionInformationForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event CancelBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this, Config.RENT_BIKE.RENT_BIKE_INFO);
            this.Hide();
        }
    }
}
