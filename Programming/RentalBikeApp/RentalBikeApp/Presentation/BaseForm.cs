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
    public partial class BaseForm : Form
    {
        public BaseForm PrevForm { get; set; }

        public BaseForm()
        {
            InitializeComponent("BaseForm");
        }

        /// <summary>
        /// Show form in the location base on specified form's location
        /// </summary>
        /// <param name="nameForm">The name of specified form</param>
        public void Show(string nameForm)
        {
            this.Show();
            int locationMainX = Application.OpenForms[nameForm].Location.X;
            int locationMainY = Application.OpenForms[nameForm].Location.Y;
            this.Location = new Point(locationMainX, locationMainY);
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
    }
}
