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
    public partial class FrmDoiMatKhau : Form
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static string chuoiketnoi = @"Data Source=DESKTOP-6N4MF83\SQLEXPRESS;Initial Catalog=DAPM__QLCD;Integrated Security=True";
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
        public void changePass()
        {

            con = new SqlConnection(chuoiketnoi);
            try
            {
                if (txtmatkhaucu.Text == "" || txtmatkhaumoi.Text == "" || txtnhaplaimatkhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ");
                }else if (txtmatkhaucu.Text != Properties.Settings.Default.savematkhau)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác");

                }
                else if (txtmatkhaumoi.Text != txtnhaplaimatkhau.Text)
                {
                    MessageBox.Show("Mật khẩu được nhập lại không khớp!");

                }else
                {
                    con.Open();
                    string tk = Properties.Settings.Default.savetaikhoan;

                    string sql = @"update dangnhap set matkhau = '" + txtmatkhaumoi.Text + "' where taikhoan = '" + tk + "'";

                    cmd = new SqlCommand(sql, con);
                    int x = cmd.ExecuteNonQuery();

                    if (x > 0)
                    {
                        MessageBox.Show("Thay đổi mật khẩu thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }

                    con.Close();
                }

                /* MessageBox.Show("ads");*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect Error!");
            }

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            changePass();
        }
    }
}
