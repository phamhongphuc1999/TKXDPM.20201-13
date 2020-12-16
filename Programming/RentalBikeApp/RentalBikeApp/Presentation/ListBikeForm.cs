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

namespace RentalBikeApp.Presentation
{
    public partial class ListBikeForm : BaseForm
    {
        public ListBikeForm()
        {
            InitializeComponent("ListBikesForm", "List Bikes");
            DrawBaseForm();
            DrawListBikes();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
            prevFormBut.Click += PrevFormBut_Click;
        }

        private void FillListBikes(Station station)
        {
            listBikePnl.Controls.Clear();
            List<Bike> bikesList = bikeService.GetListBikesInStation(station.StationId);
            int count = bikesList.Count(x => !x.BikeStatus);
            if (count > 0)
                descriptionRtb.Text = $"Xe đạp thường\nCòn lại {count} xe";
            else descriptionRtb.Text = "Bãi xe không còn xe";
            stationRtb.Text = $"{station.NameStation}\n{station.AddressStation}";
            int X = 20, Y = 5;
            int count1 = 1;
            foreach (Bike bike in bikesList)
            {
                Button but = new Button()
                {
                    Location = new Point(X, Y),
                    Size = new Size(listBikePnl.Width - 40, 50),
                    BackColor = (count1 % 2 == 0) ? ColorTranslator.FromHtml("#4dd7fa") : ColorTranslator.FromHtml("#c9f1fd"),
                    Text = $"xe số {count1}:{bike.QRCode}",
                    Tag = (bike.BikeId, Config.SQL.BikeCategory.BIKE)
                };
                Y += 55; count1++;
                but.Click += But_Click;
                listBikePnl.Controls.Add(but);
            }
        }

        private void FillListTandems(Station station)
        {
            listBikePnl.Controls.Clear();
            List<Tandem> bikesList = tandemService.GetListBikesInStation(station.StationId);
            int count = bikesList.Count(x => !x.BikeStatus);
            if (count > 0)
                descriptionRtb.Text = $"Xe đạp đôi\nCòn lại {count} xe";
            else descriptionRtb.Text = "Bãi xe không còn xe";
            stationRtb.Text = $"{station.NameStation}\n{station.AddressStation}";
            int X = 20, Y = 5;
            int count1 = 1;
            foreach (Tandem bike in bikesList)
            {
                Button but = new Button()
                {
                    Location = new Point(X, Y),
                    Size = new Size(listBikePnl.Width - 40, 50),
                    BackColor = (count1 % 2 == 0) ? ColorTranslator.FromHtml("#4dd7fa") : ColorTranslator.FromHtml("#c9f1fd"),
                    Text = $"xe số {count1}:{bike.QRCode}",
                    Tag = (bike.BikeId, Config.SQL.BikeCategory.TANDEM)
                };
                Y += 55; count1++;
                but.Click += But_Click;
                listBikePnl.Controls.Add(but);
            }
        }

        private void FillListElectric(Station station)
        {
            listBikePnl.Controls.Clear();
            List<ElectricBike> bikesList = electricBikeService.GetListBikesInStation(station.StationId);
            int count = bikesList.Count(x => !x.BikeStatus);
            if (count > 0)
                descriptionRtb.Text = $"Xe đạp điện\nCòn lại {count} xe";
            else descriptionRtb.Text = "Bãi xe không còn xe";
            stationRtb.Text = $"{station.NameStation}\n{station.AddressStation}";
            int X = 20, Y = 5;
            int count1 = 1;
            foreach (ElectricBike bike in bikesList)
            {
                Button but = new Button()
                {
                    Location = new Point(X, Y),
                    Size = new Size(listBikePnl.Width - 40, 50),
                    BackColor = (count1 % 2 == 0) ? ColorTranslator.FromHtml("#4dd7fa") : ColorTranslator.FromHtml("#c9f1fd"),
                    Text = $"xe số {count1}:{bike.QRCode}",
                    Tag = (bike.BikeId, Config.SQL.BikeCategory.ELECTRIC)
                };
                Y += 55; count1++;
                but.Click += But_Click;
                listBikePnl.Controls.Add(but);
            }
        }

        /// <summary>
        /// Fill ListBikeForm with bike's information in specified category
        /// </summary>
        /// <param name="station">The station contain list bike is displayed</param>
        /// <param name="category">The specified bike's category</param>
        public void FillListBikes(Station station, Config.SQL.BikeCategory category)
        {
            if (category == Config.SQL.BikeCategory.BIKE) FillListBikes(station);
            else if (category == Config.SQL.BikeCategory.ELECTRIC) FillListElectric(station);
            else FillListTandems(station);
        }

        /// <summary>
        /// Handle click event bike detail button, display the information of specified bike
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            (int, Config.SQL.BikeCategory) bikeInfo = ((int, Config.SQL.BikeCategory))but.Tag;
            string stationName = "", stationAddress = "";
            BaseBike bike = bikeStationController.ViewBikeDetail(bikeInfo.Item1, bikeInfo.Item2, ref stationName, ref stationAddress);
            if (bike == null)
            {
                MessageBox.Show($"Không tìm được xe có id: {bikeInfo.Item1}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bikeDetailForm.FillBikeInformation(bike, stationName, stationAddress);
            bikeDetailForm.Show(this);
            this.Hide();
            bikeDetailForm.Show(this, this);
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            rentBikeForm.Show(this, Config.RENT_BIKE_STATUS, this);
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
            if (!Utilities.InvlidString(Config.QRValid, qrCode))
            {
                MessageBox.Show($"QRCode không hợp lệ\nQRCode là dãy số có chín chữ số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string stationName = "", stationAddress = "";
            BaseBike bike = bikeStationController.ViewBikeDetail(qrCode, ref stationName, ref stationAddress);
            if(bike == null) MessageBox.Show($"Không tìm được xe có qrcode: {qrCode}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bikeDetailForm.FillBikeInformation(bike, stationName, stationAddress);
            bikeDetailForm.Show(this);
            this.Hide();
        }
    }
}
