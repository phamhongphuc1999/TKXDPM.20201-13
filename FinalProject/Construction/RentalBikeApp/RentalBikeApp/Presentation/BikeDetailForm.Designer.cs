using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class BikeDetailForm
    {
        private PictureBox avatarPb;
        private Panel bikeDetailPnl;
        private RichTextBox stationRtb;
        private Button rentThisBikeBut, viewRentingBut;
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
            avatarPb = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(20, 100),
                Size = new Size(300, 300)
            };
            qrCodeLbl = new Label()
            {
                Text = "Mã xe",
                Size = new Size(150, 40),
                Location = new Point(330, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            qrCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(290, 40),
                Location = new Point(490, 100),
                ReadOnly = true
            };
            categoryBikeLbl = new Label()
            {
                Text = "Loại xe",
                Size = new Size(150, 40),
                Location = new Point(330, 148),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            categoryBikeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(290, 40),
                Location = new Point(490, 148),
                ReadOnly = true
            };
            licenceLbl = new Label()
            {
                Text = "Biển số xe",
                Size = new Size(150, 40),
                Location = new Point(330, 196),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            licenceTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(290, 40),
                Location = new Point(490, 196),
                ReadOnly = true
            };
            manufactureLbl = new Label()
            {
                Text = "Hãng sản xuất",
                Size = new Size(150, 40),
                Location = new Point(330, 244),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            manufactureTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(290, 40),
                Location = new Point(490, 244),
                ReadOnly = true
            };
            powerLbl = new Label()
            {
                Text = "Lượng pin",
                Size = new Size(150, 40),
                Location = new Point(330, 292),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            powerTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(290, 40),
                Location = new Point(490, 292),
                ReadOnly = true
            };
            rentThisBikeBut = new Button()
            {
                Text = "Thuê xe này",
                Size = new Size(450, 50),
                Location = new Point(330, 350),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };
            viewRentingBut = new Button
            {
                Text = "Chi tiết",
                Size = new Size(450, 50),
                Location = new Point(330, 350),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };

            rentThisBikeBut.Click += RentThisBikeBut_Click;
            viewRentingBut.Click += ViewRentingBut_Click;

            bikeDetailPnl.Controls.Add(stationRtb);
            bikeDetailPnl.Controls.Add(statusBikeLbl);
            bikeDetailPnl.Controls.Add(avatarPb);
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
            bikeDetailPnl.Controls.Add(viewRentingBut);
            this.Controls.Add(bikeDetailPnl);
        }
    }
}