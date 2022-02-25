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
            cbmanph.Enabled = false;
            cbtinhtrang.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
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
            cbmanph.Enabled = false;
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
            cbmanph.Enabled = true;
            cbtinhtrang.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        public void kiemtra()
        {
            if(txttencd.Text == "" || txttencasi.Text == "" || txtnamph.Text == "" || txttheloai.Text == ""|| txtsoluongnhap.Text == "" || txtgiamuon.Text == "" || txtgianhap.Text == "")
            {
                MessageBox.Show("Không để trống!");
            }
        }
        public void checkSo()
        {
            int num = 0;

            if (Int32.TryParse(txtsoluongnhap.Text, out num))
            {

            }
            else
                MessageBox.Show("Vui lòng nhập số !", "Thông báo");
        }
        // code xu ly su kien 
        public void themCD()
        {
            con = new SqlConnection(chuoiketnoi);
            try
            {
                string sql = @"insert into ";
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
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
            kiemtra();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void txtsoluongnhap_TextChanged(object sender, EventArgs e)
        {
            checkSo();
           /* txtsoluongnhap.Focus();*/
        }

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            checkSo();
            /*txtgianhap.Focus();*/
        }

        private void txtgiamuon_TextChanged(object sender, EventArgs e)
        {
            checkSo();
           /* txtgiamuon.Focus();*//**/
        }
    }
}
