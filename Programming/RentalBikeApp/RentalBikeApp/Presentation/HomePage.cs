using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Presentation
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            SQLConnecter sss = new SQLConnecter();
            User u = sss.SqlData.Users.ToList()[0];
            MessageBox.Show(u.UserName);
        }
    }
}
