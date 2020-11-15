using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class ListBikeForm
    {
        public RichTextBox categoryBikeRtb, numberRtb, stationRtb;
        public TextBox searchTxt;
        public Panel listBikePnl;
        public Button returnStationBut;

        public void DrawListBikes()
        {
            searchTxt = new TextBox()
            {
                Width = 570,
                Location = new Point(20, 5)
            };
            categoryBikeRtb = new RichTextBox()
            {
                Size = new Size(190, 30),
                Location = new Point(590, 5),
                SelectionAlignment = HorizontalAlignment.Center,
                ReadOnly = true
            };
            stationRtb = new RichTextBox()
            {
                Multiline = true,
                Size = new Size(570, 80),
                Location = new Point(20, 35),
                SelectionAlignment = HorizontalAlignment.Center,
                ReadOnly = true
            };
            numberRtb = new RichTextBox()
            {
                Multiline = true,
                Size = new Size(190, 80),
                Location = new Point(590, 35),
                SelectionAlignment = HorizontalAlignment.Center,
                ReadOnly = true
            };
            listBikePnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 255),
                Location = new Point(0, 115)
            };
            listBikePnl.HorizontalScroll.Maximum = 0;
            listBikePnl.AutoScroll = false;
            listBikePnl.VerticalScroll.Visible = false;
            listBikePnl.AutoScroll = true;
            returnStationBut = new Button()
            {
                Text = "Quay lại bãi xe",
                Size = new Size(350, 50),
                Location = new Point(430, 365),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Helvetica", 12, FontStyle.Regular)
            };
            this.Controls.Add(searchTxt);
            this.Controls.Add(categoryBikeRtb);
            this.Controls.Add(stationRtb);
            this.Controls.Add(numberRtb);
            this.Controls.Add(listBikePnl);
            this.Controls.Add(returnStationBut);
        }
    }
}