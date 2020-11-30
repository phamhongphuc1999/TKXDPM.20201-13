// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class ListBikeForm : BaseForm
    {
        private BikeService bikeService;

        private HomePageForm _homePageForm;
        /// <value>
        /// get or set the HomePageForm representing the home page screen
        /// </value>
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        private BikeDetailForm _bikeDetailForm;
        /// <value>
        /// get or set the BikeDetailForm representing the bike detail screen
        /// </value>
        public BikeDetailForm bikeDetailForm
        {
            get { return _bikeDetailForm; }
            set { _bikeDetailForm = value; }
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

        private StationDetailForm _stationDetailForm;
        /// <value>
        /// get or set the StationDetailForm representing the station detail screen
        /// </value>
        public StationDetailForm stationDetailForm
        {
            get { return _stationDetailForm; }
            set { _stationDetailForm = value; }
        }

        public ListBikeForm()
        {
            bikeService = new BikeService();

            InitializeComponent("ListBikesForm", "List Bikes");
            DrawBaseForm();
            DrawListBikes();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        /// <summary>
        /// Fill ListBikeForm with bike's information in specified category
        /// </summary>
        /// <param name="station">The station contain list bike is displayed</param>
        /// <param name="category">The specified bike's category</param>
        public void FillListBikes(Station station, Config.SQL.BikeCategory category)
        {
            listBikePnl.Controls.Clear();
            List<Bike> bikesList = bikeService.GetListBikesInStation(station.StationId, category);
            int count = bikesList.Count(x => !x.BikeStatus);
            string categoryBike = Config.BIKE_CATEGORY[bikesList[0].Category];
            descriptionRtb.Text = string.Format("{0}\nCòn lại {1} xe", categoryBike, count.ToString());
            stationRtb.Text = string.Format("{0}\n{1}", station.NameStation, station.AddressStation);
            int X = 20, Y = 5;
            int count1 = 1;
            foreach (Bike bike in bikesList)
            {
                Button but = new Button()
                {
                    Location = new Point(X, Y),
                    Size = new Size(listBikePnl.Width - 40, 50),
                    BackColor = (count1 % 2 == 0) ? ColorTranslator.FromHtml("#4dd7fa") : ColorTranslator.FromHtml("#c9f1fd"),
                    Text = string.Format("xe số {0}:{1}", count1.ToString(), bike.QRCode),
                    Tag = bike.BikeId
                };
                Y += 55; count1++;
                but.Click += But_Click;
                listBikePnl.Controls.Add(but);
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
            Bike bike = bikeService.GetBikeById((int)but.Tag);
            _bikeDetailForm.FillBikeInformation(bike);
            _bikeDetailForm.Show(this);
            this.Hide();
            bikeDetailForm.Show();
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this, Config.RENT_BIKE_STATUS);
            this.Hide();
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handle click event ReturnStationBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void ReturnStationBut_Click(object sender, EventArgs e)
        {
            stationDetailForm.Show(this);
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
            if(qrCode == "")
            {
                MessageBox.Show("Nhập mã xe bạn muốn tìm kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Regex r = new Regex("([0-9]){0,8}");
            if (!r.IsMatch(qrCode))
            {
                MessageBox.Show("Mã xe bạn nhập không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bike bike = bikeService.GetBikeByQRCode(qrCode);
            if(bike == null)
            {
                MessageBox.Show("Không tìm thấy mã xe: " + qrCode, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _bikeDetailForm.FillBikeInformation(bike);
            _bikeDetailForm.Show(this);
            this.Hide();
        }
    }
}
