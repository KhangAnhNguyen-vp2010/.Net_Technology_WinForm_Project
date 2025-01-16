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

namespace QuanLyThuVien
{
    public partial class TheLoai : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlCommand cmd;

        public TheLoai()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        void LoadData()
        {
            string sql = "select * from theloai";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
        }

        void them()
        {
            try
            {
                cn.Open();
                string sql = string.Format("insert into theloai values('{0}', N'{1}', N'{2}')", textBox_ma.Text, textBox_name.Text, richTextBox1.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
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
                string sql = string.Format("update theloai set tenloai = N'{0}', mota = N'{1}' where maloai = '{2}'", textBox_name.Text, richTextBox1.Text, textBox_ma.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        void xoa()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete theloai where maloai = '{0}'", textBox_ma.Text);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        private void TheLoai_Load(object sender, EventArgs e)
        {
            LoadData();
            groupBox1.Enabled = false;
            textBox_ma.Enabled = false;
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button_foradmin.Show();
            }
            else button_foradmin.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    textBox_ma.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    textBox_name.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    richTextBox1.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                }
                catch (Exception)
                {

                }
            }
        }

        void clearDuLieu()
        {
            textBox_ma.Clear();
            textBox_name.Clear();
            richTextBox1.Clear();
        }

        string maTL()
        {
            string sql = "select top 1 maloai from theloai order by maloai desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "L001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(1));
                stt++;
                newStr = "L" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            clearDuLieu();
            textBox_ma.Text = maTL();
            groupBox1.Enabled = true;
            dataGridView1.Enabled = false;
            button_del.Enabled = false;
            button_edit.Enabled = false;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            button_add.Enabled = true;
            button_edit.Enabled = true;
            button_del.Enabled = true;
            dataGridView1.Enabled = true;
            groupBox1.Enabled = false;
            textBox_name.Enabled = true;
            richTextBox1.Enabled = true;
            clearDuLieu();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_del.Enabled = false;
            button_add.Enabled = false;
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_edit.Enabled = false;
            button_add.Enabled = false;
            textBox_name.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (button_add.Enabled == true)
            {
                if (textBox_ma.Text.Length == 0 || textBox_name.Text.Length == 0 || richTextBox1.Text.Length == 0)
                {
                    MessageBox.Show("Nhập Đầy Đủ Dữ Liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    them();
                    button_add.Enabled = true;
                    button_del.Enabled = true;
                    button_edit.Enabled = true;
                    groupBox1.Enabled = false;
                    dataGridView1.Enabled = true;
                    clearDuLieu();
                }
            }
            else if (button_edit.Enabled == true)
            {
                if (textBox_ma.Text.Length == 0 || textBox_name.Text.Length == 0 || richTextBox1.Text.Length == 0)
                {
                    MessageBox.Show("Nhập Đầy Đủ Dữ Liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    edit();
                    button_add.Enabled = true;
                    button_del.Enabled = true;
                    button_edit.Enabled = true;
                    groupBox1.Enabled = false;
                    clearDuLieu();
                }
            }
            else if (button_del.Enabled == true)
            {
                xoa();
                button_add.Enabled = true;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                groupBox1.Enabled = false;
                textBox_name.Enabled = true;
                richTextBox1.Enabled = true;
                clearDuLieu();
            }
        }

        private void button_seach_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from THELOAI where MALOAI like '%' + '{0}' + '%' or TENLOAI like '%' + N'{0}' + '%' or MOTA like '%' + N'{0}' + '%'", textBox_search.Text);
            adapter = new SqlDataAdapter(sql,cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Sach();
            f.Show();
            this.Hide();
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (textBox_ma.Enabled == false)
            {
                textBox_ma.Enabled = true;
            }
            else textBox_ma.Enabled = false;
        }


    }
}
