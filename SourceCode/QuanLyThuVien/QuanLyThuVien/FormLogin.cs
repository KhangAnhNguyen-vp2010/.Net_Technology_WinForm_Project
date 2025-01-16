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
    public partial class FormLogin : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();       
        public FormLogin()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch; // hoặc ImageLayout.Zoom

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            panel_doipass.Hide();
        }

        int check_admin()
        {
            if (textBox_TK.Text == "admin" && textBox_MK.Text == "admin123")
            {
                return 1;
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_TK.Text.Length == 0 || textBox_MK.Text.Length == 0)
            {
                MessageBox.Show("Nhập đầy đủ tài khoản - mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cn.Open();
                string sql = string.Format("select COUNT(*) from _USER_ where TENTAIKHOAN = '{0}' AND MATKHAU = '{1}'", textBox_TK.Text, textBox_MK.Text);
                SqlCommand cmd = new SqlCommand(sql, cn);
                int count = (int)cmd.ExecuteScalar();
                if (count == 0 && check_admin() == 0)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string a = "";
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        string sql2 = string.Format("select vaitro from _USER_ where TENTAIKHOAN = '{0}' AND MATKHAU = '{1}'", textBox_TK.Text, textBox_MK.Text);
                        cmd = new SqlCommand(sql2, cn);
                        if (textBox_TK.Text != "admin" && textBox_MK.Text != "admin123")
                        {
                            string vt = cmd.ExecuteScalar().ToString();
                            a = vt;                          
                        }
                        else MessageBox.Show("Bạn đang đăng nhập với quyền admin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string ngayThangNam = DateTime.Now.ToString("yyyy/MM/dd");
                        try
                        {
                            //cn.Open();
                            string sql3 = string.Format("update _USER_ set LAST_LOGIN = '{0}' where TENTAIKHOAN = '{1}'", ngayThangNam, textBox_TK.Text);
                            cmd = new SqlCommand(sql3, cn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //finally { cn.Close(); }   
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bạn đang đăng nhập với quyền admin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    StaticUser.tenTK = textBox_TK.Text;
                    StaticUser.vaiTro = a.Trim();
                    Form f = new TrangChu();                     
                    f.Show();
                    this.Hide(); 
                }
                cn.Close();
            }         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_dangnhap.Hide();
            panel_doipass.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_doipass_tk.Text.Length == 0 || textBox_doipass_tk.Text.Length == 0 || textBox_doipass_newmk.Text.Length == 0)
            {
                MessageBox.Show("Nhập đầy đủ tài khoàn - mật khẩu hiện tại - new mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cn.Open();
                string sql = string.Format("select COUNT(*) from _USER_ where TENTAIKHOAN = '{0}' AND MATKHAU = '{1}'", textBox_doipass_tk.Text, textBox_doipass_mk.Text);
                SqlCommand cmd = new SqlCommand(sql, cn);
                int count = (int)cmd.ExecuteScalar();
                if (count==0)
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sql2 = string.Format("update _user_ set matkhau = '{0}' where tentaikhoan = '{1}'", textBox_doipass_newmk.Text, textBox_doipass_tk.Text);
                    cmd = new SqlCommand(sql2, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thay Đổi Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel_doipass.Hide();
                    panel_dangnhap.Show();
                }
                cn.Close();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_dangnhap.Show();
            panel_doipass.Hide();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Có Muốn Thoát???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
            else Environment.Exit(0);
        }
    }
}
