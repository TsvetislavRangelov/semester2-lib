using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Models;
using ClassLibrary1.Managers;
using DAL.DAL;

namespace OOD
{
    public partial class Login : Form
    {
        private readonly UserManager um;
        public Login()
        {
            InitializeComponent();
            um = new UserManager(new UsersDAL());

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string loginUsername = tbxUsername.Text;
            string loginPassword = tbxPassword.Text;

            User loggedUser = um.LoginUser(loginUsername, loginPassword);

            if (loggedUser != null && loggedUser.Role == Models.Enums.Role.ADMIN)
            {
                this.Hide();
                Home nf = new Home();
                nf.SetWelcomeName(loggedUser.Username);
                nf.UpdateLabel();
                nf.Show();
                
            }
            else
            {
                MessageBox.Show("The credentials you have provided are incorrect.");
            }


        }
    }
}
