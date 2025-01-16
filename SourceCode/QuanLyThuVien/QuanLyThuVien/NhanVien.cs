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
    public partial class NhanVien : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;
        OpenFileDialog fileDlog;

        public NhanVien()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        void clear()
        {
            txtManv.Clear();
            txtTennv.Clear();
            txtDiachi.Clear();
            txtHinhanh.Clear();
            txtPhone.Clear();        
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadData();
            groupBox1.Enabled = false;
            button_cancel.Enabled = false;
            button_file.Enabled = false;
            button_sub.Enabled = false;
            txtManv.Enabled = false;
            txtHinhanh.Enabled = false;
            cboGioitinh.SelectedIndex = 0;
            if (StaticUser.vaiTro == "")
            {
                btnXoa.Show();
            }
            else btnXoa.Hide();
        }

        void loadData()
        {
            dgvNhanVien.RowTemplate.Height = 100;
            string sql = "select * from nhanvien";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);

            // Thêm cột hình ảnh vào DataTable (sử dụng cột đã có HINHANH_TG)
            dt.Columns.Add("HINHANH", typeof(Image));

            // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
            foreach (DataRow row in dt.Rows)
            {
                string relativeImagePath = row["HINHANH_NV"].ToString(); // Đường dẫn tương đối

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imageDirectory = Path.Combine(Application.StartupPath, "img", "NhanVien"); // Thư mục chứa hình ảnh

                // Kết hợp thư mục gốc với đường dẫn tương đối để có đường dẫn tuyệt đối
                string imagePath = Path.Combine(imageDirectory, relativeImagePath);
                if (File.Exists(imagePath)) // Kiểm tra nếu file tồn tại
                {
                    row["HINHANH"] = Image.FromFile(imagePath); // Chuyển đổi đường dẫn thành hình ảnh
                }
                else
                {
                    row["HINHANH"] = null; // Nếu không tồn tại, đặt giá trị là null
                }
            }

            dgvNhanVien.DataSource = dt;

            button_sl.Text = (dgvNhanVien.RowCount).ToString();

            // Đổi cột HINHANH_TG thành DataGridViewImageColumn để hiển thị ảnh
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "HINHANH";
            imageColumn.HeaderText = "Hình ảnh";
            imageColumn.DataPropertyName = "HINHANH";
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Hiển thị ảnh theo kiểu zoom vừa với ô

            dgvNhanVien.Columns.Remove("HINHANH"); // Bỏ cột HINHANH_TG text
            dgvNhanVien.Columns.Add(imageColumn); // Thêm cột hình ảnh mới
        }

        void them()
        {
            try
            {
                cn.Open();
                DateTime ns = DateTime.Parse(dtpNgaysinh.Text);
                string sql = string.Format("insert into nhanvien values('{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}')", txtManv.Text, txtTennv.Text, cboGioitinh.Text, ns.ToString("yyyy-MM-dd"), txtDiachi.Text, txtPhone.Text, txtHinhanh.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        void edit()
        {
            try
            {
                cn.Open();
                DateTime ns = DateTime.Parse(dtpNgaysinh.Text);
                string sql = string.Format("update nhanvien set tennv = N'{0}', gioitinh = N'{1}', ngaysinh = '{2}', diachi_nv = N'{3}', phone = '{4}', hinhanh_nv = '{5}' where manv = '{6}'", txtTennv.Text, cboGioitinh.Text, ns.ToString("yyyy-MM-dd"), txtDiachi.Text, txtPhone.Text, txtHinhanh.Text, txtManv.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        void xoa()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from nhanvien where manv = '{0}'", txtManv.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {            
            clear();
            txtManv.Text = maNV();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            button_cancel.Enabled = true;
            button_sub.Enabled = true;
            button_file.Enabled = true;
            dgvNhanVien.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            fileDlog = new OpenFileDialog();
            fileDlog.Filter = fileDlog.Filter = "JPG (*.jpg)|*.jpg|All files (*.*)|*.*";
            fileDlog.FilterIndex = 1;
            fileDlog.RestoreDirectory = true;
            if (fileDlog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = fileDlog.FileName;
                txtHinhanh.Text = Path.GetFileName(fileDlog.FileName);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            button_cancel.Enabled = true;
            button_sub.Enabled = true;
            button_file.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            button_cancel.Enabled = true;
            button_sub.Enabled = true;
            button_file.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    txtManv.Text = dgvNhanVien.Rows[index].Cells[0].Value.ToString();
                    txtTennv.Text = dgvNhanVien.Rows[index].Cells[1].Value.ToString();
                    cboGioitinh.Text = dgvNhanVien.Rows[index].Cells[2].Value.ToString();
                    DateTime datevalue = (DateTime)dgvNhanVien.Rows[index].Cells[3].Value;
                    dtpNgaysinh.Text = datevalue.ToString("yyyy-MM-dd");    
                    txtDiachi.Text = dgvNhanVien.Rows[index].Cells[4].Value.ToString();
                    txtPhone.Text = dgvNhanVien.Rows[index].Cells[5].Value.ToString();
                    txtHinhanh.Text = dgvNhanVien.Rows[index].Cells[6].Value.ToString();
                    Bitmap bitmap = (Bitmap)dgvNhanVien.Rows[index].Cells[7].Value;
                    // Gán Bitmap cho PictureBox
                    pictureBox2.Image = bitmap;
                }
                catch (Exception)
                {

                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            clear();
            button_cancel.Enabled = false;
            groupBox1.Enabled = false;
            button_file.Enabled = false;
            button_sub.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            dgvNhanVien.Enabled = true;
        }

        string maNV()
        {
            string sql = "select top 1 manv from nhanvien order by manv desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "NV001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(2));
                stt++;
                newStr = "NV" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }

        private void button_sub_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                if (txtTennv.Text.Length == 0 || txtDiachi.Text.Length == 0 || txtPhone.Text.Length == 0 || txtHinhanh.Text.Length == 0)
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    them();
                    clear();
                    button_cancel.Enabled = false;
                    groupBox1.Enabled = false;
                    button_file.Enabled = false;
                    button_sub.Enabled = false;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    dgvNhanVien.Enabled = true;
                }
            }
            else if (btnSua.Enabled ==true)
            {
                if (txtTennv.Text.Length == 0 || txtDiachi.Text.Length == 0 || txtPhone.Text.Length == 0 || txtHinhanh.Text.Length == 0)
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    edit();
                    clear();
                    button_cancel.Enabled = false;
                    groupBox1.Enabled = false;
                    button_file.Enabled = false;
                    button_sub.Enabled = false;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    dgvNhanVien.Enabled = true;
                }
            }
            else if (btnXoa.Enabled == true)
            {
                xoa();
                clear();
                button_cancel.Enabled = false;
                groupBox1.Enabled = false;
                button_file.Enabled = false;
                button_sub.Enabled = false;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                dgvNhanVien.Enabled = true;
            }
        }

        void search()
        {
            cn.Open();
            string sql = string.Format("select * from NHANVIEN where MANV like '%' + N'{0}' + '%' or TENNV like '%' + N'{0}' + '%' or GIOITINH like '%' + N'{0}' + '%' or NGAYSINH like '%' + '{0}' + '%' or DIACHI_NV like '%' + N'{0}' + '%' or PHONE like '%' + '{0}' + '%'", txtTimKiem.Text);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dgvNhanVien.DataSource = dt;

            // Thêm cột hình ảnh vào DataTable (sử dụng cột đã có HINHANH_TG)
            dt.Columns.Add("HINHANH", typeof(Image));

            // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
            foreach (DataRow row in dt.Rows)
            {
                string relativeImagePath = row["HINHANH_NV"].ToString(); // Đường dẫn tương đối

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imageDirectory = Path.Combine(Application.StartupPath, "img", "NhanVien"); // Thư mục chứa hình ảnh

                // Kết hợp thư mục gốc với đường dẫn tương đối để có đường dẫn tuyệt đối
                string imagePath = Path.Combine(imageDirectory, relativeImagePath);
                if (File.Exists(imagePath)) // Kiểm tra nếu file tồn tại
                {
                    row["HINHANH"] = Image.FromFile(imagePath); // Chuyển đổi đường dẫn thành hình ảnh
                }
                else
                {
                    row["HINHANH"] = null; // Nếu không tồn tại, đặt giá trị là null
                }
            }
            // Đổi cột HINHANH_TG thành DataGridViewImageColumn để hiển thị ảnh
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "HINHANH";
            imageColumn.HeaderText = "Hình ảnh";
            imageColumn.DataPropertyName = "HINHANH";
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Hiển thị ảnh theo kiểu zoom vừa với ô

            dgvNhanVien.Columns.Remove("HINHANH"); // Bỏ cột HINHANH_TG text
            dgvNhanVien.Columns.Add(imageColumn); // Thêm cột hình ảnh mới
            cn.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            search();
            button_sl.Text = dgvNhanVien.RowCount.ToString();
        }

        private void button_reload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new QuanLyUser();
            f.Show();
            this.Hide();
        }

        private void button_home_Click(object sender, EventArgs e)
        {
            Form f = new TrangChu();
            f.Show();
            this.Hide();
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (txtManv.Enabled == false)
            {
                txtManv.Enabled = true;
            }
            else txtManv.Enabled = false;
        }
    }
}
