using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1.Managers;
using DAL.DAL;
using Models.Enums;

namespace OOD
{
    public partial class UserManagementForm : Form
    {
        private Role[] roles =
        {
            Role.ADMIN,
            Role.USER
        };
        private readonly UserManager um;
        public UserManagementForm()
        {
            InitializeComponent();
            um = new UserManager(new UsersDAL());
            PopulateDGV();
            AddRoles();
            cbRole.SelectedItem = roles[1];
        }

        private void PopulateDGV()
        {
            dgvUsers.DataSource = um.FillUserTable();
            dgvUsers.AutoResizeColumns();
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.Update();

        }
        private void AddRoles()
        {
            for (int i = 0; i < roles.Length; i++)
            {
                cbRole.Items.Add(roles[i]);
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if(tbxId.Text == "")
            {
                MessageBox.Show("Please enter a valid ID");
            }
            else
            {
                try
                {
                    bool isRemoved = um.DeleteUser(Convert.ToInt32(tbxId.Text));
                    if (!isRemoved)
                    {
                        MessageBox.Show("The id you provided does not exist or an error occured while processing your request");
                    }
                    dgvUsers.Update();
                    PopulateDGV();
                }
                catch (System.FormatException)
                {
                   MessageBox.Show("Please provide a valid value for the id");
                }

            }
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(tbxId.Text) == 0)
                {
                    MessageBox.Show("Please enter a valid id");
                }
                else
                {
                    int id = Int32.Parse(tbxId.Text);
                    Role selectedRole = (Role)cbRole.SelectedItem;
                    um.ChangeRole(id, selectedRole.ToString());
                    dgvUsers.Update();
                    PopulateDGV();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("The ID needs to be a number");
            }
        }
    }
}
