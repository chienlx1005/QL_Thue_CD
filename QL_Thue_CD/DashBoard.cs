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
    public partial class DashBoard : Form
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter adapter;
        public static string chuoiketnoi = @"Data Source=DESKTOP-6N4MF83\SQLEXPRESS;Initial Catalog=DAPM__QLCD;Integrated Security=True";
        public DashBoard()
        {
            InitializeComponent();
        }

        
        public void load()
        {
            con = new SqlConnection(chuoiketnoi);
            string tennguoisudung = "Xin chào! " +FrmLogin.tentaikhoan;
            lbten.Text = tennguoisudung;
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            load();
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
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

        private void đổiMậtKhẩuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmDoiMatKhau frmDoiMatKhau = new FrmDoiMatKhau();
            frmDoiMatKhau.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ActiveForm.Close();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

        }
        private void quảnLýĐĩaCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCD qlCD = new QuanLyCD();
            qlCD.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang qlkh = new QuanLyKhachHang();
            qlkh.ShowDialog();
        }

        private void quảnLýMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhaPhatHanh qlnph = new QuanLyNhaPhatHanh();
            qlnph.ShowDialog();
        }

        private void quảnLýMượnTrảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLyMuonTra qlmt = new QuanLyMuonTra();
            qlmt.ShowDialog();
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.ShowDialog();
        }
    }
}
