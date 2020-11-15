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

        /// <summary>
        /// Fill bike form with bike's information and station's information
        /// </summary>
        /// <param name="station">The station contain the specified bike</param>
        /// <param name="bike">The specified bike</param>
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
    }
}
