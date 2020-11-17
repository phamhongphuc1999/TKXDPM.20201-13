using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class ReturnBikeForm : BaseForm
    {
        private StationService stationService;

        public ReturnBikeForm()
        {
            stationService = new StationService();

            InitializeComponent("ReturnBikeForm", "Return Bike");
            DrawBaseForm();
            DrawReturnBikeForm();
            RenderStationList(this.listStationPnl);
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

        private void But_Click(object sender, System.EventArgs e)
        {
            
        }

        private void CancelBut_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
