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
using static RentalBikeApp.Constant;
using static RentalBikeApp.Program;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Entities.InterbankEntities;
using RentalBikeApp.Bussiness;
using RentalBikeApp.InterbankSubsystem;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with transaction information screen
    /// </summary>
    public partial class TransactionInformationForm : BaseForm
    {
        private bool isPay;
        private int deposit;
        private int rentalMoney;
        private int stationId;
        private BaseBike bike;
        private Card card;
        private BikeCategory category;

        private RentBikeController rentBikeController;
        private ReturnBikeController returnBikeController;
        private PaymentController paymentController;

        /// <summary>
        /// contructor of TransactionInformationForm
        /// </summary>
        public TransactionInformationForm() : base()
        {
            rentBikeController = new RentBikeController();
            returnBikeController = new ReturnBikeController();
            paymentController = new PaymentController();

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
            this.stationId = stationId;
            remainMoneyTxt.Text = "1000000";
            transactionDateTxt.Text = DateTime.Now.ToString("f");
            cancelBut.Visible = false;
            this.isPay = true;
            if (bike is Bike) category = BikeCategory.BIKE;
            else if (bike is ElectricBike) category = BikeCategory.ELECTRIC;
            else if (bike is Tandem) category = BikeCategory.TANDEM;
            rentalMoney = paymentController.CalculateFee(rentBikeForm.GetTotalTimeRent(), category);
            rentalMoneyTxt.Text = (rentalMoney == 0) ? "Miễn phí" : rentalMoney.ToString();
        }

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay deposit money
        /// </summary>
        /// <param name="bike">the rental bike</param>
        /// <param name="card">The card</param>
        public void FillTransactionInformationWhenRentBike(BaseBike bike, Card card)
        {
            this.bike = bike;
            this.card = card;
            this.isPay = false;
            if (bike is Bike) category = BikeCategory.BIKE;
            else if (bike is ElectricBike) category = BikeCategory.ELECTRIC;
            else if (bike is Tandem) category = BikeCategory.TANDEM;
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
            try
            {
                InterbankResponse result = await paymentController.Pay(card, this.deposit, DateTime.Now, noteTxt.Text == "" ? "Transaction content" : noteTxt.Text);
                Transaction transaction = rentBikeController.CreateDepositTransaction(1, bike.BikeId, this.deposit);
                if (transaction == null)
                {
                    MessageBox.Show("Hệ thống không thể lưu thông tin giao dịch", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                rentBikeForm.FillRentingBikeForm();
                rentBikeController.BeginRentingBike(bike.BikeId);
                rentBikeForm.Show(this, null);
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle click event PermitBut when process pay rental money transaction
        /// </summary>
        private async void PermitButWhenPay()
        {
            try
            {
                if (card == null) card = rentBikeController.GetCardInformation("Group 13");
                if (this.deposit == 0) this.deposit = bike.CalculateDeposit();
                InterbankResponse response = null;
                Transaction transaction;
                if (this.deposit == this.rentalMoney)
                {
                    transaction = returnBikeController.UpdatePaymentTransaction(bike.BikeId, this.rentalMoney);
                    returnBikeController.UpdateStationAfterReturnbike(this.stationId, bike.BikeId);
                    MessageBox.Show("giao dịch thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    homePageForm.Show(this);
                    this.Hide();
                    return;
                }
                if (this.deposit < this.rentalMoney)
                    response = await paymentController.Pay(card, this.rentalMoney - this.deposit, DateTime.Now, "Pay Rental Money");
                else if (this.deposit > this.rentalMoney)
                    response = await paymentController.Refund(card, this.deposit - this.rentalMoney, DateTime.Now, "Refund deposit");
                string error = response.errorCode;
                transaction = returnBikeController.UpdatePaymentTransaction(bike.BikeId, this.rentalMoney);
                returnBikeController.UpdateStationAfterReturnbike(this.stationId, bike.BikeId);
                MessageBox.Show("giao dịch thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                homePageForm.Show(this);
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            homePageForm.RenderStationList();
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
            if (this.isPay) PermitButWhenPay();
            else PermitButWhenRentBike();
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
