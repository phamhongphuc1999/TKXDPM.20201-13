using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button homePageBut, rentBikeBut;
        private Label lineLbl, lineSearchLbl;
        private Panel stationPnl;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawBaseForm()
        {
            stationPnl = new Panel()
            {
                BackColor = Color.Red,
                Size = new Size(this.Width, 370),
                Location = new Point(0, 50),
                AutoScroll = true
            };
            lineSearchLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 50)
            };
            lineLbl = new Label()
            {
                AutoSize = false,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(this.Width, 4),
                Location = new Point(0, 420)
            };
            homePageBut = new Button()
            {
                Text = "Trang chủ",
                Size = new Size(220, 50),
                Location = new Point(20, 435),
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            rentBikeBut = new Button()
            {
                Text = "Thuê xe",
                Size = new Size(220, 50),
                Location = new Point(560, 435),
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(stationPnl);
            this.Controls.Add(lineSearchLbl);
            this.Controls.Add(lineLbl);
            this.Controls.Add(homePageBut);
            this.Controls.Add(rentBikeBut);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "HomePage";
        }

        #endregion
    }
}