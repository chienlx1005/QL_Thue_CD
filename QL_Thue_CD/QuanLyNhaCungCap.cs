using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Thue_CD
{
    public partial class QuanLyNhaCungCap : Form
    {
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void QuanLyNhaPhatHanh_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            txtmanph.Enabled = false;
            txttennph.Enabled = false;
            txtsdt.Enabled = false;
            txtemail.Enabled = false;
            txtdiachi.Enabled = false;
            txtghichu.Enabled = false;
            cbtrangthai.Enabled = false;
            btnHuy.Enabled = btnLuu.Enabled = btnSua.Enabled =btnXoa.Enabled= false;
        }
        public void enable()
        {
            txttennph.Enabled = true;
            txtsdt.Enabled = true;
            txtemail.Enabled = true;
            txtdiachi.Enabled = true;
            txtghichu.Enabled = true;
            cbtrangthai.Enabled = true;
            btnHuy.Enabled = btnLuu.Enabled = true;
        }
       
        public int kiemtra()
        {
            if(txttennph.Text == "" || txtsdt.Text == ""|| txtemail.Text == "" || txtdiachi.Text =="" || cbtrangthai.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            }
            return 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemtra() == 1)
            {
                MessageBox.Show("ok");
            }
        }
    }
}
