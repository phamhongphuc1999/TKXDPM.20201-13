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
        private BikeService bikeService;

        private StationDetailForm stationDetailForm;
        private ListBikeForm listBikeForm;
        private BikeDetailForm bikeDetailForm;
        private RentBikeForm rentBikeForm;
        private CardInformationForm cardInformationForm;

        public HomePageForm()
        {
            stationService = new StationService();
            bikeService = new BikeService();

            CreateStationDetailForm();
            CreateListBikeForm();
            CreateBikeDetailForm();
            CreateRentBikeForm();
            CreateCardInformationForm();

            InitializeComponent("HomePageForm", "Home Page");
            DrawBaseForm();
            DrawHomePage();
            RenderStationList(this.stationPnl);
            this.StartPosition = FormStartPosition.CenterScreen;

            homePageBut.Click += HomePageBut_Click;
        }

        /// <summary>
        /// Initialized control in DetailForm as HomaPageForm's property
        /// </summary>
        private void CreateStationDetailForm()
        {
            stationDetailForm = new StationDetailForm();
            stationDetailForm.homePageBut.Click += HomePageBut_Click;
            stationDetailForm.rentBikeBut.Click += RentBikeBut_Click;
            stationDetailForm.returnHomePageBut.Click += StationDetail_ReturnHomePageBut_Click;
            stationDetailForm.tandemBut.Click += StationDetail_TandemBut_Click;
            stationDetailForm.electricBut.Click += StationDetail_ElectricBut_Click;
            stationDetailForm.bikeBut.Click += StationDetail_BikeBut_Click;
        }

        /// <summary>
        /// Initialized control in ListBikeForm as HomaPageForm's property
        /// </summary>
        private void CreateListBikeForm()
        {
            listBikeForm = new ListBikeForm();
            listBikeForm.But_Click += ListBike_But_Click;
            listBikeForm.homePageBut.Click += HomePageBut_Click;
            listBikeForm.rentBikeBut.Click += RentBikeBut_Click;
            listBikeForm.returnStationBut.Click += ListBike_ReturnStationBut_Click;
        }

        /// <summary>
        /// Initialized control in BikeDetailForm as HomaPageForm's property
        /// </summary>
        private void CreateBikeDetailForm()
        {
            bikeDetailForm = new BikeDetailForm();
            bikeDetailForm.homePageBut.Click += HomePageBut_Click;
            bikeDetailForm.rentBikeBut.Click += RentBikeBut_Click;
            bikeDetailForm.rentThisBikeBut.Click += BikeDetail_RentThisBikeBut_Click;
            bikeDetailForm.returnListBikeBut.Click += BikeDetail_ReturnListBikeBut_Click;
        }

        /// <summary>
        /// Initialized control in RentBikeForm as HomaPageForm's property
        /// </summary>
        private void CreateRentBikeForm()
        {
            rentBikeForm = new RentBikeForm();
            rentBikeForm.homePageBut.Click += HomePageBut_Click;
            rentBikeForm.rentBikeBut.Click += RentBikeBut_Click;
        }

        /// <summary>
        /// Initialized control in CardInformation as HomaPageForm's property
        /// </summary>
        private void CreateCardInformationForm()
        {
            cardInformationForm = new CardInformationForm();
            cardInformationForm.homePageBut.Click += HomePageBut_Click;
            cardInformationForm.rentBikeBut.Click += RentBikeBut_Click;
        }

        /// <summary>
        /// Get station in the database and display in specified panel
        /// </summary>
        /// <param name="pnl">The specified panel</param>
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

        #region Base Form Event
        private void HomePageBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Form form = but.Parent as Form;
            this.RenderStationList(this.stationPnl);
            this.Show(form);
            bool check = form is HomePageForm;
            if (!check) form.Hide();
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Form form = but.Parent as Form;
            this.RenderStationList(this.stationPnl);
            rentBikeForm.Show(form);
            bool check = form is RentBikeForm;
            if (!check) form.Hide();
        }
        #endregion

        #region Home Page Form Event
        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Station station = stationService.GetStationById((int)but.Tag);
            this.Hide();
            stationDetailForm.FillStationDetail(station);
            Config.CURRENT_STATION = station;
            stationDetailForm.Show(this);
        }
        #endregion

        #region Station Detail Form Event
        private void StationDetail_ReturnHomePageBut_Click(object sender, EventArgs e)
        {
            this.Show(stationDetailForm);
            stationDetailForm.Hide();
        }

        private void StationDetail_TandemBut_Click(object sender, EventArgs e)
        {
            Button tandemBut = sender as Button;
            Station station = stationService.GetStationById((int)tandemBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.TANDEM);
            listBikeForm.Show(stationDetailForm);
            stationDetailForm.Hide();
        }

        private void StationDetail_BikeBut_Click(object sender, EventArgs e)
        {
            Button bikeBut = sender as Button;
            Station station = stationService.GetStationById((int)bikeBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.BIKE);
            listBikeForm.Show(stationDetailForm);
            stationDetailForm.Hide();
        }

        private void StationDetail_ElectricBut_Click(object sender, EventArgs e)
        {
            Button electricBut = sender as Button;
            Station station = stationService.GetStationById((int)electricBut.Tag);
            listBikeForm.FillListBikes(station, Config.SQL.BikeCategory.ELECTRIC);
            listBikeForm.Show(stationDetailForm);
            stationDetailForm.Hide();
        }
        #endregion

        #region List Bike Form Event
        private void ListBike_But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Bike bike = bikeService.GetBikeById((int)but.Tag);
            bikeDetailForm.FillBikeInformation(Config.CURRENT_STATION, bike);
            bikeDetailForm.Show(listBikeForm);
            listBikeForm.Hide();
            bikeDetailForm.Show();
        }

        private void ListBike_ReturnStationBut_Click(object sender, EventArgs e)
        {
            stationDetailForm.Show();
            listBikeForm.Hide();
        }
        #endregion

        #region Bike Detail Form Event
        private void BikeDetail_ReturnListBikeBut_Click(object sender, EventArgs e)
        {
            listBikeForm.Show(bikeDetailForm);
            bikeDetailForm.Hide();
        }

        private void BikeDetail_RentThisBikeBut_Click(object sender, EventArgs e)
        {
            cardInformationForm.Show(bikeDetailForm);
            bikeDetailForm.Hide();
        }
        #endregion
    }
}
