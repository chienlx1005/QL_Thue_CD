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
    public partial class QuanLyMuonTra : Form
    {
        public QuanLyMuonTra()
        {
            InitializeComponent();
        }

        private void QuanLyMuonTra_Load(object sender, EventArgs e)
        {
            disable();
        }
        public void disable()
        {
            txtmacd1.Enabled = txtmaphieu1.Enabled = txtmakh1.Enabled = txtslmuon1.Enabled = txtthanhtien1.Enabled = false;
            dtNgayMuon1.Enabled = dtNgayTra1.Enabled = false;
            txtghichu1.Enabled = cbtinhtrang1.Enabled = false;
            txtmacd.Enabled = txttencd.Enabled = txtsoluongcon.Enabled = txttheloai.Enabled = txtgiamuon.Enabled = false;
            txtmaphieu.Enabled = cbmakh.Enabled = cbmacd.Enabled = txtslmuon.Enabled = txtthanhtien.Enabled = false;
            dtNgayMuon.Enabled = dtNgayTra.Enabled = false;
            cbtinhtrang.Enabled = txtghichu.Enabled = false;
            btnHuy.Enabled = btnChomuon.Enabled = btnInphieumuon.Enabled = false;
            btnTradia.Enabled = false;
        }
        public void enable()
        {
            cbmakh.Enabled = cbmacd.Enabled = txtslmuon.Enabled =  true;
            dtNgayMuon.Enabled = dtNgayTra.Enabled = true;
            cbtinhtrang.Enabled = txtghichu.Enabled = true;
            btnHuy.Enabled = btnChomuon.Enabled = true;

        }
        public int kiemtra()
        {
            if(cbmakh.Text == "" || cbmacd.Text == "" || txtslmuon.Text == "" || cbtinhtrang.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            }else if(int.Parse(txtslmuon.Text) <= 0 || int.Parse(txtslmuon.Text) > int.Parse(txtsoluongcon.Text))
            {
                MessageBox.Show("Số lượng mượn phải trong khoảng [1;x]. Trong đó x là: số cd còn lại trong kho!");
                return 0;
            }
            return 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
            
        }

        private void btnChomuon_Click(object sender, EventArgs e)
        {
            txtsoluongcon.Text = "3";
            if(kiemtra() == 1)
            {
                MessageBox.Show("ok");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            disable();
        }
    }
}
