using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOD
{
    public partial class Home : Form
    {
        private static string adminName;
        public Home()
        {
            InitializeComponent();
        }

        public void SetWelcomeName(string name)
        {
            adminName = name;
        }

        public void UpdateLabel()
        {
            label1.Text = $"{label1.Text} : {adminName}";
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManagementForm nf = new UserManagementForm();
            nf.Show();
        }

        private void btnItemManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemManagement nf = new ItemManagement();
            nf.Show();
        }
    }
}
