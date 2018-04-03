using KhoManagement.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoManagement
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
            LoadTaiKhoan();
            AddTaiKhoanBinding();
        }

        void LoadTaiKhoan()
        {
            string query = "SELECT * FROM dbo.NhanVien";
            dtgvTaiKhoan.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }
        void AddTaiKhoanBinding()
        {
            txtTenNV.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "HoTen"));
            txtMaNV.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "MaNV"));
            txtTaiKhoan.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "TaiKhoan"));
            txtMatKHau.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "MatKhau"));
            txtSDT.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "Sdt"));
            txtGioiTinh.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "GioiTinh"));
        }
        void ThemTaiKhoan(string TaiKhoan,string MatKhau,string MaNV,string Hoten,string GioiTinh,string SDT)
        {
            if(TaiKhoanDAO.instance.ThemTaiKhoan(TaiKhoan, MatKhau, MaNV, Hoten,GioiTinh,SDT))
            {
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại");
            }
                
        }
        void XoaNV(string MaNV)
        {
           
            if (TaiKhoanDAO.instance.XoaTaiKhoan(MaNV))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadTaiKhoan();
        }
        
        void SuaTaiKhoan(string TaiKhoan, string MatKhau, string MaNV, string HoTen, string GioiTinh, string SDT)
        {

            if (TaiKhoanDAO.instance.SuaTaiKhoan(TaiKhoan, MatKhau, MaNV, HoTen, GioiTinh, SDT))
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }

            LoadTaiKhoan();
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;

            XoaNV(MaNV);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaiKhoan.Text;
            string MatKHau = txtMatKHau.Text;
            string MaNV = txtMaNV.Text;
            string HoTen = txtTenNV.Text;
            string GioiTinh = txtGioiTinh.Text;
            string SDT = txtSDT.Text;
            ThemTaiKhoan(TaiKhoan,MatKHau,MaNV,HoTen,GioiTinh,SDT);
            LoadTaiKhoan();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaiKhoan.Text;
            string MatKHau = txtMatKHau.Text;
            string MaNV = txtMaNV.Text;
            string HoTen = txtTenNV.Text;
            string GioiTinh = txtGioiTinh.Text;
            string SDT = txtSDT.Text;
            SuaTaiKhoan(TaiKhoan, MatKHau, MaNV, HoTen, GioiTinh, SDT);
            LoadTaiKhoan();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
