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
using static RentalBikeApp.Program;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Bussiness;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with rent bike screen
    /// </summary>
    public partial class RentBikeForm : BaseForm
    {
        private RentBikeController rentBikeController;

        /// <summary>
        /// contructor of RentBikeForm
        /// </summary>
        public RentBikeForm() : base()
        {
            rentBikeController = new RentBikeController();

            InitializeComponent("RentBikeForm", "Rent Bike");
            DrawRentBikeForm();
        }

        /// <summary>
        /// display screen to user fill rental bike qrcode
        /// </summary>
        public void DisplayRentbikeQrcode()
        {
            rentBikePnl.Visible = true;
            rentBikeQrCodeTxt.Text = "";
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void HomePageBut_Click(object sender, EventArgs e)
        {
            homePageForm.RenderStationList();
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void RentBikeBut_Click(object sender, EventArgs e)
        {
            DisplayRentbikeQrcode();
        }

        /// <summary>
        /// Handle click event RentBikeRentBut, if user enter correct or code, display detail information of bike have this qr code
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeRentBut_Click(object sender, EventArgs e)
        {
            string qrCode = rentBikeQrCodeTxt.Text;
            if (qrCode == "")
            {
                MessageBox.Show("Nhập mã xe bạn muốn tìm kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Utilities.InvlidString(Constant.QRValid, qrCode))
            {
                MessageBox.Show($"QRCode không hợp lệ\nQRCode là dãy số có chín chữ số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            string stationName = "", stationAddress = "";
            BaseBike bike = rentBikeController.SubmitQrCode(qrCode, ref stationName, ref stationAddress);
            if (bike == null)
            {
                MessageBox.Show($"Không tìm thấy xe có mã qr code {qrCode}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            if (bike.BikeStatus)
            {
                MessageBox.Show($"Xe đang được thuê, vui lòng chọn xe khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rentBikeQrCodeTxt.Text = "";
                return;
            }
            bikeDetailForm.FillBikeInformation(bike, stationName, stationAddress);
            bikeDetailForm.Show(this);
            this.Hide();
        }
    }
}
