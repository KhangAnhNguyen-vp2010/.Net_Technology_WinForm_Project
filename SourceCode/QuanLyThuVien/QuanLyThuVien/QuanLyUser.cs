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
    public partial class QuanLyUser : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;

        public QuanLyUser()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        public void loaduser()
        {
            string sql = "select * from _USER_";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
            LoadCBB_User();
            LoadCBB_NV();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void QuanLyUser_Load(object sender, EventArgs e)
        {
            loaduser();
            groupBox1.Enabled = false;
            comboBox_user.Enabled = false;
            button_ok.Enabled = false;
            LoadCBB_User();
            LoadCBB_NV();
            comboBox_user.SelectedIndex = -1;
            comboBox_nv.Enabled = false;
            comboBox_roleuser.Enabled = false;
            comboBox_roleuser.SelectedIndex = -1;
            comboBox_nv.SelectedIndex = -1;
            button_done.Enabled = false;
            if (StaticUser.vaiTro == "")
            {
                groupBox3.Show();
            }
            else groupBox3.Hide();

            if (StaticUser.vaiTro == "")
            {
                button_del.Show();
            }
            else button_del.Hide();
        }

        public void sua_User()
        {
            try
            {
                cn.Open();
                DateTime nt = DateTime.Parse(maskedTextBox_nt.Text);
                DateTime ll = DateTime.Parse(maskedTextBox_ll.Text);
                string sql = string.Format("update _USER_ set ngaytao = '{0}', last_login = '{1}' where TENTAIKHOAN = '{2}'", nt.ToString("yyyy-MM-dd"), ll.ToString("yyyy-MM-dd"), txt_TK.Text);
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

        public void xoa_user()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from _USER_ where TENTAIKHOAN = '{0}'", txt_TK.Text);
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

        private void button_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            maskedTextBox_ll.Enabled = true;
            maskedTextBox_nt.Enabled = true;
            button_del.Enabled = false;
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            maskedTextBox_ll.Enabled = false;
            maskedTextBox_nt.Enabled = false;
            button_edit.Enabled = false;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (txt_TK.Text.Length == 0 || txt_MK.Text.Length == 0)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (button_edit.Enabled == true)
            {
                sua_User();
                loaduser();
                button_del.Enabled = true;
                groupBox1.Enabled = false;            
            }
            else if (button_del.Enabled == true)
            {
                xoa_user();
                loaduser();
                groupBox1.Enabled = false;
                button_edit.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    txt_TK.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    txt_MK.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    txt_Vaitro.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    DateTime nt = (DateTime)dataGridView1.Rows[index].Cells[3].Value;
                    maskedTextBox_nt.Text = nt.ToString("dd-MM-yyyy");
                    DateTime ll = (DateTime)dataGridView1.Rows[index].Cells[4].Value;
                    maskedTextBox_ll.Text = ll.ToString("dd-MM-yyyy");
                }
                catch (Exception)
                {

                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            button_del.Enabled = true;
            button_edit.Enabled = true;
            txt_MK.Enabled = false;
            txt_Vaitro.Enabled = false;
            txt_TK.Enabled = false;
            groupBox1.Enabled = false;
        }

        void TimKiem()
        {
            string sql = string.Format("select * from _USER_ where TENTAIKHOAN like '%' + '{0}' + '%' or matkhau like '%' + '{0}' + '%' or vaitro like '%' + '{0}' + '%' or ngaytao like '%' + '{0}' + '%' or last_login like '%' + '{0}' + '%'", textBox_search.Text);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loaduser();
        }

        private void button_seach_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_sl_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }

        void LoadCBB_User()
        {
            string sql = "select tentaikhoan from _user_";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_user.DataSource = dt;
            comboBox_user.DisplayMember = "tentaikhoan";
            comboBox_user.ValueMember = "tentaikhoan";          
        }

        void LoadCBB_NV()
        {
            string sql = "select tentaikhoan from _user_";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_nv.DataSource = dt;
            comboBox_nv.DisplayMember = "tentaikhoan";
            comboBox_nv.ValueMember = "tentaikhoan";
        }

        private void button_rspass_Click(object sender, EventArgs e)
        {
            if (button_ok.Enabled == false)
            {
                button_rspass.Text = "Cancel";
                comboBox_user.Enabled = true;
                button_ok.Enabled = true;
                try
                {
                    comboBox_user.SelectedIndex = 0;
                }
                catch (Exception)
                {

                }           
            }
            else
            {
                button_rspass.Text = "Reset Password";
                button_ok.Enabled = false;
                comboBox_user.Enabled = false;
                comboBox_user.SelectedIndex = -1;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = string.Format("update _user_ set matkhau = '123' where tentaikhoan = '{0}'", comboBox_user.SelectedValue);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Reset Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaduser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
            button_rspass.Text = "Reset Password";
            button_ok.Enabled = false;
            comboBox_user.Enabled = false;
            comboBox_user.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new DangKyNhanVien();
            f.Show();
        }

        private void QuanLyUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void QuanLyUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = string.Format("update _user_ set vaitro = '{0}' where tentaikhoan = '{1}'", comboBox_roleuser.Text, comboBox_nv.SelectedValue);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Set Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaduser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
            button_setrole.Text = "Set Role";
            comboBox_nv.Enabled = false;
            comboBox_roleuser.Enabled = false;
            comboBox_roleuser.SelectedIndex = -1;
            comboBox_nv.SelectedIndex = -1;
            button_done.Enabled = false;
        }

        private void button_setrole_Click(object sender, EventArgs e)
        {
            if (comboBox_nv.Enabled == false)
            {
                button_setrole.Text = "Cancel";
                comboBox_nv.Enabled = true;
                comboBox_roleuser.Enabled = true;
                comboBox_roleuser.SelectedIndex = 0;
                try
                {
                    comboBox_nv.SelectedIndex = 0;
                }
                catch (Exception)
                {

                }              
                button_done.Enabled = true;
            }
            else
            {
                button_setrole.Text = "Set Role";
                comboBox_nv.Enabled = false;
                comboBox_roleuser.Enabled = false;
                comboBox_roleuser.SelectedIndex = -1;
                comboBox_nv.SelectedIndex = -1;
                button_done.Enabled = false;
            }
        }

        private void button_home_Click(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new NhanVien();
            f.Show();
            this.Hide();
        }
    }
}
