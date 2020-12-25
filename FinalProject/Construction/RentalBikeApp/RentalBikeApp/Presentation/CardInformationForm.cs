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

using static RentalBikeApp.Program;
using System;
using System.Windows.Forms;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with card information screen
    /// </summary>
    public partial class CardInformationForm : BaseForm
    {
        /// <summary>
        /// contructor of CardInformationForm
        /// </summary>
        public CardInformationForm(): base()
        {
            InitializeComponent("CardInformationForm", "Card Information");
            DrawCardInformation();
        }

        /// <summary>
        /// Valid card information
        /// </summary>
        /// <returns>(bool, string) tuple, Item1 representing status valid, true when valid success, false when valid fail. Item2 representing response message</returns>
        private (bool, string) ValidCardInfor()
        {
            if (owerTxt.Text == "" || cardCodeTxt.Text == "" || securityCodeTxt.Text == "" || bankCb.SelectedIndex == 0)
                return (false, "Yêu cầu nhập đầy đủ thông tin trước khi xác nhận");
            Card card = rentBikeController.GetCardInformation(owerTxt.Text);
            if (card == null) return (false, "Thông tin sai hoặc thẻ không tồn tại");
            if(card.CardCode != cardCodeTxt.Text || card.SecurityKey != securityCodeTxt.Text)
                return (false, "Thông tin sai hoặc thẻ không tồn tại");
            return (true, "");
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void RentBikeBut_Click(object sender, EventArgs e)
        {
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
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event SubmitBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void SubmitBut_Click(object sender, EventArgs e)
        {
            (bool, string) info = ValidCardInfor();
            if (!info.Item1)
            {
                MessageBox.Show(info.Item2, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            transactionInformationForm.FillTransactionInformationWhenRentBike();
            transactionInformationForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event CancelBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.Show(this, Config.RENT_BIKE.RENT_BIKE_INFO);
            this.Hide();
        }
    }
}
