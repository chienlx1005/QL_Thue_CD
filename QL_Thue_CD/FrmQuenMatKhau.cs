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
    public partial class FrmQuenMatKhau : Form
    {
        public FrmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            HopDongBLL qlhd = new HopDongBLL();
            NguoiDungBLL userbll = new NguoiDungBLL();
            NguoiDung user = new NguoiDung();

            user.Taikhoan = txttaikhoan.Text.Trim();
            user.Matkhau = txtmatkhau2.Text.Trim();
            user.Hoten = "";

            string mahd = txtmahd.Text.Trim();
            if(check() == 1)
            {
                if (qlhd.kiemTraHd(mahd))
                {
                    if (userbll.doiMatKhau(user))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu không thành công! \n Kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã hợp đồng không hợp lệ! \n Kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        public int check()
        {
            if(txtmahd.Text ==""|| txttaikhoan.Text ==""||txtmatkhau.Text ==""||txtmatkhau2.Text == "")
            {
                MessageBox.Show("Không để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;

            }
            if(txtmatkhau.Text  != txtmatkhau2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            return 1;
        }
    }
}
