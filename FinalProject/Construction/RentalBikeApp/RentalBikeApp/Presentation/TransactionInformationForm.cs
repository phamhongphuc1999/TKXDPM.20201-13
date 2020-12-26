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
using RentalBikeApp.Bussiness;

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
        private BaseBike bike;
        private Card card;
        private TRANSACTION_STATUS status;
        private RentBikeController rentBikeController;
        private ReturnBikeController returnBikeController;

        /// <summary>
        /// contructor of TransactionInformationForm
        /// </summary>
        public TransactionInformationForm(): base()
        {
            rentBikeController = new RentBikeController();
            returnBikeController = new ReturnBikeController();

            InitializeComponent("TransactionInformationForm", "Transaction Information");
            DrawTransactionInformationForm();
        }

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay rental money
        /// </summary>
        /// <param name="stationId">The return station id</param>
        /// <param name="bike">The rental need to return</param>
        public void FillTransactionInformationWhenPay(int stationId, BaseBike bike)
        {
            this.bike = bike;
            this.status = TRANSACTION_STATUS.PAY;
            this.stationId = stationId;
            remainMoneyTxt.Text = "111";
            transactionDateTxt.Text = DateTime.Now.ToString("f");
            cancelBut.Visible = false;

            SQL.BikeCategory category = SQL.BikeCategory.BIKE;
            if (bike is Bike) category = SQL.BikeCategory.BIKE;
            else if (bike is ElectricBike) category = SQL.BikeCategory.ELECTRIC;
            else if (bike is Tandem) category = SQL.BikeCategory.TANDEM;
            rentalMoney = returnBikeController.CalculateFee(rentBikeForm.GetTotalTimeRent(), category);
            rentalMoneyTxt.Text = (rentalMoney == 0) ? "Miễn phí" : rentalMoney.ToString();
        }

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay deposit money
        /// </summary>
        public void FillTransactionInformationWhenRentBike(BaseBike bike, Card card)
        {
            this.bike = bike;
            this.card = card;
            this.status = TRANSACTION_STATUS.RENT_BIKE;
            this.deposit = 40 * bike.Value / 100;
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
            ProcessTransactionResponse result = await InterbankService.ProcessTransaction(card, Config.API_INFO.COMMAND.PAY, this.deposit, DateTime.Now,
                noteTxt.Text == "" ? "Transaction content" : noteTxt.Text);
            string error = result.errorCode;
            if (error == "00")
            {
                Transaction transaction = rentBikeController.CreateDepositTransaction(1, bike.QRCode, this.deposit);
                if (transaction == null)
                {
                    MessageBox.Show("Hệ thống không thể lưu thông tin giao dịch", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.transactionId = transaction.TransactionId;
                rentBikeForm.FillRentingBikeForm();
                rentBikeController.BeginRentingBike(bike.BikeId);
                rentBikeForm.Show(this, null);
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
            if (card == null) card = rentBikeController.GetCardInformation("Group 13");
            if (this.deposit == 0) this.deposit = 40 * bike.Value / 100;
            ProcessTransactionResponse response = null;
            if(this.deposit == this.rentalMoney)
            {
                Transaction transaction = returnBikeController.UpdatePaymentTransaction(transactionId, this.rentalMoney);
                returnBikeController.UpdateStationAfterReturnbike(this.stationId, bike.BikeId, RENTAL_BIKE_CATEGORY);
                MessageBox.Show("giao dịch thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                homePageForm.Show(this);
                this.Hide();
                return;
            }
            if (this.deposit < this.rentalMoney)
                response = await InterbankService.ProcessTransaction(card, API_INFO.COMMAND.PAY, this.rentalMoney - this.deposit,
                    DateTime.Now, "Pay Rental Money");
            else if (this.deposit > this.rentalMoney)
                response = await InterbankService.ProcessTransaction(card, API_INFO.COMMAND.REFUND, this.deposit - this.rentalMoney,
                    DateTime.Now, "Refund deposit");
            string error = response.errorCode;
            if (error == "00")
            {
                Transaction transaction = returnBikeController.UpdatePaymentTransaction(transactionId, this.rentalMoney);
                returnBikeController.UpdateStationAfterReturnbike(this.stationId, bike.BikeId, RENTAL_BIKE_CATEGORY);
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
            rentBikeForm.DisplayRentbikeQrcode();
            rentBikeForm.Show(this, this);
            this.Hide();
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
