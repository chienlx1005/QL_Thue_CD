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
using BLL;
using DTO;
using DAL;


namespace QL_Thue_CD
{
    public partial class FrmLogin : Form
    {
        
        public FrmLogin()
        {
            InitializeComponent();
        }
        public static string chuoiketnoi = @"Data Source=DESKTOP-6N4MF83\SQLEXPRESS;Initial Catalog=DAPM__QLCD;Integrated Security=True";
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter adapter;
        public static string tentaikhoan = "";

        // xu ly dang nhap
        #region
        public int check()
        {
            string account = txttaikhoan.Text;
            string pass = txtmatkhau.Text;
            if(account == "")
            {
                MessageBox.Show("Không để trống tài khoản!");
                txttaikhoan.Focus();
                return 0;
            }else if(pass == "")
            {
                MessageBox.Show("Không để trống mật khẩu!");
                txtmatkhau.Focus();
                return 0;

            }
            return 1;
        }
        public void login()
        {
            con = new SqlConnection(chuoiketnoi);
            try
            {
                if (txttaikhoan.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo");
                    txttaikhoan.Focus();
                }
                else if (txtmatkhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
                    txtmatkhau.Focus();
                }
                else
                {
                    con.Open();
                    string tk = txttaikhoan.Text;
                    string mk = txtmatkhau.Text;


                    string sql = "select * from dangnhap where taikhoan='" + tk + "' and matkhau ='" + mk + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    /*DataSet dataSet = new DataSet(sql);*/
                    SqlDataReader dta = cmd.ExecuteReader();

                    if (dta.Read() == true)
                    {
                        tentaikhoan = dta["hoten"].ToString();
                        DashBoard db = new DashBoard();
                        db.Show();
                        this.Visible = false;

                        /* MessageBox.Show("");*/
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                        txttaikhoan.Clear();
                        txtmatkhau.Clear();
                        txttaikhoan.Focus();
                    }
                    con.Close();

                    if (chckNhoMK.Checked == true)
                    {
                        Properties.Settings.Default.taikhoan = txttaikhoan.Text;
                        Properties.Settings.Default.matkhau = txtmatkhau.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        /*Properties.Settings.Default.taikhoan;*/
                        Properties.Settings.Default.matkhau = "";

                    }
                    rememberPass();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connecting error");
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
                NguoiDungBLL userBll = new NguoiDungBLL();
                NguoiDung user = new NguoiDung();
                user.Taikhoan = txttaikhoan.Text.Trim();
                user.Matkhau = txtmatkhau.Text.Trim();
                user.Hoten = "";
                if (userBll.dangNhap(user))
                {
                    
                    DashBoard db = new DashBoard();
                    db.Show();
                    this.Visible = false;
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo");
            }
            if (chckNhoMK.Checked == true)
            {
                Properties.Settings.Default.taikhoan = NguoiDungDAL.user1.Taikhoan;
                Properties.Settings.Default.matkhau = NguoiDungDAL.user1.Matkhau;
                Properties.Settings.Default.Save();
            }
            else
            {
                /*Properties.Settings.Default.taikhoan;*/
                Properties.Settings.Default.matkhau = "";

            }
            rememberPass();
                
                
              
                

        }
        public void rememberPass()
        {
            Properties.Settings.Default.savetaikhoan = NguoiDungDAL.user1.Taikhoan;
            Properties.Settings.Default.savematkhau = NguoiDungDAL.user1.Matkhau;
            Properties.Settings.Default.Save();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txttaikhoan.Text = Properties.Settings.Default.taikhoan;
            txtmatkhau.Text = Properties.Settings.Default.matkhau;
            if (Properties.Settings.Default.matkhau != "")
            {
                chckNhoMK.Checked = true;
                
            }
        }

        #endregion

        // xy ly dang ky
        #region
        #endregion
        // xu ly quen mat khau
        #region
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                /*MessageBox.Show("Thoat");*/
                Application.Exit();
            }
            else
            {
               /* MessageBox.Show("khong thoat");*/
            }
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
