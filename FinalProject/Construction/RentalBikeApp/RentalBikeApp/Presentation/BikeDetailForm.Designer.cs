using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class BikeDetailForm
    {
        private Panel bikeDetailPnl;
        private RichTextBox stationRtb;
        private Button rentThisBikeBut;
        private TextBox qrCodeTxt, categoryBikeTxt, licenceTxt, manufactureTxt, powerTxt;
        private Label qrCodeLbl, categoryBikeLbl, licenceLbl, manufactureLbl, powerLbl, statusBikeLbl;

        /// <summary>
        /// Initialized control in BikeDetailForm
        /// </summary>
        public void DrawBikeDetail()
        {
            bikeDetailPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            stationRtb = new RichTextBox()
            {
                Size = new Size(bikeDetailPnl.Width - 140, 80),
                Location = new Point(20, 5),
                SelectionAlignment = HorizontalAlignment.Center,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            statusBikeLbl = new Label()
            {
                Size = new Size(100, 80),
                Location = new Point(bikeDetailPnl.Width - 120, 5),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            qrCodeLbl = new Label()
            {
                Text = "Mã xe",
                Size = new Size(150, 40),
                Location = new Point(20, 90),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            qrCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(600, 40),
                Location = new Point(180, 90),
                ReadOnly = true
            };
            categoryBikeLbl = new Label()
            {
                Text = "Loại xe",
                Size = new Size(150, 40),
                Location = new Point(20, 138),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            categoryBikeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(600, 40),
                Location = new Point(180, 138),
                ReadOnly = true
            };
            licenceLbl = new Label()
            {
                Text = "Biển số xe",
                Size = new Size(150, 40),
                Location = new Point(20, 186),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            licenceTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(600, 40),
                Location = new Point(180, 186),
                ReadOnly = true
            };
            manufactureLbl = new Label()
            {
                Text = "Hãng sản xuất",
                Size = new Size(150, 40),
                Location = new Point(20, 234),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            manufactureTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(600, 40),
                Location = new Point(180, 234),
                ReadOnly = true
            };
            powerLbl = new Label()
            {
                Text = "Lượng pin",
                Size = new Size(150, 40),
                Location = new Point(20, 282),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            powerTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(600, 40),
                Location = new Point(180, 282),
                ReadOnly = true
            };
            rentThisBikeBut = new Button()
            {
                Text = "Thuê xe này",
                Size = new Size(250, 50),
                Location = new Point(530, 362),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };

            rentThisBikeBut.Click += RentThisBikeBut_Click;

            bikeDetailPnl.Controls.Add(stationRtb);
            bikeDetailPnl.Controls.Add(statusBikeLbl);
            bikeDetailPnl.Controls.Add(qrCodeLbl);
            bikeDetailPnl.Controls.Add(qrCodeTxt);
            bikeDetailPnl.Controls.Add(categoryBikeLbl);
            bikeDetailPnl.Controls.Add(categoryBikeTxt);
            bikeDetailPnl.Controls.Add(licenceLbl);
            bikeDetailPnl.Controls.Add(licenceTxt);
            bikeDetailPnl.Controls.Add(manufactureLbl);
            bikeDetailPnl.Controls.Add(manufactureTxt);
            bikeDetailPnl.Controls.Add(powerLbl);
            bikeDetailPnl.Controls.Add(powerTxt);
            bikeDetailPnl.Controls.Add(rentThisBikeBut);
            this.Controls.Add(bikeDetailPnl);
        }
    }
}