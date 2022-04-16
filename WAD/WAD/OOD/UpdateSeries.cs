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
    public partial class UpdateSeries : Form
    {
        ImageConverter ic;
        Series updatedSeries;
        SeriesManager sm;
        public UpdateSeries(Series selectedSeries)
        {
            this.ic = new ImageConverter();
            this.sm = new SeriesManager(new SeriesDAL());
            updatedSeries = selectedSeries;
            InitializeComponent();
            lblId.Text = "Current series ID:" + updatedSeries.Id.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxTitle.Text is not null && tbxEpisodes.Text is not null && tbxSeasons.Text is not null && pictureBox1.Image is not null)
                {
                    updatedSeries.Title = tbxTitle.Text;
                    updatedSeries.Episodes = Int32.Parse(tbxEpisodes.Text);
                    updatedSeries.Seasons = Int32.Parse(tbxSeasons.Text);
                    updatedSeries.Image = (byte[])ic.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    sm.UpdateSeries(updatedSeries);
                    MessageBox.Show("Update successful");
                }
                else
                {
                    MessageBox.Show("Please provide valid values for all fields");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Episodes and seasons must be a numerical value.");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (browser.ShowDialog() is DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(browser.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            SeriesForm nf = new SeriesForm();
            nf.Show();
        }
    }
}
