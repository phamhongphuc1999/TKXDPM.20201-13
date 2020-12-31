using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class RentBikeInfoForm
    {
        private Panel rentBikeInfoPnl;
        private Label rentBikeInfoQrCodeLbl, rentBikeInfoCategoryLbl, rentBikeInfoLicenseLbl, rentBikeInfoDepositLbl;
        private TextBox rentBikeInfoQrCodeTxt, rentBikeInfoCategoryTxt, rentBikeInfoLicenseTxt, rentBikeInfoDepositTxt;
        private Button rentBikeInfoDetailBut, rentBikeInfoRentThisBikeBut;
        private Label rentBikeLineLbl;

        /// <summary>
        /// Display RentBikeForm to display bike information
        /// </summary>
        private void DrawRentBikeInfoForm()
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

            rentBikeInfoDetailBut.Click += RentBikeInfoDetailBut_Click;
            rentBikeInfoRentThisBikeBut.Click += RentBikeInfoRentThisBikeBut_Click;

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
            this.Controls.Add(rentBikeInfoPnl);
        }
    }
}