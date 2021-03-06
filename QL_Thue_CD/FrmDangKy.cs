using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace QL_Thue_CD
{
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            HopDongBLL qlhd = new HopDongBLL();
            NguoiDung user = new NguoiDung();
            NguoiDungBLL userdal = new NguoiDungBLL();

            string mahd = txtmahd.Text.Trim();
            string taikhoan = txttaikhoan.Text.Trim();
            string matkhau = txtmatkhau.Text.Trim();
            string hoten = txthoten.Text.Trim();
            string nhaplaimk = txtmatkhau2.Text.Trim();
            user.Mahd = mahd;
            user.Taikhoan = taikhoan;
            user.Matkhau = matkhau;
            user.Hoten = hoten;
            if(check() == 1)
            {
                if (qlhd.kiemTraHd(mahd))
                {
                    if (userdal.dangKyNguoiDung(user, nhaplaimk))
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Hợp đồng này không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public int check()
        {
            if(txtmahd.Text == "" || txttaikhoan.Text == ""|| txtmatkhau.Text == "" || txtmatkhau2.Text =="")
            {
                MessageBox.Show("Không để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            if(txtmatkhau.Text != txtmatkhau2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            return 1;
        }
    }
}
