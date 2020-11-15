using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class BikeDetailForm : BaseForm
    {
        public BikeDetailForm()
        {
            InitializeComponent("BikeDetailForm", "Bike Detail");
            DrawBaseForm();
            DrawBikeDetail();
        }

        public void FillBikeInformation(Station station, Bike bike)
        {
            stationRtb.Text = string.Format("{0}\n{1}", station.NameStation, station.AddressStation);
            qrCodeTxt.Text = bike.QRCode;
            licenceTxt.Text = bike.LicensePlate;
            manufactureTxt.Text = bike.Manufacturer;
            powerTxt.Text = "";
            if (bike.Category == "bike") categoryBikeTxt.Text = "Xe đạp thường";
            else if (bike.Category == "tandem") categoryBikeTxt.Text = "Xe đạp đôi";
            else
            {
                categoryBikeTxt.Text = "Xe đạp điện";
                powerTxt.Text = "100%";
            }
        }

        private void RentThisBikeBut_Click(object sender, System.EventArgs e)
        {
            
        }

        private void ReturnListBikeBut_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
