using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoManagement.DAO
{
    class TaiKhoanDAO
    {

        private static TaiKhoanDAO Instance;

        public static TaiKhoanDAO instance
        {
            get
            {
                if (Instance == null) Instance = new TaiKhoanDAO();
                return Instance;
            }

            private set
            {
                Instance = value;
            }
        }
        private TaiKhoanDAO() { }

        public bool Login(string TaiKhoan, string MatKhau)
        {
            string query = "USP_TaiKhoan @TaiKhoan , @MatKhau";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { TaiKhoan, MatKhau });
            return result.Rows.Count > 0;
        }

        public bool ThemTaiKhoan(string TaiKhoan, string MatKhau, string MaNV, string HoTen, string GioiTinh,string SDT)
        {
            string query = "USP_ThemTaiKhoan @TaiKhoan , @MatKhau , @MaNV , @HoTen , @GioiTinh , @Sdt";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {TaiKhoan,MatKhau,MaNV,HoTen,GioiTinh,SDT});
            return result > 0;
        }
        public bool XoaTaiKhoan(string MaNV)
        {
            string query = string.Format("Delete NhanVien where MaNV = N'{0}'", MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool SuaTaiKhoan(string TaiKhoan, string MatKhau, string MaNV, string HoTen, string GioiTinh, string SDT)
        {
            string query = string.Format("UPDATE NhanVien SET TaiKhoan = N'{0}', MatKhau = N'{1}', HoTen = N'{3}', GioiTinh = N'{4}', Sdt = N'{5}' where  MaNV = N'{2}'", TaiKhoan,MatKhau,MaNV,HoTen,GioiTinh,SDT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
