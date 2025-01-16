using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class SelectBaoCao : Form
    {
        public SelectBaoCao()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new FormRP_PhieuMuon();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new FormRP_PhieuPhat();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new FormNhanSu();
            f.Show();
        }

        private void SelectBaoCao_Load(object sender, EventArgs e)
        {
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button3.Show();
                this.Size = new Size(300, 100);
            }
            else
            {
                button3.Hide();
                this.Size = new Size(210, 100);
            }
        }
    }
}
