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
    public partial class frmnhacungcap : Form
    {
        public frmnhacungcap()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=QuanLyKho2;Integrated Security=True";
        private void frmnhacungcap_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM dbo.NhaCungCap";
            command.Connection = conn;
            lvnhacungcap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvnhacungcap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvnhacungcap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvnhacungcap.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvnhacungcap.SelectedItems[0];
            txtma.Text = lvi.SubItems[0].Text;
            txtten.Text = lvi.SubItems[1].Text;
            txtdiachi.Text = lvi.SubItems[2].Text;
            txtsdt.Text = lvi.SubItems[3].Text;
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
            command.CommandText = @"INSERT INTO dbo.NhaCungCap
        ( MaNCC, TenNCC, DiaChiNCC, SdtNCC )
VALUES  ( @ma,
          @ten,
          @diachi,
          @sdt
          )";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtma.Text;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtten.Text;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtdiachi.Text;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtsdt.Text;
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
            command.CommandText = @"SELECT * FROM dbo.NhaCungCap";

            command.Connection = conn;
            lvnhacungcap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvnhacungcap.Items.Add(lvi);
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
            command.CommandText = @" UPDATE dbo.NhaCungCap SET MaNCC=@ma,TenNCC=@ten,DiaChiNCC=@diachi,SdtNCC=@sdt WHERE MaNCC=@ma";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtma.Text;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtten.Text;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtdiachi.Text;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtsdt.Text;
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
            command.CommandText = @"SELECT * FROM dbo.NhaCungCap";

            command.Connection = conn;
            lvnhacungcap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvnhacungcap.Items.Add(lvi);
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
            command.CommandText = @"DELETE dbo.NhaCungCap WHERE MaNCC=@ma";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtma.Text;
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
            command.CommandText = @"SELECT * FROM dbo.NhaCungCap";

            command.Connection = conn;
            lvnhacungcap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvnhacungcap.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
