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
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            disable();
        }
       
        public void disable()
        {
            cbgioitinh.Enabled = nbTuoi.Enabled = false;
            txtmakh.Enabled = txttenkh.Enabled = txtsdt.Enabled = txtdiachi.Enabled = txtghichu.Enabled = false;
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = btnHuy.Enabled = false;
            txtmakh.Text = txttenkh.Text = txtsdt.Text = txtdiachi.Text = txtghichu.Text = "";

        }
        public void enable()
        {
            btnLuu.Enabled = btnHuy.Enabled = true;
            cbgioitinh.Enabled = nbTuoi.Enabled = true;
            txttenkh.Enabled = txtsdt.Enabled = txtdiachi.Enabled = txtghichu.Enabled = true;
        }
        public int kiemtra()
        {
            if(txttenkh.Text == "" || txtsdt.Text == "" || txtdiachi.Text == ""||cbgioitinh.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            }else if (nbTuoi.Value < 16 || nbTuoi.Value > 65)
            {
                MessageBox.Show("Tuổi phải trong khoảng [16;65] mới được mượn!","Không đủ tuổi");
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
            if(kiemtra() == 1)
            {
                MessageBox.Show("ok");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            disable();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
