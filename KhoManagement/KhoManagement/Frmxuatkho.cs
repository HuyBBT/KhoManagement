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
    public partial class Frmxuatkho : Form
    {
        public Frmxuatkho()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=QuanLyKho2;Integrated Security=True";
        private void Frmxuatkho_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.HangXuat.SpXuat,dbo.HangXuat.MaHang,dbo.HangXuat.SoLuong,dbo.PhieuXuat.NgayXuat,dbo.PhieuXuat.MaNV FROM dbo.HangXuat,dbo.PhieuXuat WHERE dbo.HangXuat.SpXuat=dbo.PhieuXuat.SpXuat";
            command.Connection = conn;
            lvxuat.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvxuat.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvxuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvxuat.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvxuat.SelectedItems[0];
            txtphieuxuat.Text = lvi.SubItems[0].Text;
            dtxuat.Text = lvi.SubItems[3].Text;
            txtmahang.Text = lvi.SubItems[1].Text;
            txtmanv.Text = lvi.SubItems[4].Text;
            txtsoluong.Text = lvi.SubItems[2].Text;
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
            command.CommandText = @"EXEC dbo.xuat1 @spxuat,
                                   @date,
                                   @manv,
                                   @mahang,
                                   @soluong";
            command.Parameters.Add("@spxuat", SqlDbType.NVarChar).Value = txtphieuxuat.Text;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = txtmanv.Text;
            command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtmahang.Text;
            command.Parameters.Add("@date", SqlDbType.Date).Value = dtxuat.Text;
            command.Parameters.Add("@soluong", SqlDbType.Int).Value = txtsoluong.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Xuất kho thành công");
            }
            else
            {
                MessageBox.Show("Xuất thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.HangXuat.SpXuat,dbo.HangXuat.MaHang,dbo.HangXuat.SoLuong,dbo.PhieuXuat.NgayXuat,dbo.PhieuXuat.MaNV FROM dbo.HangXuat,dbo.PhieuXuat WHERE dbo.HangXuat.SpXuat=dbo.PhieuXuat.SpXuat";
            command.Connection = conn;
            lvxuat.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvxuat.Items.Add(lvi);
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
            command.CommandText = @"EXEC dbo.suaxuat @spxuat,
                                   @date,
                                   @manv,
                                   @mahang,
                                   @soluong";
            command.Parameters.Add("@spxuat", SqlDbType.NVarChar).Value = txtphieuxuat.Text;
            command.Parameters.Add("@date", SqlDbType.Date).Value = dtxuat.Text;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = txtmanv.Text;
            command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtmahang.Text;
            command.Parameters.Add("@soluong", SqlDbType.Int).Value = txtsoluong.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            txtmahang.Clear(); txtmanv.Clear(); txtsoluong.Clear(); txtmahang.Clear(); txtphieuxuat.Clear();
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.HangXuat.SpXuat,dbo.HangXuat.MaHang,dbo.HangXuat.SoLuong,dbo.PhieuXuat.NgayXuat,dbo.PhieuXuat.MaNV FROM dbo.HangXuat,dbo.PhieuXuat WHERE dbo.HangXuat.SpXuat=dbo.PhieuXuat.SpXuat";
            command.Connection = conn;
            lvxuat.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvxuat.Items.Add(lvi);
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
            command.CommandText = @"EXEC dbo.xoaxuat @spxuat";
            command.Parameters.Add("@spxuat", SqlDbType.NVarChar).Value = txtphieuxuat.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            txtmahang.Clear(); txtphieuxuat.Clear(); txtmanv.Clear(); txtsoluong.Clear();
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.HangXuat.SpXuat,dbo.HangXuat.MaHang,dbo.HangXuat.SoLuong,dbo.PhieuXuat.NgayXuat,dbo.PhieuXuat.MaNV FROM dbo.HangXuat,dbo.PhieuXuat WHERE dbo.HangXuat.SpXuat=dbo.PhieuXuat.SpXuat";
            command.Connection = conn;
            lvxuat.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvxuat.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
