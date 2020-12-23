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
using static RentalBikeApp.Config;
using static RentalBikeApp.Program;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Entities.APIEntities;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with transaction information screen
    /// </summary>
    public partial class TransactionInformationForm : BaseForm
    {
        private int deposit;
        private int rentalMoney;
        private int stationId;
        private int transactionId;

        /// <summary>
        /// contructor of TransactionInformationForm
        /// </summary>
        public TransactionInformationForm(): base()
        {
            InitializeComponent("TransactionInformationForm", "Transaction Information");
            DrawTransactionInformationForm();
        }

        private TRANSACTION_STATUS status;

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay rental money
        /// </summary>
        /// <param name="stationId">The return station id</param>
        public void FillTransactionInformationWhenPay(int stationId)
        {
            this.status = TRANSACTION_STATUS.PAY;
            this.stationId = stationId;
            remainMoneyTxt.Text = "111";
            transactionDateTxt.Text = DateTime.Now.ToString("f");
            cancelBut.Visible = false;

            Config.SQL.BikeCategory category = SQL.BikeCategory.BIKE;
            if (Config.RENTAL_BIKE is Bike) category = SQL.BikeCategory.BIKE;
            else if (Config.RENTAL_BIKE is ElectricBike) category = SQL.BikeCategory.ELECTRIC;
            else if (Config.RENTAL_BIKE is Tandem) category = SQL.BikeCategory.TANDEM;
            rentalMoney = returnBikeController.CalculateFee(Config.TIME_RENTAL_BIKE, category);
            rentalMoneyTxt.Text = (rentalMoney == 0) ? "Miễn phí" : rentalMoney.ToString();
        }

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay deposit money
        /// </summary>
        public void FillTransactionInformationWhenRentBike()
        {
            this.status = TRANSACTION_STATUS.RENT_BIKE;
            this.deposit = 40 * Config.RENTAL_BIKE.Value / 100;
            depositTxt.Text = String.Format("{0:n0}", this.deposit);
            rentalMoneyTxt.Text = "Không có dữ liệu";
            transactionDateTxt.Text = "Không có dữ liệu";
            cancelBut.Visible = true;
        }

        /// <summary>
        /// Handle click event PermitBut when process rent bike transaction
        /// </summary>
        private async void PermitButWhenRentBike()
        {
            Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENTING_BIKE;
            ProcessTransactionResponse result = await InterbankService.ProcessTransaction(Config.CARD_INFO, Config.API_INFO.COMMAND.PAY, this.deposit, DateTime.Now,
                noteTxt.Text == "" ? "Transaction content" : noteTxt.Text);
            string error = result.errorCode;
            if (error == "00")
            {
                Transaction transaction = rentBikeController.CreateDepositTransaction(1, Config.RENTAL_BIKE.QRCode, this.deposit);
                if (transaction == null)
                {
                    MessageBox.Show("Hệ thống không thể lưu thông tin giao dịch", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.transactionId = transaction.TransactionId;
                rentBikeForm.FillRentingBikeForm();
                rentBikeController.BeginRentingBike(Config.RENTAL_BIKE.BikeId);
                rentBikeForm.Show(this, Config.RENT_BIKE_STATUS);
            }
            else if (error == "01" || error == "02" || error == "05")
            {
                MessageBox.Show(API_INFO.ERROR_CODE[result.errorCode], "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cardInformationForm.Show(this);
            }
            else
            {
                MessageBox.Show(API_INFO.ERROR_CODE[result.errorCode], "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
        }

        /// <summary>
        /// Handle click event PermitBut when process pay rental money transaction
        /// </summary>
        private async void PermitButWhenPay()
        {
            Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENT_BIKE;
            ProcessTransactionResponse response = null;
            if (this.deposit < this.rentalMoney)
                response = await InterbankService.ProcessTransaction(Config.CARD_INFO, API_INFO.COMMAND.PAY, this.rentalMoney - this.deposit,
                    DateTime.Now, "Pay Rental Money");
            else if (this.deposit > this.rentalMoney)
                response = await InterbankService.ProcessTransaction(Config.CARD_INFO, API_INFO.COMMAND.REFUND, this.deposit - this.rentalMoney,
                    DateTime.Now, "Refund deposit");
            string error = response.errorCode;
            if (error == "00")
            {
                Transaction transaction = returnBikeController.UpdatePaymentTransaction(transactionId, this.rentalMoney);
                returnBikeController.UpdateStationAfterReturnbike(this.stationId, RENTAL_BIKE_CATEGORY);
                MessageBox.Show("giao dịch thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                homePageForm.Show(this);
            }
            this.Hide();
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void RentBikeBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.Show(this, this);
            this.Show();
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void HomePageBut_Click(object sender, EventArgs e)
        {
            homePageForm.RenderStationList(homePageForm.stationPnl);
            homePageForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Handle click event PermitBut, send pay or refund transaction end handle the response
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void PermitBut_Click(object sender, EventArgs e)
        {
            if (status == TRANSACTION_STATUS.RENT_BIKE) PermitButWhenRentBike();
            else if (status == TRANSACTION_STATUS.PAY) PermitButWhenPay();
        }

        /// <summary>
        /// Handle click event Cancelbut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelBut_Click(object sender, EventArgs e)
        {
            cardInformationForm.Show(this);
            this.Hide();
        }
    }
}
