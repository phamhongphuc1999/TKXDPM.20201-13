using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class CardInformationForm
    {
        private Label owerLbl, cardCodeLbl, bankLbl, securityCodeLbl, expirationDateLbl;
        private TextBox owerTxt, cardCodeTxt, securityCodeTxt, expirationTxt;
        private Button cancelBut, submitBut;
        private Panel cardInformationPnl;
        private ComboBox bankCb;

        /// <summary>
        /// Initialized control in CardInformation
        /// </summary>
        private void DrawCardInformation()
        {
            cardInformationPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            owerLbl = new Label()
            {
                Text = "Tên chủ xe",
                Size = new Size(150, 40),
                Location = new Point(20, 5),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            owerTxt = new TextBox()
            {
                Multiline = true,
                Text = "Group 13",
                Size = new Size(590, 40),
                Location = new Point(190, 5),
                PlaceholderText = "Nhập tên chủ thẻ"
            };
            cardCodeLbl = new Label()
            {
                Text = "Mã thẻ",
                Size = new Size(150, 40),
                Location = new Point(20, 55),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            cardCodeTxt = new TextBox()
            {
                Multiline = true,
                Text = "118609_group13_2020",
                Size = new Size(590, 40),
                Location = new Point(190, 55),
                PlaceholderText = "Nhập mã thẻ"
            };
            bankLbl = new Label()
            {
                Text = "Ngân hàng phát hành",
                Size = new Size(150, 40),
                Location = new Point(20, 105),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            bankCb = new ComboBox()
            {
                Width = 590,
                Location = new Point(190, 105)
            };
            Utilities.SetComboBoxHeight(bankCb.Handle, 35);
            bankCb.Items.Insert(0, "Chọn tên ngân hàng phát hành thẻ");
            bankCb.SelectedIndex = 0;
            bankCb.Items.Add("Bank 2");
            bankCb.SelectedIndex = 1;
            securityCodeLbl = new Label
            {
                Text = "Mã bảo mật",
                Size = new Size(150, 40),
                Location = new Point(20, 155),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            securityCodeTxt = new TextBox()
            {
                Multiline = true,
                Text = "B92s318KCwI=",
                Size = new Size(590, 40),
                Location = new Point(190, 155),
                PlaceholderText = "Nhập mã bảo mật"
            };
            expirationDateLbl = new Label()
            {
                Text = "Ngày hết hạn",
                Size = new Size(150, 40),
                Location = new Point(20, 205),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            expirationTxt = new TextBox()
            {
                Multiline = true,
                Text = "474",
                Size = new Size(590, 40),
                Location = new Point(190, 205),
                PlaceholderText = "Nhập ngày hết hạn"
            };
            cancelBut = new Button()
            {
                Text = "Hủy",
                Size = new Size(250, 50),
                Location = new Point(250, 300),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };
            submitBut = new Button
            {
                Text = "Xác nhận",
                Size = new Size(250, 50),
                Location = new Point(530, 300),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc")
            };

            cancelBut.Click += CancelBut_Click;
            submitBut.Click += SubmitBut_Click;

            cardInformationPnl.Controls.Add(owerLbl);
            cardInformationPnl.Controls.Add(owerTxt);
            cardInformationPnl.Controls.Add(cardCodeLbl);
            cardInformationPnl.Controls.Add(cardCodeTxt);
            cardInformationPnl.Controls.Add(bankLbl);
            cardInformationPnl.Controls.Add(bankCb);
            cardInformationPnl.Controls.Add(securityCodeLbl);
            cardInformationPnl.Controls.Add(securityCodeTxt);
            cardInformationPnl.Controls.Add(expirationDateLbl);
            cardInformationPnl.Controls.Add(expirationTxt);
            cardInformationPnl.Controls.Add(cancelBut);
            cardInformationPnl.Controls.Add(submitBut);
            this.Controls.Add(cardInformationPnl);
        }
    }
}