using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class ListBikeForm
    {
        public RichTextBox descriptionRtb, stationRtb;
        public TextBox searchTxt;
        public Panel listBikePnl;
        public Button searchBut;

        /// <summary>
        /// Initalized control in ListBikeForm
        /// </summary>
        public void DrawListBikes()
        {
            searchTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(this.ClientSize.Width - 230, 40),
                Location = new Point(20, 5),
                PlaceholderText = "Nhập mã vạch xe muốn tìm kiếm"
            };
            searchBut = new Button()
            {
                Size = new Size(190, 40),
                Location = new Point(590, 5),
                Text = "Search",
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            stationRtb = new RichTextBox()
            {
                Multiline = true,
                Size = new Size(570, 75),
                Location = new Point(20, 40),
                SelectionAlignment = HorizontalAlignment.Center,
                ReadOnly = true,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            descriptionRtb = new RichTextBox()
            {
                Multiline = true,
                Size = new Size(190, 80),
                Location = new Point(590, 35),
                SelectionAlignment = HorizontalAlignment.Center,
                ReadOnly = true
            };
            listBikePnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 245),
                Location = new Point(0, 115),
            };
            listBikePnl.HorizontalScroll.Maximum = 0;
            listBikePnl.AutoScroll = false;
            listBikePnl.VerticalScroll.Visible = false;
            listBikePnl.AutoScroll = true;

            searchBut.Click += SearchBut_Click;

            this.Controls.Add(searchTxt);
            this.Controls.Add(searchBut);
            this.Controls.Add(stationRtb);
            this.Controls.Add(descriptionRtb);
            this.Controls.Add(listBikePnl);
        }
    }
}