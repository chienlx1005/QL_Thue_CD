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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(kiemtra() == 1)
            {
                MessageBox.Show("ok");
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

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất không thành công! \n" + ex.Message);
                    }
                }
            }
            {
                MessageBox.Show("Không có dữ liệu để export! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExportToExcel(string path)
        {
            Excel.Application application = new Excel.Application();

            application.Application.Workbooks.Add(Type.Missing);

            // tao header 
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            // export content
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            // tu dong gian dong`
            application.Columns.AutoFit();
            // chon duong dan path
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Visible = true;

        }
    }
}
