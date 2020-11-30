// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.Windows.Forms;
using RentalBikeApp.Business;
using static RentalBikeApp.Config;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Entities.APIEntities;

namespace RentalBikeApp.Presentation
{
    public partial class TransactionInformationForm : BaseForm
    {
        private InterbankService interbankService;

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

        private CardInformationForm _cardInformationForm;
        /// <value>
        /// get or set the CardInformationForm representing the card information screen
        /// </value>
        public CardInformationForm cardInformationForm
        {
            get { return _cardInformationForm; }
            set { _cardInformationForm = value; }
        }

        private int deposit;
        private int rentalMoney;

        public TransactionInformationForm()
        {
            interbankService = new InterbankService();

            InitializeComponent("TransactionInformationForm", "Transaction Information");
            DrawBaseForm();
            DrawTransactionInformationForm();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        private TRANSACTION_STATUS status;

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay rental money
        /// </summary>
        public void FillTransactionInformationWhenPay()
        {
            this.status = TRANSACTION_STATUS.PAY;
            remainMoneyTxt.Text = "111";
            transactionDateTxt.Text = Utilities.ConvertDateToString(DateTime.Now);
            cancelBut.Visible = false;

            Config.SQL.BikeCategory category = SQL.BikeCategory.BIKE;
            if (Config.RENTAL_BIKE.Category == "bike") category = SQL.BikeCategory.BIKE;
            else if (Config.RENTAL_BIKE.Category == "electric") category = SQL.BikeCategory.ELECTRIC;
            else if (Config.RENTAL_BIKE.Category == "tandem") category = SQL.BikeCategory.TANDEM;
            rentalMoney = interbankService.CalculateFee(Config.TIME_RENTAL_BIKE, category);
            rentalMoneyTxt.Text = (rentalMoney == 0) ? "Miễn phí" : rentalMoney.ToString();
        }

        /// <summary>
        /// Fill transaction form with transaction's information when user process transaction for pay deposit money
        /// </summary>
        /// <param name="card">The instance represent user card information</param>
        public void FillTransactionInformationWhenRentBike(Card card)
        {
            this.status = TRANSACTION_STATUS.RENT_BIKE;
            this.deposit = Config.BIKE_DEPOSIT[Config.RENTAL_BIKE.Category];
            depositTxt.Text = String.Format("{0:n0}", this.deposit);
            remainMoneyTxt.Text = "Không có dữ liệu";
            transactionDateTxt.Text = "Không có dữ liệu";
            cancelBut.Visible = true;
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show();
            this.Show();
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Handle click event PermitBut, send pay or refund transaction end handle the response
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private async void PermitBut_Click(object sender, EventArgs e)
        {
            if (status == TRANSACTION_STATUS.RENT_BIKE)
            {
                Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENTING_BIKE;
                ProcessTransactionResponse result = await interbankService.ProcessTransaction(new TransactionInfo
                {
                    cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                    owner = Config.API_INFO.CARD_INFO.OWER,
                    cvvCode = Config.API_INFO.CARD_INFO.CVV,
                    dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                    transactionContent = "Pay Deposit",
                    amount = this.deposit,
                    createdAt = Utilities.ConvertDateToString(DateTime.Now)
                }, Config.API_INFO.COMMAND.PAY);
                string error = result.errorCode;
                if(error == "00")
                {
                    _rentBikeForm.FillRentingBikeForm();
                    _rentBikeForm.rentBikeTmr.Start();
                    _rentBikeForm.Show(this, Config.RENT_BIKE_STATUS);
                }
                else if(error == "01" || error == "02" || error == "05")
                {
                    MessageBox.Show(API_INFO.ERROR_CODE[result.errorCode], "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _cardInformationForm.Show(this);
                }
                else
                {
                    MessageBox.Show(API_INFO.ERROR_CODE[result.errorCode], "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (status == TRANSACTION_STATUS.PAY) 
            {
                Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENT_BIKE;
                ProcessTransactionResponse response = await interbankService.ProcessTransaction(new TransactionInfo
                {
                    cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                    owner = Config.API_INFO.CARD_INFO.OWER,
                    cvvCode = Config.API_INFO.CARD_INFO.CVV,
                    dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                    transactionContent = "Pay rental money",
                    amount = this.rentalMoney,
                    createdAt = Utilities.ConvertDateToString(DateTime.Now)
                }, Config.API_INFO.COMMAND.PAY);
                string error = response.errorCode;
                if(error == "00")
                {
                    ProcessTransactionResponse response1 = await interbankService.ProcessTransaction(new TransactionInfo
                    {
                        cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                        owner = Config.API_INFO.CARD_INFO.OWER,
                        cvvCode = Config.API_INFO.CARD_INFO.CVV,
                        dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                        transactionContent = "Refund deposit",
                        amount = this.deposit,
                        createdAt = Utilities.ConvertDateToString(DateTime.Now)
                    }, Config.API_INFO.COMMAND.REFUND);
                    MessageBox.Show("Thanh toán tiền thuê xe thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _homePageForm.RenderStationList(_homePageForm.stationPnl);
                    _homePageForm.Show(this);
                }
                else
                {
                    MessageBox.Show(API_INFO.ERROR_CODE[response.errorCode], "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.Hide();
        }

        /// <summary>
        /// Handle click event Cancelbut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelBut_Click(object sender, EventArgs e)
        {
            _cardInformationForm.Show(this);
            this.Hide();
        }
    }
}
