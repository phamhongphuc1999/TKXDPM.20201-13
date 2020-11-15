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
            int LocationMainX = Application.OpenForms[nameForm].Location.X;
            int locationMainY = Application.OpenForms[nameForm].Location.Y;
            this.Location = new Point(LocationMainX, locationMainY);
        }
    }
}
