using System;

namespace RentalBikeApp.Presentation
{
    public partial class RentBikeForm : BaseForm
    {
        private HomePageForm _homePageForm;
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        public RentBikeForm()
        {
            InitializeComponent("RentBikeForm", "Rent Bike");
            DrawBaseForm();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
        }

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }
    }
}
