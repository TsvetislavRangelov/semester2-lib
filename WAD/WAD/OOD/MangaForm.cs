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
using System.IO;

namespace OOD
{
    public partial class MangaForm : Form
    {
        private const byte limit = 255;
        MangaManager mm;
        ImageConverter im;
        public MangaForm()
        {
            mm = new MangaManager(new MangaDAL());
            im = new ImageConverter();
            InitializeComponent();
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

        private void btnAddManga_Click(object sender, EventArgs e)
        {
            Manga m = new Manga();

            if (tbxAuthor.Text != String.Empty && tbxTitle.Text != String.Empty && pictureBox1.Image != null)
            {
                m.Title = tbxTitle.Text;
                m.Author = tbxAuthor.Text;
                m.ReleaseDate = dtpReleaseDate.Value.Date;
                m.Image = (byte[])im.ConvertTo(pictureBox1.Image, typeof(byte[]));

                if (mm.AddManga(m) == 1)
                {
                    MessageBox.Show("Manga added successfully.");
                }
                else
                {
                    MessageBox.Show("The image you're trying to upload is too big.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields and add a cover.");
            }
        }
    }
}
