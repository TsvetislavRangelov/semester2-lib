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
    public partial class UpdateManga : Form
    {
        private readonly ImageConverter ic;
        private readonly Manga selected;
        private readonly MangaManager mm;
        public UpdateManga(Manga updateManga)
        {
            this.ic = new ImageConverter();
            this.selected = updateManga;
            mm = new MangaManager(new MangaDAL());
            InitializeComponent();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxTitle.Text is not null && tbxAuthor.Text is not null && pictureBox1.Image is not null)
            {
                selected.Title = tbxTitle.Text;
                selected.Author = tbxAuthor.Text;
                selected.ReleaseDate = (DateTime)dtpReleaseDate.Value;
                selected.Image = (byte[])ic.ConvertTo(pictureBox1.Image, typeof(byte[]));
                mm.UpdateManga(selected);
                MessageBox.Show("Update successful");
            }
            else
            {
                MessageBox.Show("Please provide valid values for all fields");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (browser.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(browser.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewManga nf = new ViewManga();
            nf.Show();
        }
    }
}
