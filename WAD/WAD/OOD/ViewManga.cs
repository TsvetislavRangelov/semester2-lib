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
using DAL.DAL;
using ClassLibrary1.Managers;

namespace OOD
{
    public partial class ViewManga : Form
    {
        MangaManager mm;

        public ViewManga()
        {
            this.mm = new MangaManager(new MangaDAL());
            InitializeComponent();
            PopulateDGV();
        }

        private void PopulateDGV()
        {
            dataGridView1.DataSource = mm.GetMangaListNoCover();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Update();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(tbxId.Text);

            if(id is not 0)
            {
                mm.DeleteMangaById(id);
                PopulateDGV();
            }
            else
            {
                MessageBox.Show("Please provide a valid id.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Manga selected = selectedRow.DataBoundItem as Manga;
                if (selected is not null)
                {
                    this.Hide();
                    UpdateManga nf = new UpdateManga(selected);
                    nf.Show();
                    PopulateDGV();
                }
                else
                {
                    MessageBox.Show("Please select an item to modify.");
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select the whole row you wish to update");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MangaForm nf = new MangaForm();
            nf.Show();
        }
    }
}
