using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class StationDetailForm : BaseForm
    {
        public StationDetailForm()
        {
            InitializeComponent("Station Detail");
            DrawBaseForm();
            DrawStationDetail();
        }

        public void FillStationDetail(Station station)
        {
            nameTxt.Text = station.NameStation;
            addressTxt.Text = station.AddressStation;
            areaTxt.Text = station.AreaStaion.ToString();
            numberTxt.Text = station.NumberOfBike.ToString();
            distanceTxt.Text = "100 m";
            timeTxt.Text = "10";
        }
    }
}
