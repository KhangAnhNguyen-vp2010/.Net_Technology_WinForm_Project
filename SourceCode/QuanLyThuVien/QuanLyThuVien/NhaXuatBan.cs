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
    public partial class NhaXuatBan : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;

        void ClearDuLieu()
        {
            textBox_maNXB.Clear();
            textBox_nameNXB.Clear();
            richTextBox_DiaChi.Clear();
            textBox_lienhe.Clear();
        }

        public void them_NXB()
        {
            try
            {
                cn.Open();
                string sql = string.Format("insert into nhaxuatban values('{0}', N'{1}', N'{2}', N'{3}')", textBox_maNXB.Text, textBox_nameNXB.Text, richTextBox_DiaChi.Text, textBox_lienhe.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDuLieu();
                loadData_NXB();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                dataGridView1.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Số điện thoại phải 10 kí tự số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { cn.Close(); }
        }

        public void sua_NXB()
        {
            try
            {
                cn.Open();
                string sql = string.Format("update nhaxuatban set tennxb = N'{0}', diachi_nxb = N'{1}', lienhe = '{2}' where manxb = '{3}'", textBox_nameNXB.Text, richTextBox_DiaChi.Text, textBox_lienhe.Text, textBox_maNXB.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData_NXB();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Số điện thoại phải 10 kí tự số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally { cn.Close(); }
        }

        public void xoa_NXB()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from nhaxuatban where manxb = '{0}'", textBox_maNXB.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        void loadData_NXB()
        {
            string sql = "select * from nhaxuatban";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
        }

        public NhaXuatBan()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            loadData_NXB();
            groupBox1.Enabled = false;
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button_foradmin.Show();
            }
            else button_foradmin.Hide();
        }

        string maNXB()
        {
            string sql = "select top 1 manxb from nhaxuatban order by manxb desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "NXB001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(3));
                stt++;
                newStr = "NXB" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }
        
        private void button_add_Click_1(object sender, EventArgs e)
        {
            ClearDuLieu();
            dataGridView1.Enabled = false;
            groupBox1.Enabled = true;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            textBox_maNXB.Enabled = false;
            textBox_maNXB.Text = maNXB();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (textBox_maNXB.Text.Length == 0 || richTextBox_DiaChi.Text.Length == 0 || textBox_lienhe.Text.Length == 0)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (button_add.Enabled == true)
            {
                them_NXB();
            }
            else if (button_edit.Enabled == true)
            {
                sua_NXB();
            }
            else if (button_del.Enabled == true)
            {
                xoa_NXB();
                loadData_NXB();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                textBox_maNXB.Enabled = true;
                textBox_nameNXB.Enabled = true;
                richTextBox_DiaChi.Enabled = true;
                textBox_lienhe.Enabled = true;
            }
        }

        private void button_edit_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_del.Enabled = false;
            textBox_maNXB.Enabled = false;
        }

        

        private void button_cancel_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
            groupBox1.Enabled = false;
            button_add.Enabled = true;
            button_del.Enabled = true;
            button_edit.Enabled = true;
            dataGridView1.Enabled = true;
            textBox_maNXB.Enabled = true;
            textBox_nameNXB.Enabled = true;
            richTextBox_DiaChi.Enabled = true;
            textBox_lienhe.Enabled = true;
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_edit.Enabled = false;
            textBox_maNXB.Enabled = false;
            textBox_nameNXB.Enabled = false;
            richTextBox_DiaChi.Enabled = false;
            textBox_lienhe.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form f = new TacGia();
            f.Show();
        }

        void Seach_ThongTin()
        {
            try
            {
                string sql = string.Format("select * from nhaxuatban where manxb like '%' + '{0}' + '%' or tennxb like '%' + '{0}' + '%' or diachi_nxb like '%' + '{0}' + '%' or lienhe like '%' + '{0}' + '%'", textBox_search.Text);
                adapter = new SqlDataAdapter(sql, cn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                button_sl.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu");
                
            }
        }

        private void dsadsadsadsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Seach_ThongTin();
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loadData_NXB();
        }

        private void dsadsadToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            Form f = new TacGia();
            f.Show();
            this.Hide();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            Form f = new Sach();
            f.Show();
            this.Hide();
        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (textBox_maNXB.Enabled == true)
            {
                textBox_maNXB.Enabled = false;
            }
            else textBox_maNXB.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    textBox_maNXB.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    textBox_nameNXB.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    richTextBox_DiaChi.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    textBox_lienhe.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                }
                catch (Exception)
                {

                }
            }
        }

        private void NhaXuatBan_FormClosing(object sender, FormClosingEventArgs e)
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
