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
    public partial class TacGia : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;
        OpenFileDialog fileDlog;

        void ClearDuLieu()
        {
            textBox_matg.Clear();
            textBox_name.Clear();
            maskedTextBox1.Clear();
            richTextBox1.Clear();
            pictureBox1.Image = null;
        }

        public void them_TacGia()
        {
            try
            {
                DateTime date;
                try
                {
                    date = DateTime.Parse(maskedTextBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }             
                cn.Open();
                date = DateTime.Parse(maskedTextBox1.Text);
                string sql = string.Format("insert into tacgia values('{0}', N'{1}', '{2}', N'{3}', '{4}')", textBox_matg.Text, textBox_name.Text, date.ToString("yyyy-MM-dd"), richTextBox1.Text, textBox_linkanh.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        public void sua_TacGia()
        {
            try
            {
                DateTime date;
                try
                {
                   date = DateTime.Parse(maskedTextBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                date = DateTime.Parse(maskedTextBox1.Text);
                string sql = string.Format("update tacgia set tentg = N'{0}', ngaysinh = '{1}', tieusu = N'{2}', hinhanh_tg = '{3}' where matg = '{4}'", textBox_name.Text, date.ToString("yyyy-MM-dd"), richTextBox1.Text, textBox_linkanh.Text, textBox_matg.Text);
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

        public void xoa_TacGia()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from tacgia where matg = '{0}'", textBox_matg.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        void loadData_TacGia()
        {
            dataGridView1.RowTemplate.Height = 100;
            string sql = "select * from tacgia";
            adapter = new SqlDataAdapter(sql,cn);
            dt = new DataTable();
            adapter.Fill(dt);

            // Thêm cột hình ảnh vào DataTable (sử dụng cột đã có HINHANH_TG)
            dt.Columns.Add("HINHANH", typeof(Image));

            // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
            foreach (DataRow row in dt.Rows)
            {
                string relativeImagePath = row["HINHANH_TG"].ToString(); // Đường dẫn tương đối

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imageDirectory = Path.Combine(Application.StartupPath, "img", "TacGia"); // Thư mục chứa hình ảnh

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
            dataGridView1.Columns["TIEUSU"].Width = 300;
        }

        public TacGia()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            loadData_TacGia();
            groupBox1.Enabled = false;
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button_foradmin.Show();
            }
            else button_foradmin.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
            dataGridView1.Enabled = false;
            groupBox1.Enabled = true;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            textBox_matg.Enabled = false;
            textBox_matg.Text = maTG();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_del.Enabled = false;
            textBox_matg.Enabled = false;
            pictureBox1.Show();
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

        string maTG()
        {
            string sql = "select top 1 matg from tacgia order by matg desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "TG001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(2));
                stt++;
                newStr = "TG" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length == 0 || maskedTextBox1.Text.Length < 10 || richTextBox1.Text.Length == 0 || pictureBox1.Image == null)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (button_add.Enabled == true)
            {
                them_TacGia();
                loadData_TacGia();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else if (button_edit.Enabled ==true)
            {
                sua_TacGia();
                loadData_TacGia();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
            }
            else if (button_del.Enabled == true)
            {
                xoa_TacGia();
                loadData_TacGia();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                textBox_matg.Enabled = true;
                textBox_name.Enabled = true;
                maskedTextBox1.Enabled = true;
                richTextBox1.Enabled = true;
                file.Enabled = true;
            }        
        }

        private void TacGia_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Show();
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    textBox_matg.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    textBox_name.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    DateTime datevalue = (DateTime)dataGridView1.Rows[index].Cells[2].Value;
                    maskedTextBox1.Text = datevalue.ToString("dd-MM-yyyy");
                    richTextBox1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    textBox_linkanh.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    Bitmap bitmap = (Bitmap)dataGridView1.Rows[index].Cells[5].Value;
                    // Gán Bitmap cho PictureBox
                    pictureBox1.Image = bitmap;              
                }
                catch (Exception)
                {
                    
                }        
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
            groupBox1.Enabled = false;
            button_add.Enabled = true;
            button_del.Enabled = true;
            button_edit.Enabled = true;
            dataGridView1.Enabled = true;
            textBox_matg.Enabled = true;
            textBox_name.Enabled = true;
            maskedTextBox1.Enabled = true;
            richTextBox1.Enabled = true;
            file.Enabled = true;
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_edit.Enabled = false;
            textBox_matg.Enabled = false;
            textBox_name.Enabled = false;
            maskedTextBox1.Enabled = false;
            richTextBox1.Enabled = false;
            file.Enabled = false;
        }

        void Seach_ThongTin()
        {
            try
            {
                string sql = string.Format("select * from tacgia where matg like '%' + '{0}' + '%' or tentg like '%' + N'{0}' + '%' or ngaysinh like '%' + '{0}' + '%' or tieusu like '%' + N'{0}' + '%'", textBox_search.Text);
                adapter = new SqlDataAdapter(sql, cn);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dt.Columns.Add("HINHANH", typeof(Image));

                // Chuyển đổi đường dẫn hình ảnh thành hình ảnh
                foreach (DataRow row in dt.Rows)
                {
                    string relativeImagePath = row["HINHANH_TG"].ToString(); // Đường dẫn tương đối

                    string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string imageDirectory = Path.Combine(Application.StartupPath, "img", "TacGia"); // Thư mục chứa hình ảnh
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
                dataGridView1.Columns["TIEUSU"].Width = 300;
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu");
            }
        }

        private void button_seach_Click(object sender, EventArgs e)
        {  
            Seach_ThongTin();
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loadData_TacGia();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Form f = new NhaXuatBan();
            f.Show();
            this.Hide();
        }

        private void button_sl_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            Form f = new Sach();
            f.Show();
            this.Hide();
        }

        private void button_home_Click(object sender, EventArgs e)
        {       
            Form f = new TrangChu();
            f.Show();
            this.Hide();
        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (textBox_matg.Enabled == true)
            {
                textBox_matg.Enabled = false;
            }
            else textBox_matg.Enabled = true;
        }

        private void TacGia_FormClosing(object sender, FormClosingEventArgs e)
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

    }
}
