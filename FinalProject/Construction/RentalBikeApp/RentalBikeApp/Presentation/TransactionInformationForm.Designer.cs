using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class TransactionInformationForm
    {
        private Panel transactionPnl;
        private Label depositLbl, rentalMoneyLbl, remainMoneyLbl, transactionDateLbl, noteLbl;
        private TextBox depositTxt, rentalMoneyTxt, remainMoneyTxt, transactionDateTxt, noteTxt;
        private Button permitBut, cancelBut;

        /// <summary>
        /// Initialized control in TransactionInformationForm
        /// </summary>
        public void DrawTransactionInformationForm()
        {
            transactionPnl = new Panel()
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 80),
                Location = new Point(0, 0)
            };
            depositLbl = new Label()
            {
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Tiền cọc",
                Size = new Size(150, 40),
                Location = new Point(20, 5)
            };
            depositTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 5),
                ReadOnly = true
            };
            rentalMoneyLbl = new Label()
            {
                Text = "Tiền thuê xe",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(150, 40),
                Location = new Point(20, 60),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            rentalMoneyTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 60),
                ReadOnly = true
            };
            remainMoneyLbl = new Label()
            {
                Text = "Số tiền còn lại",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(150, 40),
                Location = new Point(20, 115),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            remainMoneyTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 115),
                ReadOnly = true
            };
            transactionDateLbl = new Label()
            {
                Text = "Ngày giao dịch",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(150, 40),
                Location = new Point(20, 170),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            transactionDateTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 170),
                ReadOnly = true
            };
            noteLbl = new Label()
            {
                Text = "Ghi chú",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(150, 40),
                Location = new Point(20, 225),
                BackColor = ColorTranslator.FromHtml("#3d8af7"),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            noteTxt = new TextBox()
            {
                Multiline = true,
                Size = new Size(590, 40),
                Location = new Point(190, 225)
            };
            permitBut = new Button()
            {
                Text = "Xác nhận",
                Size = new Size(250, 50),
                Location = new Point(530, 300),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            cancelBut = new Button()
            {
                Text = "Hủy",
                Size = new Size(250, 50),
                Location = new Point(250, 300),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat,
                Visible = true
            };

            permitBut.Click += PermitBut_Click;
            cancelBut.Click += CancelBut_Click;

            transactionPnl.Controls.Add(depositLbl);
            transactionPnl.Controls.Add(depositTxt);
            transactionPnl.Controls.Add(rentalMoneyLbl);
            transactionPnl.Controls.Add(rentalMoneyTxt);
            transactionPnl.Controls.Add(remainMoneyLbl);
            transactionPnl.Controls.Add(remainMoneyTxt);
            transactionPnl.Controls.Add(transactionDateLbl);
            transactionPnl.Controls.Add(transactionDateTxt);
            transactionPnl.Controls.Add(noteLbl);
            transactionPnl.Controls.Add(noteTxt);
            transactionPnl.Controls.Add(permitBut);
            transactionPnl.Controls.Add(cancelBut);
            this.Controls.Add(transactionPnl);
        }
    }
}