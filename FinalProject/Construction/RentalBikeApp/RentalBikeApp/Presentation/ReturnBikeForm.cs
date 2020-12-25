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
using static RentalBikeApp.Program;
using System.Collections.Generic;
using RentalBikeApp.Entities.SQLEntities;
using RentalBikeApp.Bussiness;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// provider to function and event to help user interact with return bike screen
    /// </summary>
    public partial class ReturnBikeForm : BaseForm
    {
        private List<Station> stationList;
        private BikeStationController bikeStationController;
        private ReturnBikeController returnBikeController;

        /// <summary>
        /// current rental bike
        /// </summary>
        public BaseBike rentalBike { get; set; }

        /// <summary>
        /// contructor of RentBikeForm
        /// </summary>
        public ReturnBikeForm(): base()
        {
            bikeStationController = new BikeStationController();
            returnBikeController = new ReturnBikeController();

            stationList = bikeStationController.ViewListStation();

            InitializeComponent("ReturnBikeForm", "Return Bike");
            DrawReturnBikeForm();
            RenderStationList(this.listStationPnl);
        }

        /// <summary>
        /// Get station in the database and display in specified panel
        /// </summary>
        /// <param name="pnl">The specified panel</param>
        private void RenderStationList(Panel pnl)
        {
            pnl.Controls.Clear();
            int X = 20, Y = 5;
            int count = 0;
            foreach (Station station in stationList)
            {
                Button but = new Button()
                {
                    Location = new Point(X, Y),
                    Size = new Size(pnl.Width - 40, 50),
                    BackColor = (count % 2 == 0) ? ColorTranslator.FromHtml("#4dd7fa") : ColorTranslator.FromHtml("#c9f1fd"),
                    Text = station.NameStation,
                    Tag = station.StationId
                };
                Y += 55; count++;
                but.Click += But_Click;
                pnl.Controls.Add(but);
            }
        }

        /// <summary>
        /// Get station in the database and display in specified panel
        /// </summary>
        /// <param name="stationList">The specified station list to display</param>
        /// <param name="pnl">The specified panel to display station list</param>
        private void RenderStationList(List<Station> stationList, Panel pnl)
        {
            this.stationList = stationList;
            RenderStationList(pnl);
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
            homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event return station but, choose the station to return renta bike
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            string nameStation = but.Text;
            DialogResult result = MessageBox.Show($"Bạn có chắc muốn trả xe ở bãi xe: {nameStation}", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            int stationId = (int)but.Tag;
            if(result == DialogResult.OK)
            {
                if (!returnBikeController.CheckStation(stationId))
                {
                    MessageBox.Show($"Bãi đỗ xe: {but.Text} đã đầy, vui lòng chọn bãi khác để trả xe", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                rentBikeForm.StopTimer();
                transactionInformationForm.FillTransactionInformationWhenPay(stationId, this.rentalBike);
                transactionInformationForm.Show(this);
                this.Hide();
            }
        }

        /// <summary>
        /// Handle click event CancelBut, cancel return bike action
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event CancelSearchBut, delete the search result, display the default form
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelSearchBut_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            searchTxt.Width = this.ClientSize.Width - 140;
            this.stationList = bikeStationController.ViewListStation();
            RenderStationList(this.listStationPnl);
        }

        /// <summary>
        /// Handle click event SearchBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void SearchBut_Click(object sender, EventArgs e)
        {
            string nameStation = searchTxt.Text;
            if (nameStation == "")
            {
                MessageBox.Show("Nhập tên bãi xe bạn muốn tìm kiếm");
                return;
            }
            List<Station> stations = stationList.Where(x => x.NameStation.Contains(nameStation)).ToList();
            if (stations.Count() == 0)
            {
                MessageBox.Show("Không tìm thấy bãi xe " + nameStation);
                searchTxt.Text = "";
                return;
            }
            searchTxt.Width = this.ClientSize.Width - 180;
            this.RenderStationList(stations, this.listStationPnl);
        }
    }
}
