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
    public partial class CardInformationForm : BaseForm
    {
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.Show(this, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void HomePageBut_Click(object sender, EventArgs e)
        {
            homePageForm.RenderStationList(homePageForm.stationPnl);
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event PrevFormBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
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
            (bool, string) info = ValidCardInfor();
            if (!info.Item1)
            {
                MessageBox.Show(info.Item2, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            transactionInformationForm.FillTransactionInformationWhenRentBike();
            transactionInformationForm.Show(this);
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
