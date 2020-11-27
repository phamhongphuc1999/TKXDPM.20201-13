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

        private int deposit;

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
                    transactionContent = "Thanh toan Mass",
                    amount = this.deposit,
                    createdAt = Utilities.ConvertDateToString(2020, 11, 10, 18, 30, 20)
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
                Config.SQL.BikeCategory category = SQL.BikeCategory.BIKE;
                if (Config.RENTAL_BIKE.Category == "bike") category = SQL.BikeCategory.BIKE;
                else if (Config.RENTAL_BIKE.Category == "electric") category = SQL.BikeCategory.ELECTRIC;
                else if (Config.RENTAL_BIKE.Category == "tandem") category = SQL.BikeCategory.TANDEM;
                int rentalMoney = interbankService.CalculateFee(Config.TIME_RENTAL_BIKE, category);
                rentalMoneyTxt.Text = rentalMoney.ToString();
                ProcessTransactionResponse result = await interbankService.ProcessTransaction(new TransactionInfo
                {
                    cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                    owner = Config.API_INFO.CARD_INFO.OWER,
                    cvvCode = Config.API_INFO.CARD_INFO.CVV,
                    dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                    transactionContent = "Thanh toan Mass",
                    amount = rentalMoney,
                    createdAt = Utilities.ConvertDateToString(2020, 11, 10, 18, 30, 20)
                }, Config.API_INFO.COMMAND.PAY);
                string error = result.errorCode;
                if(error == "0")
                {
                    result = await interbankService.ProcessTransaction(new TransactionInfo
                    {
                        cardCode = Config.API_INFO.CARD_INFO.CARD_CODE,
                        owner = Config.API_INFO.CARD_INFO.OWER,
                        cvvCode = Config.API_INFO.CARD_INFO.CVV,
                        dateExpired = Config.API_INFO.CARD_INFO.DATE_EXPIRED,
                        transactionContent = "Thanh toan Mass",
                        amount = deposit,
                        createdAt = Utilities.ConvertDateToString(2020, 11, 10, 18, 30, 20)
                    }, Config.API_INFO.COMMAND.REFUND);
                    MessageBox.Show("Thanh toán tiền thuê xe thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _homePageForm.RenderStationList(_homePageForm.stationPnl);
                    _homePageForm.Show(this);
                }
                else if (error == "01" || error == "02" || error == "05")
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
            this.Hide();
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            _cardInformationForm.Show(this);
            this.Hide();
        }
    }
}
