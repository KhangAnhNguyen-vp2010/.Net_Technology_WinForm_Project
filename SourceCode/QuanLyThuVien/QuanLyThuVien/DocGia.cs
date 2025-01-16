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
    public partial class DocGia : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;
        public DocGia()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
        }

        private void DocGia_Load(object sender, EventArgs e)
        {
            loaddocgia();
            groupBox1.Enabled = false;
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button_foradmin.Show();
            }
            else
            {
                button_foradmin.Hide();
            }
        }

        public void them_DocGia()
        {
            try
            {
                DateTime ns = DateTime.Parse(mtxt_NS.Text);
                DateTime ndk = DateTime.Parse(mtxt_NDK.Text);
                cn.Open();
                string gt = "";
                if (radioButton_nam.Checked == true)
                {
                    gt = "Nam";
                }
                else gt = "Nữ";
                string sql = string.Format("insert into docgia values('{0}', N'{1}', N'{2}', '{3}', N'{4}','{5}','{6}','{7}')",
                    txt_MDG.Text, txt_TenDG.Text, gt, ns.ToString("yyyy-MM-dd"), rtxt_DC.Text, txt_Email.Text, txt_Phone.Text, ndk.ToString("yyyy-MM-dd"));
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        public void sua_DocGia()
        {
            try
            {
                DateTime ns = DateTime.Parse(mtxt_NS.Text);
                DateTime ndk = DateTime.Parse(mtxt_NDK.Text);
                cn.Open();
                string gt = "";
                if (radioButton_nam.Checked == true)
                {
                    gt = "Nam";
                }
                else gt = "Nữ";
                string sql = string.Format("update DOCGIA set TENDG = N'{0}',GIOITINH=N'{1}',NGAYSINH='{2}',DIACHI_DG=N'{3}',EMAIL='{4}',PHONE='{5}', ngaydangky='{6}' where madg = '{7}'", txt_TenDG.Text, gt, ns.ToString("yyyy-MM-dd"), rtxt_DC.Text, txt_Email.Text, txt_Phone.Text, ndk.ToString("yyyy-MM-dd"), txt_MDG.Text);
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
        public void xoa_DocGia()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from DOCGIA where MADG = '{0}'", txt_MDG.Text);
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

        void loaddocgia()
        {
            string sql = "select * from DOCGIA";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
        }

        string maDG()
        {
            string sql = "select top 1 madg from docgia order by MADG desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "DG001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(2));
                stt++;
                newStr = "DG" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            ClearDuLieu();
            dataGridView1.Enabled = false;
            groupBox1.Enabled = true;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            txt_MDG.Enabled = false;
            txt_MDG.Text = maDG();
        }

        void ClearDuLieu()
        {
            txt_MDG.Clear();
            txt_TenDG.Clear();
            mtxt_NS.Clear();
            rtxt_DC.Clear();
            txt_Email.Clear();
            txt_Phone.Clear();
            mtxt_NDK.Clear();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_del.Enabled = false;
            txt_MDG.Enabled = false;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (txt_MDG.Text.Length == 0 || txt_TenDG.Text.Length == 0 || txt_Email.Text.Length == 0 || rtxt_DC.Text.Length == 0 || txt_Phone.Text.Length == 0 || mtxt_NS.Text.Length < 10 || mtxt_NDK.Text.Length < 10)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (button_add.Enabled == true)
            {
                them_DocGia();
                loaddocgia();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else if (button_edit.Enabled == true)
            {
                sua_DocGia();
                loaddocgia();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
            }
            else if (button_del.Enabled == true)
            {
                xoa_DocGia();
                loaddocgia();
                ClearDuLieu();
                button_add.Enabled = true;
                groupBox1.Enabled = false;
                button_del.Enabled = true;
                button_edit.Enabled = true;
                txt_TenDG.Enabled = true;
                mtxt_NS.Enabled = true;
                mtxt_NDK.Enabled = true;
                rtxt_DC.Enabled = true;
                txt_Email.Enabled = true;
                txt_Phone.Enabled = true;
            }          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    txt_MDG.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    txt_TenDG.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    if (dataGridView1.Rows[index].Cells[2].Value.ToString() == "Nam")
                    {
                        radioButton_nam.Checked = true;
                    }
                    else radioButton_nu.Checked = true;
                    DateTime ns = (DateTime)dataGridView1.Rows[index].Cells[3].Value;
                    mtxt_NS.Text = ns.ToString("dd-MM-yyyy");
                    rtxt_DC.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    txt_Email.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    txt_Phone.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    DateTime ndk = (DateTime)dataGridView1.Rows[index].Cells[7].Value;
                    mtxt_NDK.Text = ndk.ToString("dd--MM--yyyy");
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
            txt_TenDG.Enabled = true;
            mtxt_NS.Enabled = true;
            mtxt_NDK.Enabled = true;
            rtxt_DC.Enabled = true;
            txt_Email.Enabled = true;
            txt_Phone.Enabled = true;
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_edit.Enabled = false;
            txt_TenDG.Enabled = false;
            mtxt_NS.Enabled = false;
            mtxt_NDK.Enabled = false;
            rtxt_DC.Enabled = false;
            txt_Email.Enabled = false;
            txt_Phone.Enabled = false;
        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loaddocgia();
        }

        private void button_seach_Click(object sender, EventArgs e)
        {
            Seach_ThongTin();
        }

        void Seach_ThongTin()
        {
            try
            {
                //string sql = string.Format("select * from docgia where madg like '%' + '{0}' + '%' or tendg like '%' + '{0}' + '%' or ngaysinh like '%' + '{0}' + '%' or diachi like '%' + '{0}' + '%'", textBox_search.Text);
                //adapter = new SqlDataAdapter(sql, cn);
                //dt = new DataTable();
                //adapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                //button_sl.Text = dataGridView1.RowCount.ToString();
                string sql = string.Format("SELECT * FROM DOCGIA WHERE MADG LIKE '%' + @searchText + '%' OR TENDG LIKE '%' + @searchText + '%' OR NGAYSINH LIKE '%' + @searchText + '%' OR DIACHI_DG LIKE '%' + @searchText + '%' OR GIOITINH LIKE '%' + @searchText + '%'", textBox_search.Text);
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@searchText", textBox_search.Text);

                    // Đổ dữ liệu vào DataTable
                    adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dataGridView1.DataSource = dt;
                    button_sl.Text = dataGridView1.RowCount.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu");
            }
        }

        private void phiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            Form f = new PhieuMuon();
            f.Show();
            this.Hide();
        }

        private void phiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            Form f = new PhieuPhat();
            f.Show();
            this.Hide();
        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (txt_MDG.Enabled == false)
            {
                txt_MDG.Enabled = true;
            }
            else txt_MDG.Enabled = false;
        }

        private void DocGia_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
