using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class HomePageForm
    {
        public Panel stationPnl;
        public Label lineSearchLbl;
        public TextBox searchTxt;
        public Button searchBut, cancelSearchBut;

        /// <summary>
        /// Initialized control in HomePageForm
        /// </summary>
        public void DrawHomePage()
        {
            searchTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(this.ClientSize.Width - 140, 40),
                Location = new Point(20, 5),
                PlaceholderText= "Nhập tên bãi xe muốn tìm kiếm"
            };
            searchBut = new Button()
            {
                Size = new Size(100, 40),
                Location = new Point(680, 5),
                Text = "Search",
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            cancelSearchBut = new Button()
            {
                Size = new Size(40, 40),
                Location = new Point(640, 5),
                Text = "X"
            };
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

            searchBut.Click += SearchBut_Click;
            cancelSearchBut.Click += CancelSearchBut_Click;

            this.Controls.Add(searchTxt);
            this.Controls.Add(searchBut);
            this.Controls.Add(cancelSearchBut);
            this.Controls.Add(stationPnl);
            this.Controls.Add(lineSearchLbl);
        }
    }
}