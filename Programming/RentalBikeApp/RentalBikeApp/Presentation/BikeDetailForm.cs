using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class BikeDetailForm : BaseForm
    {
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

        private ListBikeForm _listBikeForm;
        public ListBikeForm listBikeForm
        {
            get { return _listBikeForm; }
            set { _listBikeForm = value; }
        }

        public BikeDetailForm()
        {
            InitializeComponent("BikeDetailForm", "Bike Detail");
            DrawBaseForm();
            DrawBikeDetail();

            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
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

        private void RentBikeBut_Click(object sender, System.EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void HomePageBut_Click(object sender, System.EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        private void RentThisBikeBut_Click(object sender, System.EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void ReturnListBikeBut_Click(object sender, System.EventArgs e)
        {
            _listBikeForm.Show(this);
            this.Hide();
        }
    }
}
