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

namespace QL_Thue_CD
{
    public partial class FrmDoiMatKhau : Form
    {
       
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
       

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if(check() == 1)
            {
                NguoiDungBLL userbll = new NguoiDungBLL();

                NguoiDung user = new NguoiDung();
                string taikhoan = Properties.Settings.Default.taikhoan;
                string matkhaumoi = txtnhaplaimatkhau.Text.Trim();
                string hoten = "";
                user.Taikhoan = taikhoan;
                user.Matkhau = matkhaumoi;
                user.Hoten = hoten;

                if (userbll.doiMatKhau(user))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu không thành công!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
        }
        public int check()
        {
            if (txtmatkhaucu.Text == "" || txtmatkhaumoi.Text == "" || txtnhaplaimatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ");
                return 0;
            }
            else if (txtmatkhaucu.Text != Properties.Settings.Default.savematkhau)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác");
                return 0;

            }
            else if (txtmatkhaumoi.Text.Trim() != txtnhaplaimatkhau.Text.Trim())
            {
                MessageBox.Show("Mật khẩu được nhập lại không khớp!");
                return 0;

            }
            return 1;
        }
    }
}
