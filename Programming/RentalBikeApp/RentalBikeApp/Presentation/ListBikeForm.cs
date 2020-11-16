using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class ListBikeForm : BaseForm
    {
        private StationService stationService;
        private BikeService bikeService;

        private HomePageForm _homePageForm;
        public HomePageForm homePageForm
        {
            get { return _homePageForm; }
            set { _homePageForm = value; }
        }

        private BikeDetailForm _bikeDetailForm;
        public BikeDetailForm bikeDetailForm
        {
            get { return _bikeDetailForm; }
            set { _bikeDetailForm = value; }
        }

        private RentBikeForm _rentBikeForm;
        public RentBikeForm rentBikeForm
        {
            get { return _rentBikeForm; }
            set { _rentBikeForm = value; }
        }

        private StationDetailForm _stationDetailForm;
        public StationDetailForm stationDetailForm
        {
            get { return _stationDetailForm; }
            set { _stationDetailForm = value; }
        }

        public ListBikeForm()
        {
            stationService = new StationService();
            bikeService = new BikeService();

            InitializeComponent("ListBikesForm", "List Bikes");
            DrawBaseForm();
            DrawListBikes();
            homePageBut.Click += HomePageBut_Click;
            rentBikeBut.Click += RentBikeBut_Click;
        }

        
        /// <summary>
        /// Fill ListBikeForm with bike's information in specified category
        /// </summary>
        /// <param name="station">The station contain list bike is displayed</param>
        /// <param name="category">The specified bike's category</param>
        public void FillListBikes(Station station, Config.SQL.BikeCategory category)
        {
            listBikePnl.Controls.Clear();
            List<Bike> bikesList = bikeService.GetListBikesInStation(station.StationId, category);
            int count = bikesList.Count(x => !x.BikeStatus);
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

        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Bike bike = bikeService.GetBikeById((int)but.Tag);
            _bikeDetailForm.FillBikeInformation(Config.CURRENT_STATION, bike);
            _bikeDetailForm.Show(this);
            this.Hide();
            bikeDetailForm.Show();
        }

        private void RentBikeBut_Click(object sender, EventArgs e)
        {
            _rentBikeForm.Show(this);
            this.Hide();
        }

        private void HomePageBut_Click(object sender, EventArgs e)
        {
            _homePageForm.RenderStationList(_homePageForm.stationPnl);
            _homePageForm.Show(this);
            this.Hide();
        }

        private void ReturnStationBut_Click(object sender, EventArgs e)
        {
            stationDetailForm.Show(this);
            this.Hide();
        }
    }
}
