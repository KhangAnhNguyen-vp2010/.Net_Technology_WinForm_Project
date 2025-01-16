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
    public partial class FormNhanSu : Form
    {
        SqlConnection cn;
        ketnoi kn = new ketnoi();
        SqlDataAdapter adapter;
        DataTable dt;

        public FormNhanSu()
        {
            InitializeComponent();
            cn = kn.conn;
        }

        private void FormNhanSu_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string sql = "select * from REPORT_NHANSU";
            adapter = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.ReportPath = "ReportNhanSu.rdlc";
            ReportDataSource data = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(data);
            maskedTextBox1.Text = date.ToString();
            label3.Text = dt.Rows.Count.ToString();
            this.reportViewer1.RefreshReport();
        }
    }
}
