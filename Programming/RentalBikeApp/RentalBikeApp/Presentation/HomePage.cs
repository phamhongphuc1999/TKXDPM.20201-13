using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class HomePage : Form
    {
        private StationService stationService;

        public HomePage()
        {
            stationService = new StationService();

            InitializeComponent();
            DrawBaseForm();
            RenderStationList(this.stationPnl);
        }

        public void RenderStationList(Panel pnl)
        {
            List<Station> stationList = stationService.GetListStations();

        }
    }
}
