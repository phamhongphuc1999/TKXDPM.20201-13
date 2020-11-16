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
        private BikeDetailForm bikeDetailForm;
        private RentBikeForm rentBikeForm;
        private CardInformationForm cardInformationForm;

        public HomePageForm()
        {
            stationService = new StationService();

            stationDetailForm = new StationDetailForm();
            listBikeForm = new ListBikeForm();
            bikeDetailForm = new BikeDetailForm();
            rentBikeForm = new RentBikeForm();
            cardInformationForm = new CardInformationForm();

            CreateListBikeForm();
            CreateRentBikeForm();
            CreateStationDetailForm();
            CreateBikeDetailForm();
            CreateCardInformationForm();

            InitializeComponent("HomePageForm", "Home Page");
            DrawBaseForm();
            DrawHomePage();
            RenderStationList(this.stationPnl);
            this.StartPosition = FormStartPosition.CenterScreen;

            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        /// <summary>
        /// Initialized control in DetailForm as HomaPageForm's property
        /// </summary>
        private void CreateStationDetailForm()
        {
            stationDetailForm.homePageForm = this;
            stationDetailForm.rentBikeForm = rentBikeForm;
            stationDetailForm.listBikeForm = listBikeForm;
        }

        /// <summary>
        /// Initialized control in ListBikeForm as HomaPageForm's property
        /// </summary>
        private void CreateListBikeForm()
        {
            listBikeForm.homePageForm = this;
            listBikeForm.rentBikeForm = rentBikeForm;
            listBikeForm.bikeDetailForm = bikeDetailForm;
            listBikeForm.stationDetailForm = stationDetailForm;
        }

        /// <summary>
        /// Initialized control in BikeDetailForm as HomaPageForm's property
        /// </summary>
        private void CreateBikeDetailForm()
        {
            bikeDetailForm.homePageForm = this;
            bikeDetailForm.rentBikeForm = rentBikeForm;
            bikeDetailForm.listBikeForm = listBikeForm;
        }

        /// <summary>
        /// Initialized control in RentBikeForm as HomaPageForm's property
        /// </summary>
        private void CreateRentBikeForm()
        {
            rentBikeForm.homePageForm = this;
        }

        /// <summary>
        /// Initialized control in CardInformation as HomaPageForm's property
        /// </summary>
        private void CreateCardInformationForm()
        {
            cardInformationForm.homePageForm = this;
            cardInformationForm.rentBikeForm = rentBikeForm;
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
    }
}
