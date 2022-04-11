using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DTO;
using BLL;


namespace QL_Thue_CD
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            disable();
            loadDs();
            
        }
       
        public void disable()
        {
            cbgioitinh.Enabled = nbTuoi.Enabled = false;
            txtmakh.Enabled = txttenkh.Enabled = txtsdt.Enabled = txtdiachi.Enabled = txtghichu.Enabled = false;
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = btnHuy.Enabled = false;
            txtmakh.Text = txttenkh.Text = txtsdt.Text = txtdiachi.Text = txtghichu.Text = "";

        }
        public void enable()
        {
            btnLuu.Enabled = btnHuy.Enabled = true;
            cbgioitinh.Enabled = nbTuoi.Enabled = true;
            txttenkh.Enabled = txtsdt.Enabled = txtdiachi.Enabled = txtghichu.Enabled = true;
            txtmakh.Text = txttenkh.Text = txtsdt.Text = txtdiachi.Text = txtghichu.Text = "";
            nbTuoi.Value = 0;
        }
        public int kiemtra()
        {
            if(txttenkh.Text == "" || txtsdt.Text == "" || txtdiachi.Text == ""||cbgioitinh.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            }else if (nbTuoi.Value < 16 || nbTuoi.Value > 65)
            {
                MessageBox.Show("Tuổi phải trong khoảng [16;65] mới được mượn!","Không đủ tuổi");
                return 0;
            }
            return 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
            int x = dataGridView1.Rows.Count;
            txtmakh.Text = "KH0" + (x + 1).ToString() + "";
            btnSua.Enabled = false;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(kiemtra() == 1)
            {
                QuanLyKHBLL qlkh = new QuanLyKHBLL();
                string makh = txtmakh.Text.Trim();
                string tenkh = txttenkh.Text.Trim();
                string gioitinh = cbgioitinh.Text.Trim();
                int tuoi = int.Parse(nbTuoi.Value.ToString());
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdiachi.Text.Trim();
                string ghichu = txtghichu.Text.Trim();
                KhachHang kh = new KhachHang();
                kh.MaKh = makh;
                kh.TenKh = tenkh;
                kh.GioiTinh = gioitinh;
                kh.Tuoi = tuoi;
                kh.Sdt = sdt;
                kh.DiaChi = diachi;
                kh.GhiChu = ghichu;

                if (qlkh.themKh(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                    loadDs();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng không thành công!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
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

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Xuất Excel";
                saveFileDialog.Filter = "Excel (*.xlsx)| *.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToExcel(saveFileDialog.FileName);
                        
                        MessageBox.Show("Xuất ra excel thành công", "Thông báo");
                        return;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất không thành công! \n" + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để export! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            
            
        }
        public void ExportToExcel(string path)
        {
            Excel.Application application = new Excel.Application();

            application.Application.Workbooks.Add(Type.Missing);
            application.Cells[1, 5] = "Danh sách khách hàng";
            


            // tao header 
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                application.Cells[3, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            // export content
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    application.Cells[i + 4, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            // tu dong gian dong`
            application.Columns.AutoFit();
            // chon duong dan path
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Visible = true;

        }
      

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadDs();
            txttimkiem.Text = "";
        }

        public void loadDs()
        {
            disable();
            QuanLyKHBLL qlkh = new QuanLyKHBLL();
            dataGridView1.DataSource = qlkh.layDSKH();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enable();
            dataGridView1.CurrentRow.Selected = true;
            int i = dataGridView1.CurrentRow.Index;
            txtmakh.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txttenkh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbgioitinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            nbTuoi.Value = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            txtsdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtdiachi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtghichu.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(kiemtra() == 1)
            {
                QuanLyKHBLL qlkh = new QuanLyKHBLL();
                string makh = txtmakh.Text.Trim();
                string tenkh = txttenkh.Text.Trim();
                string gioitinh = cbgioitinh.Text.Trim();
                int tuoi = int.Parse(nbTuoi.Value.ToString());
                string sdt = txtsdt.Text.Trim();
                string diachi = txtdiachi.Text.Trim();
                string ghichu = txtghichu.Text.Trim();
                KhachHang kh = new KhachHang();
                kh.MaKh = makh;
                kh.TenKh = tenkh;
                kh.GioiTinh = gioitinh;
                kh.Tuoi = tuoi;
                kh.Sdt = sdt;
                kh.DiaChi = diachi;
                kh.GhiChu = ghichu;
                if (qlkh.suaKh(kh))
                {
                    MessageBox.Show("Sửa thông tin thành công!", "Thông báo");
                    loadDs();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            QuanLyKHBLL qlkh = new QuanLyKHBLL();
            string text = txttimkiem.Text.Trim();
            if (radmakh.Checked)
            {
                dataGridView1.DataSource = qlkh.timKiemTheoMaKh(text);
            }
            if (radtenkh.Checked)
            {
                dataGridView1.DataSource = qlkh.timKiemTheoTenKh(text);
            }
        }
    }
}
