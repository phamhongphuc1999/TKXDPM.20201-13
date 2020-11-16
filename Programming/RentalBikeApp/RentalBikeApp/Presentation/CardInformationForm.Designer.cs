using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class CardInformationForm
    {
        public Label owerLbl, cardCodeLbl, bankLbl, securityCodeLbl, expirationDateLbl;
        public TextBox owerTxt, cardCodeTxt, bankTxt, securityCodeTxt, expirationDateTxt;
        public Button cancelBut, submitBut;
        public Panel cardInformationPnl;

        /// <summary>
        /// Initialized control in CardInformation
        /// </summary>
        public void DrawCardInformation()
        {
            cardInformationPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            owerLbl = new Label()
            {
                Text = "Tên chủ xe",
                Size = new Size(120, 40),
                Location = new Point(20, 5),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7")
            };
            owerTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(640, 40),
                Location = new Point(140, 5)
            };
            cardCodeLbl = new Label()
            {
                Text = "Mã xe",
                Size = new Size(120, 40),
                Location = new Point(20, 55),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7")
            };
            cardCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(640, 40),
                Location = new Point(140, 55)
            };
            bankLbl = new Label()
            {
                Text = "Ngân hàng phát hành",
                Size = new Size(120, 40),
                Location = new Point(20, 105),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7")
            };
            bankTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(640, 40),
                Location = new Point(140, 105)
            };
            securityCodeLbl = new Label
            {
                Text = "Mã bảo mật",
                Size = new Size(120, 40),
                Location = new Point(20, 155),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7")
            };
            securityCodeTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(640, 40),
                Location = new Point(140, 155)
            };
            expirationDateLbl = new Label()
            {
                Text = "Ngày hết hạn",
                Size = new Size(120, 40),
                Location = new Point(20, 205),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7")
            };
            expirationDateTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(640, 40),
                Location = new Point(140, 205)
            };
            cancelBut = new Button()
            {
                Text = "Hủy",
                Size = new Size(150, 50),
                Location = new Point(380, 307),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };
            submitBut = new Button
            {
                Text = "Xác nhận",
                Size = new Size(150, 50),
                Location = new Point(630, 307),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };
            cardInformationPnl.Controls.Add(owerLbl);
            cardInformationPnl.Controls.Add(owerTxt);
            cardInformationPnl.Controls.Add(cardCodeLbl);
            cardInformationPnl.Controls.Add(cardCodeTxt);
            cardInformationPnl.Controls.Add(bankLbl);
            cardInformationPnl.Controls.Add(bankTxt);
            cardInformationPnl.Controls.Add(securityCodeLbl);
            cardInformationPnl.Controls.Add(securityCodeTxt);
            cardInformationPnl.Controls.Add(expirationDateLbl);
            cardInformationPnl.Controls.Add(expirationDateTxt);
            cardInformationPnl.Controls.Add(cancelBut);
            cardInformationPnl.Controls.Add(submitBut);
            this.Controls.Add(cardInformationPnl);
        }
    }
}