using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class StationDetailForm
    {
        private Panel infoPnl;
        private Label nameLbl, addressLbl, areaLbl, numberLbl, distanceLbl, timeLbl;
        private TextBox nameTxt, addressTxt, areaTxt, numberTxt, distanceTxt, timeTxt;
        public Button bikeBut, tandemBut, electricBut, returnHomePageBut;

        /// <summary>
        /// Initialized control in StationDetailForm
        /// </summary>
        public void DrawStationDetail()
        {
            infoPnl = new Panel()
            {
                Location = new Point(0, 0),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80)
            };
            nameLbl = new Label()
            {
                Text = "Tên",
                Size = new Size(120, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            nameTxt = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(600, 40),
                Location = new Point(180, 15)
            };
            addressLbl = new Label()
            {
                Text = "Địa chỉ",
                Size = new Size(120, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 68),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            addressTxt = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(600, 40),
                Location = new Point(180, 68)
            };
            areaLbl = new Label()
            {
                Text = "Diện tích",
                Size = new Size(120, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 121),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            areaTxt = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(600, 40),
                Location = new Point(180, 121)
            };
            numberLbl = new Label()
            {
                Text = "Số xe",
                Size = new Size(120, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 174),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            numberTxt = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(600, 40),
                Location = new Point(180, 174)
            };
            distanceLbl = new Label()
            {
                Text = "Khoảng cách",
                Size = new Size(120, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 227),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            distanceTxt = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(600, 40),
                Location = new Point(180, 227)
            };
            timeLbl = new Label()
            {
                Text = "Thời gian",
                Size = new Size(120, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 280),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            timeTxt = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(600, 40),
                Location = new Point(180, 280)
            };
            bikeBut = new Button()
            {
                Size = new Size(150, 50),
                Location = new Point(20, 345),
                Text = "Xe đạp đơn",
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            tandemBut = new Button()
            {
                Size = new Size(150, 50),
                Location = new Point(190, 345),
                Text = "Xe đạp đôi",
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            electricBut = new Button()
            {
                Size = new Size(150, 50),
                Location = new Point(360, 345),
                Text = "Xe đạp điện",
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            returnHomePageBut = new Button()
            {
                Size = new Size(250, 50),
                Location = new Point(530, 345),
                Text = "Quay lại trang chủ",
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };

            returnHomePageBut.Click += ReturnHomePageBut_Click;
            bikeBut.Click += BikeBut_Click;
            electricBut.Click += ElectricBut_Click;
            tandemBut.Click += TandemBut_Click;

            infoPnl.Controls.Add(nameLbl);
            infoPnl.Controls.Add(nameTxt);
            infoPnl.Controls.Add(addressLbl);
            infoPnl.Controls.Add(addressTxt);
            infoPnl.Controls.Add(areaLbl);
            infoPnl.Controls.Add(areaTxt);
            infoPnl.Controls.Add(numberLbl);
            infoPnl.Controls.Add(numberTxt);
            infoPnl.Controls.Add(distanceLbl);
            infoPnl.Controls.Add(distanceTxt);
            infoPnl.Controls.Add(timeLbl);
            infoPnl.Controls.Add(timeTxt);
            infoPnl.Controls.Add(bikeBut);
            infoPnl.Controls.Add(tandemBut);
            infoPnl.Controls.Add(electricBut);
            infoPnl.Controls.Add(returnHomePageBut);
            this.Controls.Add(infoPnl);
        }
    }
}