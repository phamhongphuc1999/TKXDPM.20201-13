using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Home page button
        /// </summary>
        public Button homePageBut;

        /// <summary>
        /// rent bike button
        /// </summary>
        public Button rentBikeBut;

        /// <summary>
        /// previous form button
        /// </summary>
        public Button prevFormBut;

        /// <summary>
        /// draw base form
        /// </summary>
        protected Label lineLbl;
        
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

        /// <summary>
        /// Initialized control in BaseForm
        /// </summary>
        protected void DrawBaseForm()
        {
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
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            rentBikeBut = new Button()
            {
                Text = "Thuê xe",
                Size = new Size(220, 50),
                Location = new Point(290, 435),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            prevFormBut = new Button()
            {
                Text = "Quay lại",
                Size = new Size(220, 50),
                Location = new Point(560, 435),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = ColorTranslator.FromHtml("#d4e3fc"),
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(lineLbl);
            this.Controls.Add(homePageBut);
            this.Controls.Add(rentBikeBut);
            this.Controls.Add(prevFormBut);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent(string formName, string textForm = "BaseForm")
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Icon = new Icon("../../../icon/rental-bike.ico");
            this.Text = textForm;
            this.Name = formName;
        }
        #endregion
    }
}