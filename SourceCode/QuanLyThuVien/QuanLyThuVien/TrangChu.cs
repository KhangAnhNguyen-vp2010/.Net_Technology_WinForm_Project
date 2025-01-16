using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyThuVien
{
    public partial class TrangChu : Form
    {
        public string tentk, vaitro;
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlCommand cmd;
        OpenFileDialog fileDlog;

        public TrangChu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            cn = kn.conn;
            tentk = StaticUser.tenTK;
            vaitro = StaticUser.vaiTro;
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {        
            label_tk.Text = tentk;
            textBox_role.Text = vaitro;
            groupBox1.Enabled = false;
            if (xet_Role() == 1)
            {
                Details();
                button_qlNV.Hide();
            }
            else if (xet_Role() == 2)
            {
                Details();
                button_qlNV.Show();
            }
            else
            {
                button_qlNV.Show();
                button_save.Hide();
                button_edit.Hide();
            }
            button_save.Enabled = false;
        }

        void Details()
        {
            cn.Open();
            string sql1 = string.Format("select tennv from nhanvien where manv = '{0}'", tentk);
            cmd = new SqlCommand(sql1, cn);
            textBox_name.Text = cmd.ExecuteScalar().ToString();
            string sql2 = string.Format("select gioitinh from nhanvien where manv = '{0}'", tentk);
            cmd = new SqlCommand(sql2, cn);
            string gt = cmd.ExecuteScalar().ToString();
            if (gt == "Nam")
            {
                rd_nam.Checked = true;
            }
            else radioButton_nu.Checked = true;
            string sql3 = string.Format("select ngaysinh from nhanvien where manv = '{0}'", tentk);
            cmd = new SqlCommand(sql3, cn);
            DateTime values = (DateTime)cmd.ExecuteScalar();
            maskedTextBox_ns.Text = values.ToString("dd-MM-yyyy");
            string sql4 = string.Format("select diachi_nv from nhanvien where manv = '{0}'", tentk);
            cmd = new SqlCommand(sql4, cn);
            textBox_diachi.Text = cmd.ExecuteScalar().ToString();
            string sql5 = string.Format("select phone from nhanvien where manv = '{0}'", tentk);
            cmd = new SqlCommand(sql5, cn);
            textBox_phone.Text = cmd.ExecuteScalar().ToString();
            string sql6 = string.Format("select hinhanh_nv from nhanvien where manv = '{0}'", tentk);
            cmd = new SqlCommand(sql6, cn);
            textBox_linkanh.Text = cmd.ExecuteScalar().ToString();
            try
            {
                string relativeImagePath = textBox_linkanh.Text; // Đường dẫn tương đối

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imageDirectory = Path.Combine(Application.StartupPath, "img", "NhanVien"); // Thư mục chứa hình ảnh

                // Kết hợp thư mục gốc với đường dẫn tương đối để có đường dẫn tuyệt đối
                string imagePath = Path.Combine(imageDirectory, relativeImagePath);
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rd_nam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_nu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox_ns_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox_diachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void file_Click(object sender, EventArgs e)
        {
            fileDlog = new OpenFileDialog();
            fileDlog.Filter = fileDlog.Filter = "JPG (*.jpg)|*.jpg|All files (*.*)|*.*";
            fileDlog.FilterIndex = 1;
            fileDlog.RestoreDirectory = true;
            if (fileDlog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = fileDlog.FileName;
                textBox_linkanh.Text = Path.GetFileName(fileDlog.FileName);
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {        
            if (button_save.Enabled == false)
            {
                groupBox1.Enabled = true;
                button_save.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                button_save.Enabled = false;
            }
        }

        void sua_NV()
        {
            try
            {
                cn.Open();
                DateTime date = DateTime.Parse(maskedTextBox_ns.Text);
                string gt = "";
                if (radioButton_nu.Checked == true)
                {
                    gt = "Nữ";
                }
                else gt = "Nam";
                string sql = string.Format("update nhanvien set tennv = N'{0}', gioitinh = N'{1}', ngaysinh = '{2}', diachi_nv = N'{3}', phone = '{4}', hinhanh_nv = '{5}' where manv = '{6}'", textBox_name.Text, gt, date.ToString("yyyy-MM-dd"), textBox_diachi.Text, textBox_phone.Text, textBox_linkanh.Text, tentk);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length == 0 || maskedTextBox_ns.Text.Length < 10 || pictureBox1.Image == null )
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sua_NV();
                groupBox1.Enabled = false;
                button_edit.Enabled = true;
                button_save.Enabled = false;
            }          
        }

        private void button_dx_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu Form vẫn đang mở
            SelectBaoCao bc = Application.OpenForms.OfType<SelectBaoCao>().FirstOrDefault();
            if (bc != null && !bc.IsDisposed)  // Nếu Form đang mở
            {
                bc.Close();
            }
            Form f = new FormLogin();
            f.Show();
            this.Hide();        
        }

        int xet_Role()
        {
            if (vaitro == "staff")
            {
                return 1;
            }
            else if (vaitro == "manager")
            {
                return 2;
            }
            return 0;
        }

        private void button_qlSach_Click(object sender, EventArgs e)
        {
            StaticUser.vaiTro = vaitro;        
            Form f = new TacGia();
            f.Show();
            this.Hide();
        }

        private void button_qlMT_Click(object sender, EventArgs e)
        {          
            Form f = new  PhieuMuon();
            f.Show();
            this.Hide();
        }

        private void button_qlNV_Click(object sender, EventArgs e)
        {
            Form f = new NhanVien();
            f.Show();
            this.Hide();
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void button_inbaocao_Click(object sender, EventArgs e)
        {
            Form f = new SelectBaoCao();
            f.Show();
        }
    }
}
