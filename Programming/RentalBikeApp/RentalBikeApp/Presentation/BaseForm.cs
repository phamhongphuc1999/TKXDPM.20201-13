using System.Drawing;
using System.Windows.Forms;

namespace RentalBikeApp.Presentation
{
    public partial class BaseForm : Form
    {
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
        public void Show(Form form)
        {
            this.Show();
            int locationMainX = form.Location.X;
            int locationMainY = form.Location.Y;
            this.Location = new Point(locationMainX, locationMainY);
        }
    }
}
