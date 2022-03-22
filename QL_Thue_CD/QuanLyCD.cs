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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using BLL;
using DTO;

namespace QL_Thue_CD
{
    public partial class QuanLyCD : Form
    {
       

       

        public QuanLyCD()
        {
            InitializeComponent();
        }
        

        private void QuanLyCD_Load(object sender, EventArgs e)
        {
            disable();
            loadDS();
            getCBMNCC();

        }

        //code kiem tra,reset
        
        public void disable()
        {
            txttenncc.Enabled = false;
            txttheloai.Enabled = false;
            txttencd.Enabled = false;
            txttacgia.Enabled = false;
            txtsoluongnhap.Enabled = false;
            txtnamph.Enabled = false;
            txtmacd.Enabled = false;
            txtdonGia.Enabled = false;
            txtgiamuon.Enabled = false;
            txtghichu.Enabled = false;
            cbmancc.Enabled = false;
            cbtinhtrang.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtslcon.Enabled = false;

            txttenncc.Text = "";
            txttheloai.Text = "";
            txttencd.Text = "";
            txttacgia.Text = "";
            txtsoluongnhap.Text = "";
            txtnamph.Text = "";
            txtmacd.Text = "";
            txtdonGia.Text = "";
            txtgiamuon.Text = "";
            txtghichu.Text = "";
            txtslcon.Text = "";
        }
        public void enable()
        {
            txtslcon.Enabled = false;
            txttenncc.Enabled = false;
            txttheloai.Enabled = true;
            txttencd.Enabled = true;
            txttacgia.Enabled = true;
            txtsoluongnhap.Enabled = true;
            txtnamph.Enabled = true;
            txtmacd.Enabled = false;
            txtdonGia.Enabled = true;
            txtgiamuon.Enabled = true;
            txtghichu.Enabled = true;
            cbmancc.Enabled = true;
            cbtinhtrang.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txttenncc.Text = "";
            txttheloai.Text = "";
            txttencd.Text = "";
            txttacgia.Text = "";
            txtsoluongnhap.Text = "";
            txtnamph.Text = "";
           
            txtdonGia.Text = "";
            txtgiamuon.Text = "";
            txtghichu.Text = "";
            txtslcon.Text = "";
        }
        public int kiemtra()
        {
            /*string macd = txtmacd.Text;
            string tencd = txttencd.Text;
            string tencasi = txttencasi.Text;
            string mancc = cbmancc.Text;
            string namph = txtnamph.Text;
            string theloai = txttheloai.Text;
            int slnhap = int.Parse(txtsoluongnhap.Text);
            int gianhap = int.Parse(txtgianhap.Text);
            int giamuon = int.Parse(txtgiamuon.Text);
            string tinhtrang = cbtinhtrang.Text;
            string ghichu = txtghichu.Text;*/

            if (txttencd.Text == "" || txttacgia.Text == "" || cbmancc.Text == "" || txtnamph.Text == "" || txttheloai.Text == "" || cbtinhtrang.Text == "" ||txtsoluongnhap.Text == "" || txtgiamuon.Text == "" || txtdonGia.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            } else if (checkSo(txtsoluongnhap.Text) != 1 || checkSo(txtdonGia.Text) != 1 || checkSo(txtgiamuon.Text) != 1)
            {
                MessageBox.Show("3 trường sl Nhập & Giá Nhập & Giá mượn phải là số");
                return 0;
            } else if (int.Parse(txtsoluongnhap.Text) <= 0 || int.Parse(txtsoluongnhap.Text) > 9999 || int.Parse(txtdonGia.Text) <0 || int.Parse(txtgiamuon.Text) <0 )
            {
                MessageBox.Show("sl Nhập trong khoảng [1;9999] và giá nhập, giá mượn phải > 0");
                return 0;
            }
            return 1;
        }
        public int checkSo(string a )
        {
            int num = 0;
            
            if (Int32.TryParse(a, out num))
            {
                return 1;
            }
            else
            {
                return 0;
            }
               
        }
        // load ds + cb ma ncc+ load ten ncc
        public void loadDS()
        {
            QuanLyCDBLL qlcd = new QuanLyCDBLL();
            CD cd = new CD();
            List<CD> listcd = new List<CD>();
            listcd = qlcd.getDSCD();
            dataGridView1.DataSource = listcd;
            disable();
        }
        public void getCBMNCC()
        {
            List<CD> listcd = new List<CD>();
            QuanLyNccBLL qlncc = new QuanLyNccBLL();
            List<NhaCungCap> listNcc = new List<NhaCungCap>();


            listNcc = qlncc.getDSNcc();
            /*            txtmacd.Text = listcd.Count().ToString();
            */
            for (int i = 0; i < listNcc.Count(); i++)
            {
                cbmancc.Items.Add(listNcc[i].MaNcc.ToString());
            }
        }
       
        // code xu ly su kien 
        public void themCD()
        {
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            int x = dataGridView1.Rows.Count;
            txtmacd.Text = "CD0"+(x+1).ToString()+"";

          
            enable();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QuanLyCDBLL qlcd = new QuanLyCDBLL();
            CD cd = new CD();
            string macd = txtmacd.Text.Trim();
            string tencd = txttencd.Text.Trim();
            string theloai = txttheloai.Text.Trim();
            string tacgia = txttacgia.Text.Trim();
            string mancc = cbmancc.Text.Trim();
            int namph = int.Parse( txtnamph.Text.Trim());
            int slnhap =int.Parse( txtsoluongnhap.Text.Trim());
            int slcon =int.Parse( txtslcon.Text.Trim());
            int dongia =int.Parse( txtdonGia.Text.Trim());
            int giamuon = int.Parse( txtgiamuon.Text.Trim());
            string tinhtrang = cbtinhtrang.Text.Trim();
            string ghichu = txtghichu.Text.Trim();

            cd.MaCD = macd;
            cd.TenCD = tencd;
            cd.TheLoai = theloai;
            cd.TacGia = tacgia;
            cd.MaNcc = mancc;
            cd.NamPh = namph;
            cd.SlNhap = slnhap;
            cd.SlCon = slcon;
            cd.DonGia = dongia;
            cd.GiaMuon = giamuon;
            cd.TinhTrang = tinhtrang;
            cd.GhiChu = ghichu;
            if (qlcd.suaCd(cd))
            {
                MessageBox.Show("Sửa CD thành công!", "Thông báo");
                loadDS();
            }
            else
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemtra() == 1)
            {
                QuanLyCDBLL qlcd = new QuanLyCDBLL();
                CD cd = new CD();
                cd.MaCD = txtmacd.Text.Trim();
                cd.TenCD = txttencd.Text.Trim();
                cd.TheLoai = txttheloai.Text.Trim();
                cd.TacGia = txttacgia.Text.Trim();
                cd.MaNcc = cbmancc.Text;
                cd.NamPh = int.Parse(txtnamph.Text.Trim());
                cd.SlNhap = int.Parse(txtsoluongnhap.Text.Trim());
                cd.SlCon = int.Parse(txtsoluongnhap.Text.Trim());
                cd.DonGia = int.Parse(txtdonGia.Text.Trim());
                cd.GiaMuon = int.Parse(txtgiamuon.Text.Trim());
                cd.TinhTrang = cbtinhtrang.Text;
                cd.GhiChu = txtghichu.Text.Trim();
                if (qlcd.ThemCD(cd))
                {
                    MessageBox.Show("Thêm CD thành công!", "Thông báo");
                    loadDS();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
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



            // tao tieu de 
           


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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            disable();
            loadDS();
            txttimkiem.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            QuanLyCDBLL qlcd = new QuanLyCDBLL();
            dataGridView1.DataSource = qlcd.getDSCD();
            txttimkiem.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enable();
            txtslcon.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
            int i = dataGridView1.CurrentRow.Index;
            dataGridView1.CurrentRow.Selected = true;

            txtmacd.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txttencd.Text  = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txttheloai.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txttacgia.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbmancc.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtnamph.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtsoluongnhap.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtslcon.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtdonGia.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            txtgiamuon.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            cbtinhtrang.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            txtghichu.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
        }
        // textchang lay ten nha cung cap
        private void cbmancc_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyNccBLL qlncc = new QuanLyNccBLL();

            txttenncc.Text = qlncc.SearchNccMa(cbmancc.Text.Trim()).TenNcc;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            QuanLyCDBLL qlcd = new QuanLyCDBLL();
            string text = txttimkiem.Text.Trim();
            if (radtencd.Checked)
            {
                dataGridView1.DataSource = qlcd.timTheoTenCD(text);

            }
            if (radmacd.Checked)
            {
                dataGridView1.DataSource = qlcd.timTheoMaCD(text);
            }
            if (radtencasi.Checked)
            {
                dataGridView1.DataSource = qlcd.timTheoTenCaSi(text);
            }
            if (radtentheloai.Checked)
            {
                dataGridView1.DataSource = qlcd.timTheoTheLoai(text);
            }
        }
    }
}
