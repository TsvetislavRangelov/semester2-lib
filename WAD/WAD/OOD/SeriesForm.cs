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
    public partial class SeriesForm : Form
    {
        SeriesManager sm;
        ImageConverter im;
        public SeriesForm()
        {
            this.im = new ImageConverter();
            this.sm = new SeriesManager(new SeriesDAL());
            InitializeComponent();
            PopulateDGV();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            Series newSeries = new Series();
            try
            {
                if (tbxAddTitle.Text != String.Empty && tbxAddEpisodes.Text != String.Empty && tbxAddSeasons.Text != String.Empty && pictureBox1.Image != null)
                {
                    newSeries.Title = tbxAddTitle.Text;
                    newSeries.Episodes = Int32.Parse(tbxAddEpisodes.Text);
                    newSeries.Seasons = Int32.Parse(tbxAddSeasons.Text);
                    newSeries.Image = (byte[])im.ConvertTo(pictureBox1.Image, typeof(byte[]));

                    if (sm.AddSeries(newSeries) == 1)
                    {
                        MessageBox.Show("Series added Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("The image you're trying to upload is too big.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields and add a cover image.");
                }
                
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Episodes and seasons must be numerical values.");
            }
            finally { PopulateDGV(); }
        }

        private void btnUploadCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (browser.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(browser.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void PopulateDGV()
        {
            dataGridView1.DataSource = sm.GetSeries();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Update();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try 
            {
                int id = Int32.Parse(tbxDeleteId.Text);

                if (id > 0)
                {
                    sm.DeleteSeries(id);
                    MessageBox.Show("Deleted Successfully.");
                    PopulateDGV();
                }
                else
                {
                    MessageBox.Show("No such series exist.");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Id must be a numerical value.");
            }
            
            PopulateDGV();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Series selected = selectedRow.DataBoundItem as Series;
            if(selected is not null)
            {
                this.Hide();
                UpdateSeries nf = new UpdateSeries(selected);
                nf.Show();
            }
            else
            {
                MessageBox.Show("Please select an item to modify.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemManagement nf = new ItemManagement();
            nf.Show();
        }
    }
}
