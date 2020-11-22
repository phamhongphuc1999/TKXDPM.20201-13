using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class RentBikeForm
    {
        public Panel rentBikePnl, rentingBikePnl, rentBikeInfoPnl;

        /// <summary>
        /// Control in RentBikePanel
        /// </summary>
        public TextBox rentBikeQrCodeTxt;
        public Button rentBikeRentBut;

        /// <summary>
        /// Control in RentBikeInfoPanel
        /// </summary>
        public Label rentBikeInfoQrCodeLbl, rentBikeInfoCategoryLbl, rentBikeInfoLicenseLbl, rentBikeInfoDepositLbl;
        public TextBox rentBikeInfoQrCodeTxt, rentBikeInfoCategoryTxt, rentBikeInfoLicenseTxt, rentBikeInfoDepositTxt;
        public Button rentBikeInfoDetailBut, rentBikeInfoRentThisBikeBut;
        public Label rentBikeLineLbl;

        /// <summary>
        /// Control in RentingBikePanel
        /// </summary>
        public Label rentingQrCodeLbl, rentingCategoryLbl, rentingLicenseLbl, rentingManufactureLbl;
        public TextBox rentingQrCodeTxt, rentingCategoryTxt, rentingLicenseTxt, rentingManufactureTxt;
        public Label rentingTimedRentLbl, rentingRemainPowerLbl, rentingTimedRentValueLbl, rentingRemainPowerValueLbl;
        public Label rentingHorizontalLineLbl, rentingVerticalLineLbl;
        public Button rentingSelectReceiveStationBut;
        public Timer rentBikeTmr;

        /// <summary>
        /// Display RentBikeForm to enter QRcode
        /// </summary>
        public void DrawRentBikeForm()
        {
            rentBikePnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            rentBikeQrCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(rentBikePnl.ClientSize.Width - 40, 40),
                Location = new Point(20, 150),
                PlaceholderText = "Nhập mã QR code của xe"
            };
            rentBikeRentBut = new Button()
            {
                Text = "Thuê",
                Size = new Size(300, 50),
                Location = new Point(250, 230),
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };

            rentBikeRentBut.Click += RentBikeRentBut_Click;

            rentBikePnl.Controls.Add(rentBikeQrCodeTxt);
            rentBikePnl.Controls.Add(rentBikeRentBut);
            this.Controls.Add(rentBikePnl);
        }

        /// <summary>
        /// Display RentBikeform when user is renting bike
        /// </summary>
        public void DrawRentingBikeForm()
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
            rentingQrCodeLbl = new Label()
            {
                Text = "Mã xe",
                Size = new Size(150, 40),
                Location = new Point(20, 15),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingQrCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(355, 40),
                Location = new Point(190, 15),
                ReadOnly = true
            };
            rentingCategoryLbl = new Label()
            {
                Text = "Loại xe",
                Size = new Size(150, 40),
                Location = new Point(20, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingCategoryTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(355, 40),
                Location = new Point(190, 70),
                ReadOnly = true
            };
            rentingLicenseLbl = new Label()
            {
                Text = "Biển số xe",
                Size = new Size(150, 40),
                Location = new Point(20, 125),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingLicenseTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(355, 40),
                Location = new Point(190, 125),
                ReadOnly = true
            };
            rentingManufactureLbl = new Label()
            {
                Text = "Hãng sản xuất",
                Size = new Size(150, 40),
                Location = new Point(20, 180),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingManufactureTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(355, 40),
                Location = new Point(190, 180),
                ReadOnly = true
            };
            rentingVerticalLineLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(4, 235),
                Location = new Point(565, 0)
            };
            rentingTimedRentLbl = new Label()
            {
                Size = new Size(195, 40),
                Location = new Point(585, 15),
                Text = "Thời gian đã thuê",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingTimedRentValueLbl = new Label()
            {
                Size = new Size(195, 40),
                Location = new Point(585, 70),
                Text = "00:00:00",
                TextAlign = ContentAlignment.MiddleCenter
            };
            rentingRemainPowerLbl = new Label()
            {
                Text = "Lượng pin còn lại",
                Size = new Size(195, 40),
                Location = new Point(585, 125),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentingRemainPowerValueLbl = new Label()
            {
                Text = "100%",
                Size = new Size(195, 40),
                Location = new Point(585, 180),
                TextAlign = ContentAlignment.MiddleCenter
            };
            rentingHorizontalLineLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 235)
            };
            rentingSelectReceiveStationBut = new Button()
            {
                Size = new Size(300, 50),
                Location = new Point(250, 300),
                Text = "Chọn bãi xe để trả",
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };

            rentBikeTmr.Tick += RentBikeTmr_Tick;
            rentingSelectReceiveStationBut.Click += RentingSelectReceiveStationBut_Click;

            rentingBikePnl.Controls.Add(rentingQrCodeLbl);
            rentingBikePnl.Controls.Add(rentingQrCodeTxt);
            rentingBikePnl.Controls.Add(rentingCategoryLbl);
            rentingBikePnl.Controls.Add(rentingCategoryTxt);
            rentingBikePnl.Controls.Add(rentingLicenseLbl);
            rentingBikePnl.Controls.Add(rentingLicenseTxt);
            rentingBikePnl.Controls.Add(rentingManufactureLbl);
            rentingBikePnl.Controls.Add(rentingManufactureTxt);
            rentingBikePnl.Controls.Add(rentingVerticalLineLbl);
            rentingBikePnl.Controls.Add(rentingTimedRentLbl);
            rentingBikePnl.Controls.Add(rentingTimedRentValueLbl);
            rentingBikePnl.Controls.Add(rentingRemainPowerLbl);
            rentingBikePnl.Controls.Add(rentingRemainPowerValueLbl);
            rentingBikePnl.Controls.Add(rentingHorizontalLineLbl);
            rentingBikePnl.Controls.Add(rentingSelectReceiveStationBut);
            this.Controls.Add(rentingBikePnl);
        }

        /// <summary>
        /// Display RentBikeForm to display bike information
        /// </summary>
        public void DrawRentBikeInfoForm()
        {
            rentBikeInfoPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            rentBikeInfoQrCodeLbl = new Label()
            {
                Text = "Mã xe",
                Size = new Size(150, 40),
                Location = new Point(20, 15),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentBikeInfoQrCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 15),
                ReadOnly = true
            };
            rentBikeInfoCategoryLbl = new Label()
            {
                Text = "Loại xe",
                Size = new Size(150, 40),
                Location = new Point(20, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentBikeInfoCategoryTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 70),
                ReadOnly = true
            };
            rentBikeInfoLicenseLbl = new Label()
            {
                Text = "Biển số xe",
                Size = new Size(150, 40),
                Location = new Point(20, 125),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentBikeInfoLicenseTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 125),
                ReadOnly = true
            };
            rentBikeInfoDepositLbl = new Label()
            {
                Text = "Tiền cọc",
                Size = new Size(150, 40),
                Location = new Point(20, 180),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentBikeInfoDepositTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 180),
                ReadOnly = true
            };
            rentBikeInfoDetailBut = new Button()
            {
                Text = "Xem thông tin chi tiết của xe này",
                Size = new Size(400, 50),
                Location = new Point(380, 260),
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            rentBikeLineLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 330)
            };
            rentBikeInfoRentThisBikeBut = new Button()
            {
                Text = "Thuê xe này",
                Size = new Size(400, 50),
                Location = new Point(380, 350),
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            rentBikeInfoPnl.Controls.Add(rentBikeInfoQrCodeLbl);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoQrCodeTxt);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoCategoryLbl);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoCategoryTxt);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoLicenseLbl);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoLicenseTxt);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoDepositLbl);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoDepositTxt);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoDetailBut);
            rentBikeInfoPnl.Controls.Add(rentBikeLineLbl);
            rentBikeInfoPnl.Controls.Add(rentBikeInfoRentThisBikeBut);

            rentBikeInfoDetailBut.Click += RentBikeInfoDetailBut_Click;
            rentBikeInfoRentThisBikeBut.Click += RentBikeInfoRentThisBikeBut_Click;

            this.Controls.Add(rentBikeInfoPnl);
        }
    }
}