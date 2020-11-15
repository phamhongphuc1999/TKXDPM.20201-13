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

        public void Show(string nameForm)
        {
            this.Show();
            int locationMainX = Application.OpenForms[nameForm].Location.X;
            int locationMainY = Application.OpenForms[nameForm].Location.Y;
            this.Location = new Point(locationMainX, locationMainY);
        }

        public void Show(Form form)
        {
            this.Show();
            int locationMainX = form.Location.X;
            int locationMainY = form.Location.Y;
            this.Location = new Point(locationMainX, locationMainY);
        }
    }
}
