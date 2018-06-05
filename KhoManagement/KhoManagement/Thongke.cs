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
            command.CommandText = @"SELECT dbo.HangHoa.MaHang AS 'Mã hàng',dbo.HangHoa.TenHang AS 'Tên hàng',SUM(SoLuong) AS 'Số lượng',HangHoa.DonVi AS 'Đơn vị'
                                    FROM dbo.HangNhap,dbo.HangHoa
                                    WHERE dbo.HangNhap.MaHang=dbo.HangHoa.MaHang 
                                    GROUP BY HangHoa.MaHang,dbo.HangHoa.TenHang,dbo.HangHoa.DonVi";
            command.Connection = conn;
            Lvthongke.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetString(0));
                lvi.SubItems.Add(reader.GetString(1));
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader.GetString(3));
                Lvthongke.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
