// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class ReturnBikeForm : BaseForm
    {
        private StationService stationService;
        private List<Station> stationList;

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

        private TransactionInformationForm _transactionInformationForm;
        public TransactionInformationForm transactionInformationForm
        {
            get { return _transactionInformationForm; }
            set { _transactionInformationForm = value; }
        }

        public ReturnBikeForm()
        {
            stationService = new StationService();
            stationList = stationService.GetListStations();

            InitializeComponent("ReturnBikeForm", "Return Bike");
            DrawBaseForm();
            DrawReturnBikeForm();
            RenderStationList(this.listStationPnl);

            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        /// <summary>
        /// Get station in the database and display in specified panel
        /// </summary>
        /// <param name="pnl">The specified panel</param>
        public void RenderStationList(Panel pnl)
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
        public void RenderStationList(List<Station> stationList, Panel pnl)
        {
            this.stationList = stationList;
            RenderStationList(pnl);
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            string nameStation = but.Text;
            DialogResult result = MessageBox.Show(string.Format("Bạn có chắc muốn trả xe ở bãi xe: {0}", nameStation), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.OK)
            {
                _rentBikeForm.rentBikeTmr.Stop();
                _transactionInformationForm.FillTransactionInformation(Config.TRANSACTION_STATUS.PAY);
                _transactionInformationForm.Show(this);
                this.Hide();
            }
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void CancelSearchBut_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            searchTxt.Width = this.ClientSize.Width - 140;
            this.stationList = stationService.GetListStations();
            RenderStationList(this.listStationPnl);
        }

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
