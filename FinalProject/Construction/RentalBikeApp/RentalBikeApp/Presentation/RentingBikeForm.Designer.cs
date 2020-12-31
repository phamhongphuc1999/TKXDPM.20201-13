using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class RentingBikeForm
    {
        private Panel rentingBikePnl;
        private Label rentingQrCodeLbl, rentingCategoryLbl, rentingLicenseLbl, rentingManufactureLbl;
        private TextBox rentingQrCodeTxt, rentingCategoryTxt, rentingLicenseTxt, rentingManufactureTxt;
        private Label rentingTimedRentLbl, rentingRemainPowerLbl, rentingTimedRentValueLbl, rentingRemainPowerValueLbl;
        private Label rentingHorizontalLineLbl, rentingHorizontalLineLbl1;
        private Button rentingSelectReceiveStationBut;
        private PictureBox rentingAvatarPb;
        private Timer rentBikeTmr;

        /// <summary>
        /// Display RentBikeform when user is renting bike
        /// </summary>
        private void DrawRentingBikeForm()
        {
            rentBikeTmr = new Timer()
            {
                Interval = 1000
            };
            rentingBikePnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            rentingHorizontalLineLbl1 = new Label
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 80)
            };
            rentingAvatarPb = new PictureBox()
            {
                Location = new Point(20, 95),
                Size = new Size(205, 205),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            rentingQrCodeLbl = new Label()
            {
                Text = "Mã xe",
                Size = new Size(150, 40),
                Location = new Point(240, 95),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingQrCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(370, 40),
                Location = new Point(410, 95),
                ReadOnly = true
            };
            rentingCategoryLbl = new Label()
            {
                Text = "Loại xe",
                Size = new Size(150, 40),
                Location = new Point(240, 150),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingCategoryTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(370, 40),
                Location = new Point(410, 150),
                ReadOnly = true
            };
            rentingLicenseLbl = new Label()
            {
                Text = "Biển số xe",
                Size = new Size(150, 40),
                Location = new Point(240, 205),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingLicenseTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(370, 40),
                Location = new Point(410, 205),
                ReadOnly = true
            };
            rentingManufactureLbl = new Label()
            {
                Text = "Hãng sản xuất",
                Size = new Size(150, 40),
                Location = new Point(240, 260),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingManufactureTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(370, 40),
                Location = new Point(410, 260),
                ReadOnly = true
            };
            rentingTimedRentLbl = new Label()
            {
                Size = new Size(195, 40),
                Location = new Point(20, 20),
                Text = "Thời gian đã thuê",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingTimedRentValueLbl = new Label()
            {
                Size = new Size(185, 40),
                Location = new Point(220, 20),
                Text = "0:00:00",
                TextAlign = ContentAlignment.MiddleCenter
            };
            rentingRemainPowerLbl = new Label()
            {
                Text = "Lượng pin còn lại",
                Size = new Size(195, 40),
                Location = new Point(400, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingRemainPowerValueLbl = new Label()
            {
                Text = "100%",
                Size = new Size(195, 40),
                Location = new Point(585, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            rentingHorizontalLineLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 325)
            };
            rentingSelectReceiveStationBut = new Button()
            {
                Size = new Size(300, 50),
                Location = new Point(250, 350),
                Text = "Chọn bãi xe để trả",
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };

            rentBikeTmr.Tick += RentBikeTmr_Tick;
            rentingSelectReceiveStationBut.Click += RentingSelectReceiveStationBut_Click;

            rentingBikePnl.Controls.Add(rentingQrCodeLbl);
            rentingBikePnl.Controls.Add(rentingQrCodeTxt);
            rentingBikePnl.Controls.Add(rentingAvatarPb);
            rentingBikePnl.Controls.Add(rentingCategoryLbl);
            rentingBikePnl.Controls.Add(rentingCategoryTxt);
            rentingBikePnl.Controls.Add(rentingLicenseLbl);
            rentingBikePnl.Controls.Add(rentingLicenseTxt);
            rentingBikePnl.Controls.Add(rentingManufactureLbl);
            rentingBikePnl.Controls.Add(rentingManufactureTxt);
            rentingBikePnl.Controls.Add(rentingHorizontalLineLbl1);
            rentingBikePnl.Controls.Add(rentingTimedRentLbl);
            rentingBikePnl.Controls.Add(rentingTimedRentValueLbl);
            rentingBikePnl.Controls.Add(rentingRemainPowerLbl);
            rentingBikePnl.Controls.Add(rentingRemainPowerValueLbl);
            rentingBikePnl.Controls.Add(rentingHorizontalLineLbl);
            rentingBikePnl.Controls.Add(rentingSelectReceiveStationBut);
            this.Controls.Add(rentingBikePnl);
        }
    }
}