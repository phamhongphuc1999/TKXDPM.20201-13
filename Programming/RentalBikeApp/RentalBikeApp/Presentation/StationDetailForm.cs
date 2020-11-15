using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class StationDetailForm : BaseForm
    {
        private StationService stationService;
        private ListBikeForm listBikeForm;

        public StationDetailForm()
        {
            stationService = new StationService();
            listBikeForm = new ListBikeForm();

            InitializeComponent("StationDetailForm", "Station Detail");
            DrawBaseForm();
            DrawStationDetail();
            homePageBut.Click += HomePageBut_Click;
        }

        public void FillStationDetail(Station station)
        {
            nameTxt.Text = station.NameStation;
            addressTxt.Text = station.AddressStation;
            areaTxt.Text = station.AreaStaion.ToString();
            numberTxt.Text = station.NumberOfBike.ToString();
            distanceTxt.Text = "100 m";
            timeTxt.Text = "10";

            bikeBut.Tag = station.StationId;
            electricBut.Tag = station.StationId;
            tandemBut.Tag = station.StationId;
        }

        private void HomePageBut_Click(object sender, System.EventArgs e)
        {
            HomePageForm homePageForm = Application.OpenForms["HomePageForm"] as HomePageForm;
            homePageForm.RenderStationList(homePageForm.stationPnl);
            homePageForm.Show();
            this.Hide();
        }

        private void ReturnHomePageBut_Click(object sender, System.EventArgs e)
        {
            Application.OpenForms["HomePageForm"].Show();
            this.Hide();
        }

        private void ElectricBut_Click(object sender, System.EventArgs e)
        {
            Station station = stationService.GetStationById((int)electricBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show("StationDetailForm");
            this.Hide();
        }

        private void TandemBut_Click(object sender, System.EventArgs e)
        {
            Station station = stationService.GetStationById((int)tandemBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show("StationDetailForm");
            this.Hide();
        }

        private void BikeBut_Click(object sender, System.EventArgs e)
        {
            Station station = stationService.GetStationById((int)bikeBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show("StationDetailForm");
            this.Hide();
        }
    }
}
