using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class HomePageForm
    {
        public Panel stationPnl;
        public Label lineSearchLbl;

        /// <summary>
        /// Initialized control in HomePageForm
        /// </summary>
        public void DrawHomePage()
        {
            stationPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 130),
                Location = new Point(0, 50)
            };
            stationPnl.HorizontalScroll.Maximum = 0;
            stationPnl.AutoScroll = false;
            stationPnl.VerticalScroll.Visible = false;
            stationPnl.AutoScroll = true;
            lineSearchLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 50)
            };
            this.Controls.Add(stationPnl);
            this.Controls.Add(lineSearchLbl);
        }
    }
}