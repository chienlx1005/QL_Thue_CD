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
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
                NguoiDungBLL userBll = new NguoiDungBLL();
                NguoiDung user = new NguoiDung();
                user.Taikhoan = txttaikhoan.Text.Trim();
                user.Matkhau = txtmatkhau.Text.Trim();
                user.Hoten = "";
                user.Mahd = "";
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

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy frmDangKy = new FrmDangKy();
            frmDangKy.ShowDialog();
        }

        private void lbQuenMk_Click(object sender, EventArgs e)
        {
            FrmQuenMatKhau qmk = new FrmQuenMatKhau();
            qmk.ShowDialog();

        }
    }
}
