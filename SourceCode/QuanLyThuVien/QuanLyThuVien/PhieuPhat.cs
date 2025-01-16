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
    public partial class PhieuPhat : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;
        public PhieuPhat()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        void loadData_PhieuPhat()
        {
            string sql = "select * from phieuphat";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.Rows.Count.ToString();
            button_sumtien.Text = "Tổng Tiền Thanh Toán: " + sum_TienPhat().ToString();
        }

        void them_PhieuPhat()
        {
            try
            {
                DateTime date;
                try
                {
                    date = DateTime.Parse(maskedTextBox_ngaylap.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày lập không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                string thanhtoan = "";
                date = DateTime.Parse(maskedTextBox_ngaylap.Text);
                if (radio_chua.Checked == true)
                {
                    thanhtoan = "Chưa thanh toán";
                }
                else thanhtoan = "Đã thanh toán";
                string sql = string.Format("insert into phieuphat values('{0}', '{1}', '{2}', '{3}', '{4}', N'{5}')", textBox_mapm.Text, textBox_madg.Text, textBox_mash.Text, date.ToString("yyyy-MM-dd"), textBox_tienphat.Text, thanhtoan);
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
                
        }

        void sua_PhieuPhat()
        {
            try
            {
                DateTime date;
                try
                {
                    date = DateTime.Parse(maskedTextBox_ngaylap.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày lập không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                string thanhtoan = "";
                date = DateTime.Parse(maskedTextBox_ngaylap.Text);
                if (radio_chua.Checked == true)
                {
                    thanhtoan = "Chưa thanh toán";
                }
                else thanhtoan = "Đã thanh toán";
                string sql = string.Format("update phieuphat set ngaylap = '{0}', tienphat = '{1}', pp_status = N'{2}' where mapm = '{3}' and madg = '{4}' and mash = '{5}'", date.ToString("yyyy-MM-dd"), textBox_tienphat.Text, thanhtoan, textBox_mapm.Text, textBox_madg.Text, textBox_mash.Text);
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

        void xoa_PhieuPhat()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from phieuphat where mapm = '{0}' and madg = '{1}' and mash = '{2}'", textBox_mapm.Text, textBox_madg.Text, textBox_mash.Text);
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

        private void PhieuPhat_Load(object sender, EventArgs e)
        {
            loadData_PhieuPhat();
            groupBox1.Enabled = false;
            radioButton_da.Checked = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_del_Click(object sender, EventArgs e)
        {
            if (status_pp == "Chưa thanh toán")
            {
                MessageBox.Show("Phiếu Phạt Chưa Thanh Toán. Không Thể Xoá", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                groupBox1.Enabled = true;
                button_add.Enabled = false;
                button_edit.Enabled = false;
                textBox_mapm.Enabled = false;
                textBox_madg.Enabled = false;
                textBox_mash.Enabled = false;
            }           
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_del.Enabled = false;
            textBox_mapm.Enabled = false;
            textBox_madg.Enabled = false;
            textBox_mash.Enabled = false;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            textBox_mapm.Enabled = true;
            textBox_madg.Enabled = true;
            textBox_mash.Enabled = true;
        }

        private void maskedTextBox_ngaylap_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        string status_pp = "";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    textBox_mapm.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    textBox_madg.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    textBox_mash.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    DateTime datevalue = (DateTime)dataGridView1.Rows[index].Cells[3].Value;
                    maskedTextBox_ngaylap.Text = datevalue.ToString("dd-MM-yyyy");
                    textBox_tienphat.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    if (dataGridView1.Rows[index].Cells[5].Value.ToString() == "Chưa thanh toán")
                    {
                        radio_chua.Checked = true;
                    }
                    else radioButton_da.Checked = true;
                    status_pp = dataGridView1.Rows[index].Cells[5].Value.ToString();
                }
                catch (Exception)
                {

                }
            }
        }

        void clearDuLieu()
        {
            textBox_madg.Clear();
            textBox_mapm.Clear();
            textBox_mash.Clear();
            maskedTextBox_ngaylap.Clear();
            textBox_tienphat.Clear();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            clearDuLieu();
            button_add.Enabled = true;
            button_del.Enabled = true;
            button_edit.Enabled = true;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (textBox_madg.Text.Length == 0 || textBox_mapm.Text.Length == 0 || textBox_mash.Text.Length == 0 || maskedTextBox_ngaylap.Text.Length < 10 || textBox_tienphat.Text.Length == 0)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (button_add.Enabled == true)
                {
                    them_PhieuPhat();
                    button_add.Enabled = true;
                    button_del.Enabled = true;
                    button_edit.Enabled = true;
                    clearDuLieu();
                    groupBox1.Enabled = false;
                    loadData_PhieuPhat();
                }
                else if (button_edit.Enabled == true)
                {
                    sua_PhieuPhat();
                    button_add.Enabled = true;
                    button_del.Enabled = true;
                    button_edit.Enabled = true;
                    clearDuLieu();
                    groupBox1.Enabled = false;
                    loadData_PhieuPhat();
                }
                else if (button_del.Enabled == true)
                {
                    xoa_PhieuPhat();
                    button_add.Enabled = true;
                    button_del.Enabled = true;
                    button_edit.Enabled = true;
                    clearDuLieu();
                    groupBox1.Enabled = false;
                    loadData_PhieuPhat();
                }
            }
        }

        double sum_TienPhat()
        {
            cn.Open();
            double sum = 0;
            string sql = "select SUM(TIENPHAT) from PHIEUPHAT where PP_STATUS = N'Đã Thanh Toán'";
            cmd = new SqlCommand(sql, cn);
            string a = cmd.ExecuteScalar().ToString();
            if (a != "")
            {
                sum = double.Parse(cmd.ExecuteScalar().ToString());
            }
            cn.Close();
            return sum;
        }

        void search_ThongTin()
        {
            string sql = string.Format("select * from PHIEUPHAT WHERE MAPM LIKE '%' + '{0}' + '%' OR MADG LIKE '%' + '{0}' + '%' OR MASH LIKE '%' + '{0}' + '%' OR NGAYLAP LIKE '%' + '{0}' + '%' OR TIENPHAT LIKE '%' + '{0}' + '%' OR PP_STATUS LIKE '%' + N'{0}' + '%'", textBox_search.Text);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button_seach_Click(object sender, EventArgs e)
        {
            search_ThongTin();
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loadData_PhieuPhat();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void phiếuMươnjToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            Form f = new PhieuMuon();
            f.Show();
            this.Hide();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            Form f = new DocGia();
            f.Show();
            this.Hide();
        }

        private void PhieuPhat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
