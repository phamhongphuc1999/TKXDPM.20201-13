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
        private CardInformationForm cardInformationForm;

        public HomePageForm()
        {
            stationService = new StationService();
            cardInformationForm = new CardInformationForm();
            stationDetailForm = new StationDetailForm();

            InitializeComponent("HomePageForm", "Home Page");
            DrawBaseForm();
            DrawHomePage();
            RenderStationList(this.stationPnl);
            this.StartPosition = FormStartPosition.CenterScreen;

            homePageBut.Click += HomePageBut_Click;
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

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            this.RenderStationList(stationPnl);
        }
    }
}
