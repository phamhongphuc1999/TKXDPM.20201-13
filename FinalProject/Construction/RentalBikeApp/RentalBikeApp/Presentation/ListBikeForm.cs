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
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using static RentalBikeApp.Program;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Bussiness;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with list bike screen
    /// </summary>
    public partial class ListBikeForm : BaseForm
    {
        private string stationName, stationAddress;
        private List<BaseBike> bikes;
        private ViewBikeController viewBikeController;
        private ViewStationController viewStationController;

        /// <summary>
        /// contructor of ListBikeForm
        /// </summary>
        public ListBikeForm() : base()
        {
            viewBikeController = new ViewBikeController();
            viewStationController = new ViewStationController();

            InitializeComponent("ListBikesForm", "List Bikes");
            DrawListBikes();
        }

        /// <summary>
        /// Create button for display information bike
        /// </summary>
        /// <param name="bikeId">The bike id</param>
        /// <param name="qrCode">The bike qr code</param>
        /// <param name="status">The bike status</param>
        /// <param name="X">The horizontal position of the button</param>
        /// <param name="Y">The vertical position of the button</param>
        /// <param name="count">The index of button</param>
        private void CreateButBike(int bikeId, string qrCode, bool status, int X, int Y, int count)
        {
            Button but = new Button()
            {
                Location = new Point(X, Y),
                Size = new Size(listBikePnl.Width - 40, 50),
                BackColor = (count % 2 == 0) ? ColorTranslator.FromHtml("#4dd7fa") : ColorTranslator.FromHtml("#c9f1fd"),
                Text = status ? $"xe số {count}:{qrCode} - renting" : $"xe số {count}:{qrCode} - available",
                Tag = bikeId
            };
            but.Click += But_Click;
            listBikePnl.Controls.Add(but);
        }

        /// <summary>
        /// Fill ListBikeForm with bike's information in specified category
        /// </summary>
        /// <param name="stationId">The station contain list bike is displayed</param>
        /// <param name="stationName">The name of station contain list bike is displayed</param>
        /// <param name="stationAddress">The address of station contain list bike is displayed</param>
        public void FillListBikes(int stationId, string stationName, string stationAddress)
        {
            listBikePnl.Controls.Clear();
            this.stationName = stationName; this.stationAddress = stationAddress;
            bikes = viewBikeController.ViewListBikeInStation(stationId).Select(bike =>
            {
                return new BaseBike(bike);
            }).ToList();
            int count = bikes.Count(x => !x.BikeStatus);
            if (count > 0) descriptionRtb.Text = $"Xe đạp thường\nCòn lại {count} xe";
            else descriptionRtb.Text = "Bãi xe không còn xe";
            stationRtb.Text = $"{stationName}\n{stationAddress}";
            int X = 20, Y = 5;
            count = 1;
            foreach (BaseBike bike in bikes)
            {
                CreateButBike(bike.BikeId, bike.QRCode, bike.BikeStatus, X, Y, count);
                Y += 55; count++;
            }
        }

        /// <summary>
        /// Fill ListBikeForm with tandem's information in specified category
        /// </summary>
        /// <param name="stationId">The station contain list bike is displayed</param>
        /// <param name="stationName">The name of station contain list bike is displayed</param>
        /// <param name="stationAddress">The address of station contain list bike is displayed</param>
        public void FillListTandems(int stationId, string stationName, string stationAddress)
        {
            listBikePnl.Controls.Clear();
            this.stationName = stationName; this.stationAddress = stationAddress;
            bikes = viewBikeController.ViewListTandemInStation(stationId).Select(bike =>
            {
                return new BaseBike(bike);
            }).ToList();
            int count = bikes.Count(x => !x.BikeStatus);
            if (count > 0) descriptionRtb.Text = $"Xe đạp đôi\nCòn lại {count} xe";
            else descriptionRtb.Text = "Bãi xe không còn xe";
            stationRtb.Text = $"{stationName}\n{stationAddress}";
            int X = 20, Y = 5;
            count = 1;
            foreach (BaseBike bike in bikes)
            {
                CreateButBike(bike.BikeId, bike.QRCode, bike.BikeStatus, X, Y, count);
                Y += 55; count++;
            }
        }

        /// <summary>
        /// Fill ListBikeForm with electric bike's information in specified category
        /// </summary>
        /// <param name="stationId">The station contain list bike is displayed</param>
        /// <param name="stationName">The name of station contain list bike is displayed</param>
        /// <param name="stationAddress">The address of station contain list bike is displayed</param>
        public void FillListElectric(int stationId, string stationName, string stationAddress)
        {
            listBikePnl.Controls.Clear();
            this.stationName = stationName; this.stationAddress = stationAddress;
            bikes = viewBikeController.ViewListElectricBikeInStation(stationId).Select(bike =>
            {
                return new BaseBike(bike);
            }).ToList();
            int count = bikes.Count(x => !x.BikeStatus);
            if (count > 0) descriptionRtb.Text = $"Xe đạp điện\nCòn lại {count} xe";
            else descriptionRtb.Text = "Bãi xe không còn xe";
            stationRtb.Text = $"{stationName}\n{stationAddress}";
            int X = 20, Y = 5;
            count = 1;
            foreach (BaseBike bike in bikes)
            {
                CreateButBike(bike.BikeId, bike.QRCode, bike.BikeStatus, X, Y, count);
                Y += 55; count++;
            }
        }

        /// <summary>
        /// Handle click event bike detail button, display the information of specified bike
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            int bikeId = (int)but.Tag;
            BaseBike bike = viewBikeController.ViewBikeDetail(bikeId);
            if (bike == null)
            {
                MessageBox.Show($"Không tìm được xe có id: {bikeId}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bikeDetailForm.FillBikeInformation(bike, this.stationName, this.stationAddress);
            bikeDetailForm.Show(this);
            bikeDetailForm.Show(this, this);
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
            homePageForm.RenderStationList();
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event SearchBut, display information of bike if finded
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void SearchBut_Click(object sender, EventArgs e)
        {
            string qrCode = searchTxt.Text;
            searchTxt.Text = "";
            if (qrCode == "")
            {
                MessageBox.Show("Nhập mã xe bạn muốn tìm kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Utilities.InvlidString(Constant.QRValid, qrCode))
            {
                MessageBox.Show($"QRCode không hợp lệ\nQRCode là dãy số có chín chữ số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BaseBike bike = bikes.SingleOrDefault(x => x.QRCode == qrCode);
            if (bike == null)
            {
                MessageBox.Show($"Không tìm được xe có qrcode: {qrCode}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Station station = viewStationController.ViewStationDetail(bike.StationId);
            bikeDetailForm.FillBikeInformation(bike, station.NameStation, station.AddressStation);
            bikeDetailForm.Show(this, this);
            this.Hide();
        }
    }
}
