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
    public partial class ItemManagement : Form
    {
        public ItemManagement()
        {
            InitializeComponent();
        }

        private void btnRedirectManga_Click(object sender, EventArgs e)
        {
            this.Hide();
            MangaForm nf = new MangaForm();
            nf.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home nf = new Home();
            nf.Show();
        }

        private void btnRedirectSeries_Click(object sender, EventArgs e)
        {
            this.Hide();
            SeriesForm nf = new SeriesForm();
            nf.Show();
        }
    }
}
