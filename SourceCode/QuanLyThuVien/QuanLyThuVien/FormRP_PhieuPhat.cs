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
using Microsoft.Reporting.WinForms;

namespace QuanLyThuVien
{
    public partial class FormRP_PhieuPhat : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;

        public FormRP_PhieuPhat()
        {
            InitializeComponent();
            cn = kn.conn;
        }

        private void FormRP_PhieuPhat_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string sql = "select * from REPORT_PHIEUPHAT";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.ReportPath = "ReportPhieuPhat.rdlc";
            ReportDataSource data = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(data);
            maskedTextBox1.Text = date.ToString("yyyy-MM-dd");
            label3.Text = dt.Rows.Count.ToString();
            try
            {
                decimal tongTien = Convert.ToDecimal(dt.Compute("SUM(TIENPHAT)", string.Empty));
                label5.Text = tongTien.ToString() + "Đồng";
            }
            catch (Exception)
            {
                label5.Text = "0 Đồng";
            }       
            this.reportViewer1.RefreshReport();
        }
    }
}
