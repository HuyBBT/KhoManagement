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
    public partial class Nhapkho : Form
    {
        public Nhapkho()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=QuanLyKho2;Integrated Security=True";
        private void Form3_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select PhieuNhap.Spnhap,PhieuNhap.NgayNhap,PhieuNhap.MaNCC,PhieuNhap.MaNV,HangNhap.MaHang,HangNhap.SoLuong from PhieuNhap,HangNhap where PhieuNhap.SpNhap=HangNhap.SpNhap";
            command.Connection = conn;
            lvphieunhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetString(0));
                lvi.SubItems.Add(reader.GetString(4));
                lvi.SubItems.Add(reader.GetString(3));
                lvi.SubItems.Add(reader.GetString(2));
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvphieunhap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection=conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "EXEC dbo.themsp @spnhap1,@mancc,@manv,@mahang,@sl";
            command.Parameters.Add("@spnhap1", SqlDbType.NVarChar).Value = txtsophieunhap.Text;
            command.Parameters.Add("@mancc", SqlDbType.NVarChar).Value = txtmanhacungcap.Text;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = txtmanhanhvien.Text;
            command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtmahang.Text;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = txtsoluong.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Nhập kho thành công");
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
            command.CommandText = "select PhieuNhap.Spnhap,PhieuNhap.NgayNhap,PhieuNhap.MaNCC,PhieuNhap.MaNV,HangNhap.MaHang,HangNhap.SoLuong from PhieuNhap,HangNhap where PhieuNhap.SpNhap=HangNhap.SpNhap";
            command.Connection = conn;
            lvphieunhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetString(0));
                lvi.SubItems.Add(reader.GetString(4));
                lvi.SubItems.Add(reader.GetString(3));
                lvi.SubItems.Add(reader.GetString(2));
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvphieunhap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void cbnhomhang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvphieunhap.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvphieunhap.SelectedItems[0];
            txtsophieunhap.Text = lvi.SubItems[0].Text;
            txtsoluong.Text = lvi.SubItems[4].Text;
            txtmahang.Text = lvi.SubItems[1].Text;
            txtmanhanhvien.Text = lvi.SubItems[2].Text;
            txtmanhacungcap.Text = lvi.SubItems[3].Text;
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
            command.CommandText = @"EXEC dbo.suanhap @spnhap,
                                    @manhacc,
                                    @manv,
                                    @mahang , 
                                    @soluong";
            command.Parameters.Add("@spnhap", SqlDbType.NVarChar).Value = txtsophieunhap.Text;
            command.Parameters.Add("@manhacc", SqlDbType.NVarChar).Value = txtmanhacungcap.Text;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = txtmanhanhvien.Text;
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
            txtmahang.Clear(); txtmanhacungcap.Clear(); txtmanhanhvien.Clear(); txtsoluong.Clear(); txtsophieunhap.Clear();
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select PhieuNhap.Spnhap,PhieuNhap.NgayNhap,PhieuNhap.MaNCC,PhieuNhap.MaNV,HangNhap.MaHang,HangNhap.SoLuong from PhieuNhap,HangNhap where PhieuNhap.SpNhap=HangNhap.SpNhap";
            command.Connection = conn;
            lvphieunhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetString(0));
                lvi.SubItems.Add(reader.GetString(4));
                lvi.SubItems.Add(reader.GetString(3));
                lvi.SubItems.Add(reader.GetString(2));
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvphieunhap.Items.Add(lvi);
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
            command.CommandText = @"EXEC dbo.xoanhap @spnhap";
            command.Parameters.Add("@spnhap", SqlDbType.NVarChar).Value = txtsophieunhap.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            txtmahang.Clear(); txtmanhacungcap.Clear(); txtmanhanhvien.Clear(); txtsoluong.Clear(); txtsophieunhap.Clear();
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select PhieuNhap.Spnhap,PhieuNhap.NgayNhap,PhieuNhap.MaNCC,PhieuNhap.MaNV,HangNhap.MaHang,HangNhap.SoLuong from PhieuNhap,HangNhap where PhieuNhap.SpNhap=HangNhap.SpNhap";
            command.Connection = conn;
            lvphieunhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetString(0));
                lvi.SubItems.Add(reader.GetString(4));
                lvi.SubItems.Add(reader.GetString(3));
                lvi.SubItems.Add(reader.GetString(2));
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvphieunhap.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
