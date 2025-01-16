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
    public partial class PhieuMuon : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;

        void loadData_PM()
        {
            string sql = "select * from phieumuon";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            
        }
        public PhieuMuon()
        {
            InitializeComponent();
            cn = kn.conn;
            this.WindowState = FormWindowState.Maximized;
            
        }

        string maPM()
        {
            string sql = "select top 1 mapm from phieumuon order by mapm desc";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            string old = "PM001";
            string newStr;
            if (dt.Rows.Count > 0)
            {
                old = dt.Rows[0][0].ToString();
                int stt = int.Parse(old.Substring(2));
                stt++;
                newStr = "PM" + stt.ToString("D3");
                return newStr;
            }
            return old;
        }

        void them_PM()
        {
            try
            {
                cn.Open();
                string sql = string.Format("insert into phieumuon values('{0}', '{1}', null)", textBox_mapm.Text, comboBox_madg.SelectedValue);
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

        void sua_PM()
        {
            if (maskedTextBox_ngaylap.Text.Length < 10)
            {
                MessageBox.Show("Nhập đủ dữ liệu 'Ngày Lập'", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DateTime now;
                    try
                    {
                        now = DateTime.Parse(maskedTextBox_ngaylap.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ngày lập không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cn.Open();
                    now = DateTime.Parse(maskedTextBox_ngaylap.Text);
                    string sql = string.Format("update phieumuon set madg = '{0}', ngaylap = '{1}' where mapm = '{2}'", comboBox_madg.SelectedValue, now.ToString("yyyy-MM-dd"), textBox_mapm.Text);
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
        }

        void xoa_PM()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete from phieumuon where mapm = '{0}'", textBox_mapm.Text);
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

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            loadData_PM();
            button_huy.Enabled = false;
            button_submitnew.Enabled = false;
            maskedTextBox_trathucte.Enabled = false;
            button_tra.Enabled = false;
            groupBox1.Enabled = false;
            button_add.Enabled = false;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            loadCBB_DocGia();
            comboBox_madg.Enabled = false;
            maskedTextBox_ngaylap.Enabled = false;
            textBox_search.Enabled = false;
            button_seach.Enabled = false;
            button_rl.Enabled = false;
            button_sl.Text = (0).ToString();
            if (dataGridView2.Rows.Count > 0)
            {
                textBox_mapm.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                comboBox_madg.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                index_maPM = textBox_mapm.Text;
            }
            if (StaticUser.vaiTro == "manager" || StaticUser.vaiTro == "")
            {
                button_foradmin.Show();
                button_enale_pm.Show();
            }
            else
            {
                button_foradmin.Hide();
                button_enale_pm.Hide();
            }
        }

        private void button_newPM_Click(object sender, EventArgs e)
        {
            textBox_mapm.Text = maPM();
            button_sua.Enabled = false;
            button_xoa.Enabled = false;
            button_submitnew.Enabled = true;
            button_huy.Enabled = true;
            comboBox_madg.Enabled = true;
        }

        private void button_submitnew_Click(object sender, EventArgs e)
        {
            if (button_newPM.Enabled == true)
            {
                them_PM();
                textBox_mapm.Clear();
                maskedTextBox_ngaylap.Clear();
                button_newPM.Enabled = true;
                button_sua.Enabled = true;
                button_xoa.Enabled = true;
                loadData_PM();
                button_submitnew.Enabled = false;
                button_huy.Enabled = false;
                comboBox_madg.Enabled = false;
                maskedTextBox_ngaylap.Clear();
            }
            else if (button_sua.Enabled == true)
            {
                sua_PM();
                textBox_mapm.Clear();
                maskedTextBox_ngaylap.Clear();
                maskedTextBox_ngaylap.Enabled = false;
                button_newPM.Enabled = true;
                button_sua.Enabled = true;
                button_xoa.Enabled = true;
                loadData_PM();
                button_submitnew.Enabled = false;
                button_huy.Enabled = false;
                comboBox_madg.Enabled = false;
            }
            else if (button_xoa.Enabled == true)
            {
                xoa_PM();
                textBox_mapm.Clear();
                maskedTextBox_ngaylap.Clear();
                maskedTextBox_ngaylap.Enabled = false;
                button_newPM.Enabled = true;
                button_sua.Enabled = true;
                button_xoa.Enabled = true;
                loadData_PM();
                button_submitnew.Enabled = false;
                button_huy.Enabled = false;
                comboBox_madg.Enabled = false;
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            button_newPM.Enabled = false;
            button_xoa.Enabled = false;
            maskedTextBox_ngaylap.Enabled = true;
            button_submitnew.Enabled = true;
            button_huy.Enabled = true;
            comboBox_madg.Enabled = true;
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            button_sua.Enabled = false;
            button_newPM.Enabled = false;
            button_submitnew.Enabled = true;
            button_huy.Enabled = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    index_maPM = dataGridView2.Rows[index].Cells[0].Value.ToString();
                    textBox_mapm.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
                    comboBox_madg.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
                    DateTime datevalue = (DateTime)dataGridView2.Rows[index].Cells[2].Value;
                    maskedTextBox_ngaylap.Text = datevalue.ToString("dd-MM-yyyy");
                }
                catch (Exception)
                {

                }
            }
        }

        private void button_huy_Click(object sender, EventArgs e)
        {
            maskedTextBox_ngaylap.Enabled = false;
            button_newPM.Enabled = true;
            button_sua.Enabled = true;
            button_xoa.Enabled = true;
            button_submitnew.Enabled = false;
            button_huy.Enabled = false;
            comboBox_madg.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------\\
        string index_maPM;
        void loadCBB_DocGia()
        {
            string sql = "select * from docgia";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_madg.DataSource = dt;
            comboBox_madg.DisplayMember = "madg";
            comboBox_madg.ValueMember = "madg";
        }

        void loadCBB_Sach()
        {
            string sql = "select * from sach";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_mash.DataSource = dt;
            comboBox_mash.DisplayMember = "tensh";
            comboBox_mash.ValueMember = "mash";
        }

        void loadCBB_NV()
        {
            string sql = "select * from nhanvien";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_manv.DataSource = dt;
            comboBox_manv.DisplayMember = "tennv";
            comboBox_manv.ValueMember = "manv";
        }

        void loadData_CTPM(string ma)
        {
            string sql = string.Format("select * from chitietpm where mapm = '{0}'", ma);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.RowCount.ToString();
        }
        
        void them_CTPM()
        {
            try
            {
                DateTime date1, date2, ngaylap;  
                try
                {
                    date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                    date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                    ngaylap = DateTime.Parse(maskedTextBox_ngaylap.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có một DateTime không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                ngaylap = DateTime.Parse(maskedTextBox_ngaylap.Text);
                if (date1 >= ngaylap)
                {
                    string sql = string.Format("insert into chitietpm values('{0}', '{1}', '{2}', '{3}', null, null, '{4}')", index_maPM, comboBox_mash.SelectedValue, date1.ToString("yyyy-MM-dd"), date2.ToString("yyyy-MM-dd"), comboBox_manv.SelectedValue);
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Ngày mượn phải >= ngày lập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
                          
        }

        void sua_CTPM()
        {
            try
            {
                DateTime date1, date2, ngaylap;
                try
                {
                    date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                    date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                    ngaylap = DateTime.Parse(maskedTextBox_ngaylap.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có một DateTime không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                ngaylap = DateTime.Parse(maskedTextBox_ngaylap.Text);
                if (date1 >= ngaylap)
                {
                    string sql = string.Format("update chitietpm set ngaymuon = '{0}', hantra = '{1}', manv_phutrach = '{2}' where mapm = '{3}' and mash= '{4}'", date1.ToString("yyyy-MM-dd"), date2.ToString("yyyy-MM-dd"), comboBox_manv.SelectedValue, index_maPM, comboBox_mash.SelectedValue);
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Ngày mượn phải >= ngày lập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }      
        }

        void xoa_CTPM()
        {
            try
            {
                cn.Open();
                string sql = string.Format("delete chitietpm where mapm = '{0}' and mash = '{1}'", index_maPM, comboBox_mash.SelectedValue);
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

        void tra_Sach()
        {
            try
            {
                DateTime date1, date2, date3;
                try
                {
                    date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                    date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                    date3 = DateTime.Parse(maskedTextBox_trathucte.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có một DateTime không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                date3 = DateTime.Parse(maskedTextBox_trathucte.Text);
                if (date3 >= date1)
                {
                    string sql = string.Format("update chitietpm set ngaytra_thucte = '{0}', trangthai = N'Đã trả' where mapm = '{1}' and mash = '{2}'", date3.ToString("yyyy-MM-dd"), index_maPM, comboBox_mash.SelectedValue);
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sql1 = string.Format("update sach set tinhtrang = N'Chưa được mượn' where mash = '{0}'", comboBox_mash.SelectedValue);
                    cmd = new SqlCommand(sql1, cn);
                    cmd.ExecuteNonQuery();
                    if (date3 > date2)
                    {
                        string sql2 = string.Format("insert into phieuphat values('{0}', '{1}', '{2}', '{3}', null, null)", index_maPM, textBox_madg.Text, comboBox_mash.SelectedValue, date3.ToString("yyyy-MM-dd"));
                        cmd = new SqlCommand(sql2, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Ngày trả thực tế >= Ngày mượn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cn.Close(); }
        }

        private void button_xemct_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = false;
            textBox_mactpm.Text = index_maPM;
            textBox_madg.Text = comboBox_madg.Text;
            loadData_CTPM(index_maPM);
            loadCBB_NV();
            loadCBB_Sach();
            OnOFF_CBB(1);
            button_tra.Enabled = true;          
            dataGridView1.Enabled = true;
            button_add.Enabled = true;
            button_edit.Enabled = true;
            button_del.Enabled = true;
            textBox_search.Enabled = true;
            button_seach.Enabled = true;
            button_rl.Enabled = true;
        }

        void OnOFF_CBB(int i)
        {
            if (i==1)
            {
                comboBox_manv.Hide();
                comboBox_mash.Hide();
            }
            else if (i==0)
            {
                comboBox_mash.Show();
                comboBox_manv.Show();
            }
        }

        private void button_tra_Click(object sender, EventArgs e)
        {
            maskedTextBox_trathucte.Enabled = true;
            groupBox1.Enabled = true;
            button_add.Enabled = false;
            button_del.Enabled = false;
            button_edit.Enabled = false;
            comboBox_manv.Enabled = false;
            comboBox_mash.Enabled = false;
            maskedTextBox_hantra.Enabled = false;
            maskedTextBox_ngaymuon.Enabled = false;
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            dataGridView1.Enabled = false;
            button_add.Enabled = false;
            button_edit.Enabled = false;
            button_del.Enabled = false;
            OnOFF_CBB(1);
            groupBox1.Enabled = false;
            button_tra.Enabled = false;
            textBox_mactpm.Clear();
            textBox_madg.Clear();
            dataGridView1.DataSource = null;
            textBox_search.Enabled = false;
            button_seach.Enabled = false;
            button_rl.Enabled = false;
            button_sl.Text = (0).ToString();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            button_edit.Enabled = false;
            button_del.Enabled = false;
            groupBox1.Enabled = true;
            button_tra.Enabled = false;
            OnOFF_CBB(0);
            loadCBB_NV();
            loadCBB_Sach();
            dataGridView1.Enabled = false;
            comboBox_manv.Enabled = true;
            comboBox_mash.Enabled = true;
            maskedTextBox_ngaymuon.Enabled = true;
            maskedTextBox_hantra.Enabled = true;
            maskedTextBox_ngaymuon.Clear();
            maskedTextBox_hantra.Clear();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            button_tra.Enabled = false;
            button_add.Enabled = false;
            button_del.Enabled = false;
            groupBox1.Enabled = true;
            comboBox_mash.Enabled = false;
            OnOFF_CBB(0);
        }

        string xetNgayTra = "";
        private void button_del_Click(object sender, EventArgs e)
        {             
            if (xetNgayTra == "")
            {
                MessageBox.Show("Không Thể Xoá", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OnOFF_CBB(0);
                button_tra.Enabled = false;
                button_add.Enabled = false;
                button_edit.Enabled = false;
                groupBox1.Enabled = true;
                comboBox_madg.Enabled = false;
                comboBox_manv.Enabled = false;
                comboBox_mash.Enabled = false;
                maskedTextBox_ngaymuon.Enabled = false;
                maskedTextBox_hantra.Enabled = false;
            }          
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            button_add.Enabled = true;
            button_del.Enabled = true;
            button_edit.Enabled = true;
            button_tra.Enabled = true;
            groupBox1.Enabled = false;
            OnOFF_CBB(1);
            maskedTextBox_trathucte.Enabled = false;           
            maskedTextBox_ngaymuon.Clear();
            maskedTextBox_hantra.Clear();
            dataGridView1.Enabled = true;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (maskedTextBox_ngaymuon.Text.Length < 10 || maskedTextBox_hantra.Text.Length < 10)
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu ngày-tháng-năm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DateTime date1, date2;
                try
                {
                    date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                    date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày mượn hoặc hạn trả không đúng định dạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                date1 = DateTime.Parse(maskedTextBox_ngaymuon.Text);
                date2 = DateTime.Parse(maskedTextBox_hantra.Text);
                if (date2 < date1)
                {
                    MessageBox.Show("Hạn trả phải > ngày mượn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (button_add.Enabled == true)
                    {
                        them_CTPM();
                        OnOFF_CBB(1);
                        maskedTextBox_ngaymuon.Clear();
                        maskedTextBox_hantra.Clear();
                        groupBox1.Enabled = false;
                        button_add.Enabled = true;
                        button_del.Enabled = true;
                        button_edit.Enabled = true;
                        loadData_CTPM(index_maPM);
                        dataGridView1.Enabled = true;
                        button_tra.Enabled = true;
                    }
                    else if (button_edit.Enabled == true)
                    {
                        sua_CTPM();
                        comboBox_mash.Enabled = true;
                        OnOFF_CBB(1);
                        maskedTextBox_ngaymuon.Clear();
                        maskedTextBox_hantra.Clear();
                        groupBox1.Enabled = false;
                        button_add.Enabled = true;
                        button_del.Enabled = true;
                        button_edit.Enabled = true;                     
                        loadData_CTPM(index_maPM);
                        button_tra.Enabled = true;
                    }
                    else if (button_del.Enabled == true)
                    {
                        xoa_CTPM();
                        OnOFF_CBB(1);
                        maskedTextBox_ngaymuon.Clear();
                        maskedTextBox_hantra.Clear();
                        groupBox1.Enabled = false;
                        button_add.Enabled = true;
                        button_del.Enabled = true;
                        button_edit.Enabled = true;
                        button_tra.Enabled = true;
                        comboBox_mash.Enabled = false;
                        comboBox_manv.Enabled = false;
                        loadData_CTPM(index_maPM);
                    }
                    else if (button_tra.Enabled == true)
                    {
                        if (maskedTextBox_trathucte.Text.Length < 10)
                        {
                            MessageBox.Show("Nhập đầy đủ ngày tháng năm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            tra_Sach();
                            maskedTextBox_ngaymuon.Clear();
                            maskedTextBox_hantra.Clear();
                            groupBox1.Enabled = false;
                            button_add.Enabled = true;
                            button_del.Enabled = true;
                            button_edit.Enabled = true;
                            button_tra.Enabled = true;
                            maskedTextBox_trathucte.Clear();
                            maskedTextBox_trathucte.Enabled = false;
                            loadData_CTPM(index_maPM);
                        }
                    }
                }
            }
        }

        string GiaTriCBB_Sach(string mash)
        {
            string sql = string.Format("select tensh from sach where mash = '{0}'", mash);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        string GiaTriCBB_NhanVien(string manv)
        {
            string sql = string.Format("select tennv from nhanvien where manv = '{0}'", manv);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OnOFF_CBB(0);
            if (e.RowIndex >= 0)
            {
                try
                {
                    int index = e.RowIndex;
                    textBox_mactpm.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    comboBox_mash.Text = GiaTriCBB_Sach(dataGridView1.Rows[index].Cells[1].Value.ToString());
                    DateTime datevalue1 = (DateTime)dataGridView1.Rows[index].Cells[2].Value;
                    maskedTextBox_ngaymuon.Text = datevalue1.ToString("dd-MM-yyyy");
                    DateTime datevalue2 = (DateTime)dataGridView1.Rows[index].Cells[3].Value;
                    maskedTextBox_hantra.Text = datevalue2.ToString("dd-MM-yyyy");
                    xetNgayTra = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    comboBox_manv.Text = GiaTriCBB_NhanVien(dataGridView1.Rows[index].Cells[6].Value.ToString());          
                }
                catch (Exception)
                {

                }
            }
        }

        private void button_xemtq_Click(object sender, EventArgs e)
        {
            string sql = "select * from chitietpm";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_sl_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button_rl_Click(object sender, EventArgs e)
        {
            loadData_CTPM(index_maPM);
        }

        private void textBox_mapm_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_madg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox_ngaylap_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_mactpm_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void search_ThongTin(string mapm)
        {
            string sql = string.Format("select * from CHITIETPM where MAPM = '{0}' AND (MASH LIKE '%' + '{1}' + '%' OR NGAYMUON LIKE '%' + '{1}' + '%' OR HANTRA LIKE '%' + '{1}' + '%' OR NGAYTRA_THUCTE LIKE '%' + '{1}' + '%' OR TRANGTHAI LIKE '%' + '{1}' + '%' OR MANV_PHUTRACH LIKE '%' + '{1}' + '%')", mapm, textBox_search.Text);
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button_sl.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button_seach_Click(object sender, EventArgs e)
        {
            search_ThongTin(index_maPM);
        }

        private void button_rl_Click_1(object sender, EventArgs e)
        {
            loadData_CTPM(index_maPM);
        }

        private void phiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            Form f = new PhieuPhat();
            f.Show();
            this.Hide();
        }

        private void button_home_Click(object sender, EventArgs e)
        {      
            Form f = new TrangChu();
            f.Show();
            this.Hide();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Form f = new DocGia();
            f.Show();
            this.Hide();
        }

        private void button_foradmin_Click(object sender, EventArgs e)
        {
            if (textBox_mactpm.Enabled == false)
            {
                textBox_madg.Enabled = true;
                comboBox_mash.Enabled = true;
                textBox_mactpm.Enabled = true;
            }
            else
            {
                textBox_madg.Enabled = false;
                comboBox_mash.Enabled = false;
                textBox_mactpm.Enabled = false;
            }
        }

        private void button_enale_pm_Click(object sender, EventArgs e)
        {
            if (textBox_mapm.Enabled == false)
            {
                textBox_mapm.Enabled = true;
                comboBox_madg.Enabled = true;
            }
            else
            {
                textBox_mapm.Enabled = false;
                comboBox_madg.Enabled = false;
            }
        }

        private void PhieuMuon_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Hủy việc đóng form
            MessageBox.Show("Bạn Phải Đăng Xuất Mới Có Thể Thoát Được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
