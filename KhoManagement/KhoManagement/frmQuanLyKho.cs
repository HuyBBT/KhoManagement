using Quanlykho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoManagement
{
    public partial class frmQuanLyKho : Form
    {
        public frmQuanLyKho()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region method

        #endregion

        #region event
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongke f = new Thongke();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHuongDan f = new frmHuongDan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhapkho f = new Nhapkho();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHanghoa f = new frmHanghoa();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmnhacungcap f = new frmnhacungcap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmxuatkho f = new Frmxuatkho();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
