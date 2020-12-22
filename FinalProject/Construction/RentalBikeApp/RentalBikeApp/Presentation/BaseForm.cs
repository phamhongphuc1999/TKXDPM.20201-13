// --------------------RENTAL BIKE APP-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//   Su Huu Vu Quang
//   Pham Hong Phuc
//   Tran Minh Quang
//   Ngo Minh Quang
//
//
// ------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    /// <summary>
    /// This class extend the function and event to help user interact with screen in progran
    /// </summary>
    public partial class BaseForm : Form
    {
        public BaseForm PrevForm { get; set; }

        public BaseForm()
        {
            InitializeComponent("BaseForm");
            DrawBaseForm();
            this.FormClosing += BaseForm_FormClosing;
            this.homePageBut.Click += HomePageBut_Click;
            this.rentBikeBut.Click += RentBikeBut_Click;
            this.prevFormBut.Click += PrevFormBut_Click;
        }

        /// <summary>
        /// Show form in the location base on specified form's location
        /// </summary>
        /// <param name="nameForm">The name of specified form</param>
        /// <param name="prevForm">The previous form, will be display when press previous form button</param>
        public void Show(string nameForm, BaseForm prevForm = null)
        {
            this.Show();
            int locationMainX = Application.OpenForms[nameForm].Location.X;
            int locationMainY = Application.OpenForms[nameForm].Location.Y;
            this.Location = new Point(locationMainX, locationMainY);
            if (prevForm != null) this.PrevForm = prevForm;
        }

        /// <summary>Show form in the location base on specified form's location</summary>
        /// <param name="form">The specified form</param>
        /// <param name="prevForm">The previous form, will be display when press previous form button</param>
        public void Show(Form form, BaseForm prevForm = null)
        {
            this.Show();
            int locationMainX = form.Location.X;
            int locationMainY = form.Location.Y;
            this.Location = new Point(locationMainX, locationMainY);
            if (prevForm != null) this.PrevForm = prevForm;
        }

        /// <summary>
        /// Handle click event RentBikeBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected virtual void RentBikeBut_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Handle click event HomePageBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected virtual void HomePageBut_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Handle click event PrevFormBut
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected virtual void PrevFormBut_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this.PrevForm.Show(this);
        }

        /// <summary>
        /// Handle click event FormClosing
        /// </summary>
        /// <param name="sender">The object send event</param>
        /// <param name="e">An EventArgs</param>
        protected virtual void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Config.RENT_BIKE_STATUS == Config.RENT_BIKE.RENTING_BIKE)
            {
                MessageBox.Show("Vui lòng trả xe trước khi thoát chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel) e.Cancel = true;
        }
    }
}
