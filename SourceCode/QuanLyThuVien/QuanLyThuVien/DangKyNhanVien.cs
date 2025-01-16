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
    public partial class DangKyNhanVien : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlCommand cmd;
        public DangKyNhanVien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cn = kn.conn;
        }

        private void DangKyNhanVien_Load(object sender, EventArgs e)
        {
            comboBox_vaitro.SelectedIndex = 0;          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_tentk.Text.Length == 0 || textBox_mk.Text.Length == 0 || textBox_mkag.Text.Length == 0)
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox_mkag.Text == textBox_mk.Text)
                    {
                        cn.Open();
                        string sql = string.Format("Insert into _USER_ values('{0}','{1}','{2}',null,null)", textBox_tentk.Text, textBox_mk.Text, comboBox_vaitro.Text);
                        cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng Ký Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_tentk.Clear();
                        textBox_mk.Clear();
                        textBox_mkag.Clear();
                    }
                    else MessageBox.Show("Đăng ký không thành công do mật khẩu xác nhận không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();         
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
