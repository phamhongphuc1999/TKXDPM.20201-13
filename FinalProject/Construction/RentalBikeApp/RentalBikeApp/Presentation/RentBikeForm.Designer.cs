using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class RentBikeForm
    {
        private Panel rentBikePnl;
        private TextBox rentBikeQrCodeTxt;
        private Button rentBikeRentBut;

        /// <summary>
        /// Display RentBikeForm to enter QRcode
        /// </summary>
        private void DrawRentBikeForm()
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
    }
}