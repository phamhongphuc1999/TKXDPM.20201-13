// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.Windows.Forms;
using static RentalBikeApp.Config;
using RentalBikeApp.Entities.SQLEntities;

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

        private CardInformationForm _cardInformationForm;
        public CardInformationForm cardInformationForm
        {
            get { return _cardInformationForm; }
            set { _cardInformationForm = value; }
        }

        public TransactionInformationForm()
        {
            InitializeComponent("TransactionInformationForm", "Transaction Information");
            DrawBaseForm();
            DrawTransactionInformationForm();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        private TRANSACTION_STATUS status;

        /// <summary>
        /// 
        /// </summary>
        public void FillTransactionInformationWhenPay()
        {
            this.status = TRANSACTION_STATUS.PAY;
            remainMoneyTxt.Text = "111";
            transactionDateTxt.Text = Utilities.ConvertDateToString(DateTime.Now);
            cancelBut.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bikeId"></param>
        /// <param name="card"></param>
        public void FillTransactionInformationWhenRentBike(int bikeId, Card card)
        {
            this.status = TRANSACTION_STATUS.RENT_BIKE;
            depositTxt.Text = "111";
            rentalMoneyTxt.Text = "111";
            remainMoneyTxt.Text = "Không có dữ liệu";
            transactionDateTxt.Text = "Không có dữ liệu";
            permitBut.Tag = bikeId;
            cancelBut.Visible = true;
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show();
            this.Show();
        }

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show();
            this.Hide();
        }

        private void PermitBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (status == TRANSACTION_STATUS.RENT_BIKE)
            {
                Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENTING_BIKE;
                _rentBikeForm.FillRentBikeForm((int)but.Tag, Config.RENT_BIKE_STATUS);
                _rentBikeForm.rentBikeTmr.Start();
                _rentBikeForm.Show(this, Config.RENT_BIKE_STATUS);
            }
            else if (status == TRANSACTION_STATUS.PAY)
            {
                Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENT_BIKE;
                MessageBox.Show("Thanh toán tiền thuê xe thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _homePageForm.RenderStationList(_homePageForm.stationPnl);
                _homePageForm.Show(this);
            }
            this.Hide();
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            _cardInformationForm.Show(this);
            this.Hide();
        }
    }
}
