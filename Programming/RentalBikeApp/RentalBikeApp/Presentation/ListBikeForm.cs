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
        private BikeService bikeService;

        private event EventHandler but_Click;
        public event EventHandler But_Click
        {
            add { but_Click += value; }
            remove { but_Click -= value; }
        }

        public ListBikeForm()
        {
            bikeService = new BikeService();

            InitializeComponent("ListBikesForm", "List Bikes");
            DrawBaseForm();
            DrawListBikes();
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
                but.Click += but_Click;
                listBikePnl.Controls.Add(but);
            }
        }
    }
}
