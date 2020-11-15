using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace RentalBikeApp.Presentation
{
    public partial class HomePageForm : BaseForm
    {
        private StationService stationService;

        private StationDetailForm stationDetailForm;
        private ListBikeForm listBikeForm;

        public HomePageForm()
        {
            stationService = new StationService();
            stationDetailForm = new StationDetailForm();
            stationDetailForm.returnHomePageBut.Click += ReturnHomePageBut_Click;
            stationDetailForm.bikeBut.Click += BikeBut_Click;
            stationDetailForm.electricBut.Click += ElectricBut_Click;
            stationDetailForm.tandemBut.Click += TandemBut_Click;

            listBikeForm = new ListBikeForm();

            InitializeComponent("HomePageForm", "Home Page");
            DrawBaseForm();
            DrawHomePage();
            RenderStationList(this.stationPnl);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void RenderStationList(Panel pnl)
        {
            pnl.Controls.Clear();
            List<Station> stationList = stationService.GetListStations();
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

        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Station station = stationService.GetStationById((int)but.Tag);
            this.Hide();
            stationDetailForm.FillStationDetail(station);
            stationDetailForm.Show("HomePageForm");
        }

        #region event StationDetailForm
        private void ReturnHomePageBut_Click(object sender, EventArgs e)
        {
            stationDetailForm.Hide();
            this.Show();
        }

        private void TandemBut_Click(object sender, EventArgs e)
        {
            Button tandemBut = sender as Button;
            Station station = stationService.GetStationById((int)tandemBut.Tag);
            stationDetailForm.Hide();
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.TANDEM);
            listBikeForm.Show("StationDetailForm");
        }

        private void ElectricBut_Click(object sender, EventArgs e)
        {
            Button electricBut = sender as Button;
            Station station = stationService.GetStationById((int)electricBut.Tag);
            stationDetailForm.Hide();
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show("StationDetailForm");
        }

        private void BikeBut_Click(object sender, EventArgs e)
        {
            Button bikeBut = sender as Button;
            Station station = stationService.GetStationById((int)bikeBut.Tag);
            stationDetailForm.Hide();
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.BIKE);
            listBikeForm.Show("StationDetailForm");
        }
        #endregion
    }
}
