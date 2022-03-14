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

namespace QL_Thue_CD
{
    public partial class QuanLyCD : Form
    {
        public QuanLyCD()
        {
            InitializeComponent();
        }
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static string chuoiketnoi = @"Data Source=DESKTOP-6N4MF83\SQLEXPRESS;Initial Catalog=DAPM__QLCD;Integrated Security=True";
        public static SqlDataAdapter adapter;

        private void QuanLyCD_Load(object sender, EventArgs e)
        {
            disable();
        }

        //code kiem tra,reset
        public void disable()
        {
            txttennph.Enabled = false;
            txttheloai.Enabled = false;
            txttencd.Enabled = false;
            txttencasi.Enabled = false;
            txtsoluongnhap.Enabled = false;
            txtnamph.Enabled = false;
            txtmacd.Enabled = false;
            txtgianhap.Enabled = false;
            txtgiamuon.Enabled = false;
            txtghichu.Enabled = false;
            cbmancc.Enabled = false;
            cbtinhtrang.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }
        public void enable()
        {
            txttennph.Enabled = false;
            txttheloai.Enabled = true;
            txttencd.Enabled = true;
            txttencasi.Enabled = true;
            txtsoluongnhap.Enabled = true;
            txtnamph.Enabled = true;
            txtmacd.Enabled = false;
            txtgianhap.Enabled = true;
            txtgiamuon.Enabled = true;
            txtghichu.Enabled = true;
            cbmancc.Enabled = true;
            cbtinhtrang.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        public int kiemtra()
        {
            /*string macd = txtmacd.Text;
            string tencd = txttencd.Text;
            string tencasi = txttencasi.Text;
            string mancc = cbmancc.Text;
            string namph = txtnamph.Text;
            string theloai = txttheloai.Text;
            int slnhap = int.Parse(txtsoluongnhap.Text);
            int gianhap = int.Parse(txtgianhap.Text);
            int giamuon = int.Parse(txtgiamuon.Text);
            string tinhtrang = cbtinhtrang.Text;
            string ghichu = txtghichu.Text;*/

            if (txttencd.Text == "" || txttencasi.Text == "" || cbmancc.Text == "" || txtnamph.Text == "" || txttheloai.Text == "" || cbtinhtrang.Text == "" ||txtsoluongnhap.Text == "" || txtgiamuon.Text == "" || txtgianhap.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            } else if (checkSo(txtsoluongnhap.Text) != 1 || checkSo(txtgianhap.Text) != 1 || checkSo(txtgiamuon.Text) != 1)
            {
                MessageBox.Show("3 trường sl Nhập & Giá Nhập & Giá mượn phải là số");
                return 0;
            } else if (int.Parse(txtsoluongnhap.Text) <= 0 || int.Parse(txtsoluongnhap.Text) > 9999 || int.Parse(txtgianhap.Text) <0 || int.Parse(txtgiamuon.Text) <0 )
            {
                MessageBox.Show("sl Nhập trong khoảng [1;9999] và giá nhập, giá mượn phải > 0");
                return 0;
            }
            return 1;
        }
        public int checkSo(string a )
        {
            int num = 0;
            
            if (Int32.TryParse(a, out num))
            {
                return 1;
            }
            else
            {
                return 0;
            }
               
        }
        // code xu ly su kien 
        public void themCD()
        {
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemtra() == 1)
            {
                MessageBox.Show("Them moi thanh cong!");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            disable();
        }

    }
}
