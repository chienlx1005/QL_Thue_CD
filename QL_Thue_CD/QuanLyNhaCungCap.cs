using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

//khai bao thu vien excel 
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace QL_Thue_CD
{
    public partial class QuanLyNhaCungCap : Form
    {
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void QuanLyNhaPhatHanh_Load(object sender, EventArgs e)
        {
            disable();
            load();
        }
        public void load()
        {
            QuanLyNccBLL qlncc = new QuanLyNccBLL();
            List<NhaCungCap> listncc = new List<NhaCungCap>();
            listncc = qlncc.getDSNcc();
            dataGridView1.DataSource = listncc;
        }
        
        public void disable()
        {
            
            txtmancc.Enabled = false;
            txttenncc.Enabled = false;
            txtsdt.Enabled = false;
            txtemail.Enabled = false;
            txtdiachi.Enabled = false;
            txtghichu.Enabled = false;
            cbtrangthai.Enabled = false;
            btnHuy.Enabled = btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;

            txtmancc.Text = "";
            txttenncc.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";
            txtghichu.Text = "";
        }
        public void enable()
        {
            txttenncc.Enabled = true;
            txtsdt.Enabled = true;
            txtemail.Enabled = true;
            txtdiachi.Enabled = true;
            txtghichu.Enabled = true;
            cbtrangthai.Enabled = true;
            btnHuy.Enabled = btnLuu.Enabled = true;
            btnSua.Enabled = false;
           

        }
        public void them()
        {
            txtmancc.Text = "";
            txttenncc.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";
            txtghichu.Text = "";
        }
       
        public int kiemtra()
        {
            if(txttenncc.Text == "" || txtsdt.Text == ""|| txtemail.Text == "" || txtdiachi.Text =="" || cbtrangthai.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            }
            return 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
            them();
            int x = dataGridView1.Rows.Count;
            txtmancc.Text = "NCC0" + (x + 1).ToString() + "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemtra() == 1)
            {
                QuanLyNccBLL qlncc = new QuanLyNccBLL();
                NhaCungCap ncc = new NhaCungCap();
                string mancc = txtmancc.Text.Trim();
                string tenncc = txttenncc.Text.Trim();
                string email = txtemail.Text.Trim();
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdiachi.Text.Trim();
                string trangthai = cbtrangthai.Text.Trim();
                string ghichu = txtghichu.Text.Trim();

                ncc.MaNcc = mancc;
                ncc.TenNcc = tenncc;
                ncc.Email = email;
                ncc.Sdt = sdt;
                ncc.DiaChi = diachi;
                ncc.TrangThai = trangthai;
                ncc.GhiChu = ghichu;

                if (qlncc.addNcc(ncc))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại!", "Thông báo");
                }
                load();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            disable();
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            disable();
            txttimkiem.Text = "";
            QuanLyNccBLL qlncc = new QuanLyNccBLL();
            List<NhaCungCap> listncc = new List<NhaCungCap>();
            listncc = qlncc.getDSNcc();
            dataGridView1.DataSource = listncc;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            dataGridView1.CurrentRow.Selected = true;
            txtmancc.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txttenncc.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtemail.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtsdt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtdiachi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cbtrangthai.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtghichu.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();

            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = true;
            txttenncc.Enabled = true;
            txtsdt.Enabled = true;
            txtemail.Enabled = true;
            txtdiachi.Enabled = true;
            txtghichu.Enabled = true;
            cbtrangthai.Enabled = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QuanLyNccBLL qlncc = new QuanLyNccBLL();
            NhaCungCap ncc = new NhaCungCap();
            string mancc = txtmancc.Text.Trim();
            string tenncc = txttenncc.Text.Trim();
            string email = txtemail.Text.Trim();
            string sdt = txtsdt.Text.Trim();
            string diachi = txtdiachi.Text.Trim();
            string trangthai = cbtrangthai.Text.Trim();
            string ghichu = txtghichu.Text.Trim();

            ncc.MaNcc = mancc;
            ncc.TenNcc = tenncc;
            ncc.Email = email;
            ncc.Sdt = sdt;
            ncc.DiaChi = diachi;
            ncc.TrangThai = trangthai;
            ncc.GhiChu = ghichu;

            if (qlncc.editNcc(ncc))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo");

            }
            else
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            load();
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            QuanLyNccBLL qlncc = new QuanLyNccBLL();
            string text = txttimkiem.Text.Trim();
            
            if (radMa.Checked)
            {
                dataGridView1.DataSource = qlncc.timKiemTheoMaNcc(text);
                
            }
            if(radTen.Checked)
            {
                dataGridView1.DataSource = qlncc.timKiemTheoTenNcc(text);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)| *.xlsx";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất ra excel thành công");

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xuất không thành công! \n" + ex.Message);
                }
            }
        }
        public void ExportToExcel(string path)
        {
            Excel.Application application = new Excel.Application();

            application.Application.Workbooks.Add(Type.Missing);

            // tao header 
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            // export content
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for( int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            // tu dong gian dong`
            application.Columns.AutoFit();
            // chon duong dan path
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            
        }
    }
}
