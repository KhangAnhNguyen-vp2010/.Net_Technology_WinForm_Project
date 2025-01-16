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
    public partial class Sach : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;
        OpenFileDialog fileDlog;

        void ClearDuLieu()
        {
            textBox_mash.Clear();
            textBox_namesh.Clear();
            textBox_namxb.Clear();
            pictureBox1.Image = null;
        }

        void OnOFF_CBB(int i)
        {
            if (i==1)
            {
                comboBox_matg.Hide();
                comboBox_manxb.Hide();
                comboBox_maloai.Hide();
            }
            else if (i==0)
            {
                comboBox_matg.Show();
                comboBox_manxb.Show();
                comboBox_maloai.Show();
            }
        }

        public Sach()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        void loadData_Sach()
        {
            dataGridView1.RowTemplate.Height = 100;
            string sql = "select * from sach";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);

            dt.Columns.Add("HINHANH", typeof(Image));

            // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
            foreach (DataRow row in dt.Rows)
            {
                string relativeImagePath = row["HINHANH_SACH"].ToString(); // Đường dẫn tương đối

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imageDirectory = Path.Combine(Application.StartupPath, "img", "Sach"); // Thư mục chứa hình ảnh

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

            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();

            // Đổi cột HINHANH_TG thành DataGridViewImageColumn để hiển thị ảnh
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "HINHANH";
            imageColumn.HeaderText = "Hình ảnh";
            imageColumn.DataPropertyName = "HINHANH";
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Hiển thị ảnh theo kiểu zoom vừa với ô

            dataGridView1.Columns.Remove("HINHANH"); // Bỏ cột HINHANH_TG text
            dataGridView1.Columns.Add(imageColumn); // Thêm cột hình ảnh mới
        }

        void loadCBB_TacGia()
        {
            string sql = "select * from tacgia";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_matg.DataSource = dt;
            comboBox_matg.DisplayMember = "tentg";
            comboBox_matg.ValueMember = "matg";
        }

        void loadCBB_NXB()
        {
            string sql = "select * from nhaxuatban";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_manxb.DataSource = dt;
            comboBox_manxb.DisplayMember = "tennxb";
            comboBox_manxb.ValueMember = "manxb";
        }

        void loadCBB_TheLoai()
        {
            string sql = "select * from theloai";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_maloai.DataSource = dt;
            comboBox_maloai.DisplayMember = "tenloai";
            comboBox_maloai.ValueMember = "maloai";
        }

        string GiaTriCBB_TacGia(string matg)
        {
            string sql = string.Format("select tentg from tacgia where matg = '{0}'", matg);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        string GiaTriCBB_NXB(string manxb)
        {
            string sql = string.Format("select tennxb from nhaxuatban where manxb = '{0}'", manxb);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        string GiaTriCBB_TheLoai(string maloai)
        {
            string sql = string.Format("select tenloai from theloai where maloai = '{0}'", maloai);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        string maSach()
        {
            string sql = "select top 1 mash from sach order by mash desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "SH001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(2));
                stt++;
                newStr = "SH" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }

        void them_Sach()
        {
            try
            {
                try
                {
                    cn.Open();
                    string sql = string.Format("insert into sach values('{0}', N'{1}', '{2}', '{3}', '{4}', '{5}', null, '{6}')", textBox_mash.Text, textBox_namesh.Text, comboBox_matg.SelectedValue, comboBox_manxb.SelectedValue, comboBox_maloai.SelectedValue, textBox_namxb.Text, textBox_linkanh.Text);
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("1000 < năm xuất bản < 9999", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            finally { cn.Close(); }
        }

        public void sua_Sach()
        {
            try
            {
                try
                {
                    cn.Open();
                    string sql = string.Format("update sach set tensh = N'{0}', matg = '{1}', manxb = '{2}', maloai = '{3}', namxuatban = '{4}', hinhanh_sach = '{5}' where mash = '{6}'", textBox_namesh.Text, comboBox_matg.SelectedValue, comboBox_manxb.SelectedValue, comboBox_maloai.SelectedValue, textBox_namxb.Text, textBox_linkanh.Text, textBox_mash.Text);
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("1000 < năm xuất bản < 9999", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        public void xoa_TacGia()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from sach where mash = '{0}'", textBox_mash.Text);
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

        private void Sach_Load(object sender, EventArgs e)
        {
            loadData_Sach();
            loadCBB_TacGia();
            loadCBB_NXB();
            loadCBB_TheLoai();
            OnOFF_CBB(1);
            groupBox1.Enabled = false;
            comboBox_loc.SelectedIndex = 0;
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button_foradmin.Show();
            }
            else button_foradmin.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (textBox_namesh.Text.Length == 0 || textBox_namxb.Text.Length == 0 || pictureBox1.Image == null)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (button_add.Enabled == true)
            {
                them_Sach();
                loadData_Sach();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                dataGridView1.Enabled = true;
                OnOFF_CBB(1);
            }
            else if (button_edit.Enabled == true)
            {
                sua_Sach();
                loadData_Sach();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
            }
            else if (button_del.Enabled == true)
            {
                xoa_TacGia();
                loadData_Sach();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                file.Enabled = true;
                textBox_namesh.Enabled = true;
                textBox_namxb.Enabled = true;
                comboBox_matg.Enabled = true;
                comboBox_manxb.Enabled = true;
                comboBox_maloai.Enabled = true;
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
            dataGridView1.Enabled = false;
            groupBox1.Enabled = true;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            textBox_mash.Enabled = false;
            textBox_mash.Text = maSach();
            loadCBB_TacGia();
            loadCBB_NXB();
            loadCBB_TheLoai();
            OnOFF_CBB(0);
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_del.Enabled = false;
            textBox_mash.Enabled = false;
            pictureBox1.Show();
            OnOFF_CBB(0);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OnOFF_CBB(0);
            pictureBox1.Show();
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    textBox_mash.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    textBox_namesh.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    //comboBox_matg.Text = GiaTriCBB_TacGia(dataGridView1.Rows[index].Cells[2].Value.ToString());
                    comboBox_manxb.Text = GiaTriCBB_NXB(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    comboBox_maloai.Text = GiaTriCBB_TheLoai(dataGridView1.Rows[index].Cells[4].Value.ToString());
                    textBox_namxb.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    textBox_linkanh.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    Bitmap bitmap = (Bitmap)dataGridView1.Rows[index].Cells[8].Value;
                    // Gán Bitmap cho PictureBox
                    pictureBox1.Image = bitmap;

                }
                catch (Exception)
                {

                }
            }
        }
        private void comboBox_matg_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_manxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_maloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
            groupBox1.Enabled = false;
            button_add.Enabled = true;
            button_del.Enabled = true;
            button_edit.Enabled = true;
            dataGridView1.Enabled = true;
            file.Enabled = true;
            OnOFF_CBB(1);
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_edit.Enabled = false;
            textBox_mash.Enabled = false;
            textBox_namesh.Enabled = false;
            textBox_namxb.Enabled = false;
            comboBox_matg.Enabled = false;
            comboBox_manxb.Enabled = false;
            comboBox_maloai.Enabled = false;
            file.Enabled = false;
        }

        void Loc_Sach()
        {
            if (comboBox_loc.SelectedIndex == 0)
            {
                string sql = "select MASH, TENSH, TENTG, TINHTRANG, HINHANH_SACH from SACH, TACGIA where SACH.MATG = TACGIA.MATG";
                adapter = new SqlDataAdapter(sql, cn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox_loc.SelectedIndex == 1)
            {
                string sql = "select MASH, TENSH, TENNXB, TINHTRANG, HINHANH_SACH from sach, nhaxuatban where sach.manxb = nhaxuatban.manxb";
                adapter = new SqlDataAdapter(sql, cn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox_loc.SelectedIndex == 2)
            {
                string sql = "select MASH, TENSH, TENLOAI, TINHTRANG, HINHANH_SACH from SACH, THELOAI where SACH.MALOAI = THELOAI.MALOAI";
                adapter = new SqlDataAdapter(sql, cn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button_loc_Click(object sender, EventArgs e)
        {
            Loc_Sach();
            dt.Columns.Add("HINHANH", typeof(Image));

            // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
            foreach (DataRow row in dt.Rows)
            {
                string relativeImagePath = row["HINHANH_SACH"].ToString(); // Đường dẫn tương đối

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imageDirectory = Path.Combine(Application.StartupPath, "img", "Sach"); // Thư mục chứa hình ảnh

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

            dataGridView1.Columns.Remove("HINHANH"); // Bỏ cột HINHANH_TG text
            dataGridView1.Columns.Add(imageColumn); // Thêm cột hình ảnh mới
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loadData_Sach();
        }

        void Seach_ThongTin()
        {
            try
            {
                string sql = string.Format("select SACH.*, TENTG, TENNXB, TENLOAI from SACH, TACGIA, NHAXUATBAN, THELOAI where SACH.MATG = TACGIA.MATG and SACH.MANXB = NHAXUATBAN.MANXB and SACH.MALOAI = THELOAI.MALOAI and (MASH like '%' + '{0}' + '%' or TENSH like '%' + N'{0}' + '%' or SACH.MATG like '%' + '{0}' + '%' or SACH.MANXB like '%' + '{0}' + '%' or SACH.MALOAI like '%' + '{0}' + '%' or NAMXUATBAN like '%' + '{0}' + '%' or TINHTRANG like '%' + N'{0}' + '%' or TENTG like '%' + N'{0}' + '%' or TENNXB like '%' + N'{0}' + '%' or TENLOAI like '%' + N'{0}' + '%')", textBox_search.Text);
                adapter = new SqlDataAdapter(sql, cn);
                dt = new DataTable();
                adapter.Fill(dt);

                dt.Columns.Add("HINHANH", typeof(Image));

                // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
                foreach (DataRow row in dt.Rows)
                {
                    string relativeImagePath = row["HINHANH_SACH"].ToString(); // Đường dẫn tương đối

                    string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string imageDirectory = Path.Combine(Application.StartupPath, "img", "Sach"); // Thư mục chứa hình ảnh

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

                dataGridView1.DataSource = dt;
                button_sl.Text = dataGridView1.RowCount.ToString();

                // Đổi cột HINHANH_TG thành DataGridViewImageColumn để hiển thị ảnh
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "HINHANH";
                imageColumn.HeaderText = "Hình ảnh";
                imageColumn.DataPropertyName = "HINHANH";
                //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Hiển thị ảnh theo kiểu zoom vừa với ô

                dataGridView1.Columns.Remove("HINHANH"); // Bỏ cột HINHANH_TG text
                dataGridView1.Columns.Insert(8,imageColumn); // Thêm cột hình ảnh mới
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex);
                //MessageBox.Show("Không có dữ liệu");
            }
        }

        private void button_seach_Click(object sender, EventArgs e)
        {
            Seach_ThongTin();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            Form f = new TacGia();
            f.Show();
            this.Hide();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            Form f = new NhaXuatBan();
            f.Show();
            this.Hide();
        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (textBox_mash.Enabled == true)
            {
                textBox_mash.Enabled = false;
            }
            else textBox_mash.Enabled = true;
        }

        private void Sach_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TheLoai();
            f.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
