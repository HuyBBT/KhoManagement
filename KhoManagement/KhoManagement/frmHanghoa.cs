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

namespace KhoManagement
{
    public partial class frmHanghoa : Form
    {
        public frmHanghoa()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=QuanLyKho2;Integrated Security=True";
        private void frmHanghoa_Load(object sender, EventArgs e)
        {
            
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM dbo.HangHoa";

            command.Connection = conn;
            lvhanghoa.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvhanghoa.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvhanghoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvhanghoa.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvhanghoa.SelectedItems[0];
            txtmahang.Text = lvi.SubItems[0].Text;
            txttenhang.Text = lvi.SubItems[1].Text;
            txtmota.Text = lvi.SubItems[2].Text;
            txtdonvi.Text = lvi.SubItems[3].Text;
            txtmanhom.Text = lvi.SubItems[4].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO dbo.HangHoa
        ( MaHang ,
          TenHang ,
          MoTaHangHoa ,
          DonVi ,
          MaNhom
        )
VALUES  ( @mahang ,
          @tenhang ,
          @mota ,
          @donvi ,
          @manhom
        )";
            command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtmahang.Text;
            command.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = txttenhang.Text;
            command.Parameters.Add("@mota", SqlDbType.NVarChar).Value = txtmota.Text;
            command.Parameters.Add("@donvi", SqlDbType.NVarChar).Value = txtdonvi.Text;
            command.Parameters.Add("@manhom", SqlDbType.Int).Value = txtmanhom.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Nhập thành công");
            }
            else
            {
                MessageBox.Show("Nhập thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM dbo.HangHoa";

            command.Connection = conn;
            lvhanghoa.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvhanghoa.Items.Add(lvi);
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"UPDATE dbo.HangHoa SET MaHang=@mahang,TenHang=@tenhang,MoTaHangHoa=@mota,DonVi=@donvi,MaNhom=@manhom WHERE MaHang=@mahang";
            command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtmahang.Text;
            command.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = txttenhang.Text;
            command.Parameters.Add("@mota", SqlDbType.NVarChar).Value = txtmota.Text;
            command.Parameters.Add("@donvi", SqlDbType.NVarChar).Value = txtdonvi.Text;
            command.Parameters.Add("@manhom", SqlDbType.Int).Value = txtmanhom.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM dbo.HangHoa";

            command.Connection = conn;
            lvhanghoa.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvhanghoa.Items.Add(lvi);
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"DELETE dbo.HangHoa WHERE MaHang=@mahang";
            command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtmahang.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM dbo.HangHoa";

            command.Connection = conn;
            lvhanghoa.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvhanghoa.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
