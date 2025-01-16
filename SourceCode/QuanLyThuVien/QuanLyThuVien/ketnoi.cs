using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class ketnoi
    {
        //public SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-8HLF4UKP\SQLEXPRESS;Initial Catalog=QL_THUVIEN;Integrated Security=True");
        public SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyThuVien"].ConnectionString);
        public bool checkkey(string s)
        {
            SqlCommand cmd = new SqlCommand(s, conn);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
                return false;
            return true;
        }
    }
}
