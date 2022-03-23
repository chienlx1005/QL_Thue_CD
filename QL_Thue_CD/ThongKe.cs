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
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            txtslCD.Enabled = false;
            txtslkhachhang.Enabled = false;
            txtslncc.Enabled = false;
            txtsoluongcon.Enabled = false;
            txtsoluongmuon.Enabled = false;
            txttonggiatri.Enabled = false;
            load();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void load()
        {
            // thong ke so luong khach hang va ncc
            QuanLyKHBLL qlkh = new QuanLyKHBLL();
            QuanLyNccBLL qlncc = new QuanLyNccBLL();

            txtslkhachhang.Text = qlkh.layDSKH().Count.ToString() + " khách hàng";
            txtslncc.Text = qlncc.getDSNcc().Count.ToString() +" nhà cung cấp";
        }
    }
}
