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
           bool isRemoved = um.DeleteUser(Convert.ToInt32(tbxId.Text));
            if (!isRemoved)
            {
                MessageBox.Show("The id you provided does not exist or an error occured while processing your request");
            }
            dgvUsers.Update();
            PopulateDGV();
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxId.Text);
            Role selectedRole = (Role)cbRole.SelectedItem;
            um.ChangeStatus(id, selectedRole);
            dgvUsers.Update();
            PopulateDGV();
            

        }
    }
}
