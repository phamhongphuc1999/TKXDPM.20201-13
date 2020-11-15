using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class ListBikeForm : BaseForm
    {
        private Station station;
        private BikeService bikeService;
        private BikeDetailForm bikeDetailForm;

        public ListBikeForm()
        {
            bikeService = new BikeService();
            bikeDetailForm = new BikeDetailForm();

            InitializeComponent("ListBikesForm", "List Bikes");
            DrawBaseForm();
            DrawListBikes();

            homePageBut.Click += HomePageBut_Click;
        }

        public void FillListBikes(Station station, Config.SQL.BikeCategory category)
        {
            this.station = station;
            listBikePnl.Controls.Clear();
            List<Bike> bikesList = bikeService.GetListBikesInStation(station.StationId, category);
            int count = bikesList.Count(x => x.BikeStatus);
            if (category == Config.SQL.BikeCategory.BIKE) categoryBikeRtb.Text = "Xe đạp thường";
            else if (category == Config.SQL.BikeCategory.ELECTRIC) categoryBikeRtb.Text = "Xe đạp điện";
            else categoryBikeRtb.Text = "Xe đạp đôi";
            numberRtb.Text = string.Format("Còn lại {0} xe", count.ToString());
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

        private void But_Click(object sender, System.EventArgs e)
        {
            Button but = sender as Button;
            Bike bike = bikeService.GetBikeById((int)but.Tag);
            bikeDetailForm.FillBikeInformation(station, bike);
            bikeDetailForm.Show("ListBikesForm");
            this.Hide();
            bikeDetailForm.Show();
        }

        private void ReturnStationBut_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Application.OpenForms["StationDetailForm"].Show();
        }

        private void HomePageBut_Click(object sender, System.EventArgs e)
        {
            HomePageForm homePageForm = Application.OpenForms["HomePageForm"] as HomePageForm;
            homePageForm.RenderStationList(homePageForm.stationPnl);
            homePageForm.Show();
            this.Hide();
        }
    }
}
