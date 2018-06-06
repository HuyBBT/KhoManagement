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

namespace Quanlykho
{
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=QuanLyKho2;Integrated Security=True";
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"select TKN.MaHang,TKN.TenHang, TKN.TN - coalesce(TKX.TX,0) 
                                    FROM (select dbo.HangNhap.MaHang,dbo.HangHoa.TenHang, sum(dbo.HangNhap.SoLuong) as TN from dbo.HangNhap,dbo.HangHoa WHERE dbo.HangNhap.MaHang=dbo.HangHoa.MaHang GROUP BY dbo.HangNhap.MaHang,dbo.HangHoa.TenHang) as TKN
                                    left join (select dbo.HangXuat.MaHang, sum(dbo.HangXuat.SoLuong) as TX from dbo.HangXuat GROUP BY dbo.HangXuat.MaHang) AS TKX on TKN.MaHang = TKX.MaHang";

            command.Connection = conn;
            Lvthongke.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                Lvthongke.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
