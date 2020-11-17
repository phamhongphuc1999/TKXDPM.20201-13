using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class ReturnBikeForm
    {
        public TextBox searchTxt;
        public Panel returnBikePnl, listStationPnl;
        public Button cancelBut;

        /// <summary>
        /// Initialized control in ReturnBikeForm
        /// </summary>
        public void DrawReturnBikeForm()
        {
            returnBikePnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            searchTxt = new TextBox()
            {
                Multiline = true,
                PlaceholderText = "Nhập tên bãi xe muốn trả xe",
                Size = new Size(this.ClientSize.Width - 40, 40),
                Location = new Point(20, 5)
            };
            listStationPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, 295),
                Location = new Point(0, 55)
            };
            listStationPnl.HorizontalScroll.Maximum = 0;
            listStationPnl.AutoScroll = false;
            listStationPnl.VerticalScroll.Visible = false;
            listStationPnl.AutoScroll = true;
            cancelBut = new Button()
            {
                Text = "Hủy thanh toán",
                Size = new Size(250, 50),
                Location = new Point(480, 365),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };

            cancelBut.Click += CancelBut_Click;

            returnBikePnl.Controls.Add(searchTxt);
            returnBikePnl.Controls.Add(listStationPnl);
            returnBikePnl.Controls.Add(cancelBut);
            this.Controls.Add(returnBikePnl);
        }
    }
}