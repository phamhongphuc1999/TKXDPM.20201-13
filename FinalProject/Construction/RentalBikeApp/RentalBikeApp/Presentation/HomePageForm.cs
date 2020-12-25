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
    /// provider to function and event to help user interact with home page screen
    /// </summary>
    public partial class HomePageForm : BaseForm
    {
        private List<Station> stationList;
        private BikeStationController bikeStationController;

        /// <summary>
        /// contructor of HomePageForm
        /// </summary>
        public HomePageForm(): base()
        {
            bikeStationController = new BikeStationController();

            stationList = bikeStationController.ViewListStation();
            
            InitializeComponent("HomePageForm", "Home Page");
            DrawHomePage();
            RenderStationList(this.stationPnl);
            this.StartPosition = FormStartPosition.CenterScreen;

            Config.RENT_BIKE_STATUS = Config.RENT_BIKE.RENT_BIKE;
            prevFormBut.Enabled = false;
        }

        /// <summary>
        /// Get station in the database and display in specified panel
        /// </summary>
        /// <param name="pnl">The specified panel to display station list</param>
        public void RenderStationList(Panel pnl)
        {
            pnl.Controls.Clear();
            int X = 20, Y = 5;
            int count = 0;
            foreach(Station station in stationList)
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
        public void RenderStationList(List<Station> stationList, Panel pnl)
        {
            this.stationList = stationList;
            RenderStationList(pnl);
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void HomePageBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Form form = but.Parent as Form;
            this.RenderStationList(this.stationPnl);
            this.Show(form);
            if (!(form is HomePageForm)) form.Hide();
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected override void RentBikeBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.Show(this, Config.RENT_BIKE_STATUS, this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event station detail but
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Station station = bikeStationController.ViewStationDetail((int)but.Tag);
            this.Hide();
            stationDetailForm.FillStationDetail(station);
            stationDetailForm.Show(this, this);
        }

        /// <summary>
        /// Handle click event SearchBut, display result in form
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void SearchBut_Click(object sender, EventArgs e)
        {
            string nameStation = searchTxt.Text;
            if (nameStation == "")
            {
                MessageBox.Show("Nhập tên bãi xe bạn muốn tìm kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<Station> stations = stationList.Where(x => x.NameStation.Contains(nameStation)).ToList();
            if(stations.Count() == 0)
            {
                MessageBox.Show("Không tìm thấy bãi xe " + nameStation, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchTxt.Text = "";
                return;
            }
            searchTxt.Width = this.ClientSize.Width - 180;
            this.RenderStationList(stations, this.stationPnl);
        }

        /// <summary>
        /// Handle click event CancelSearchBut, delete search result, display default form
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void CancelSearchBut_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            searchTxt.Width = this.ClientSize.Width - 140;
            this.stationList = bikeStationController.ViewListStation();
            RenderStationList(this.stationPnl);
        }
    }
}
