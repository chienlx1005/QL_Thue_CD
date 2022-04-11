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
using Excel = Microsoft.Office.Interop.Excel;
namespace QL_Thue_CD
{
    public partial class QuanLyMuonTra : Form
    {
        public QuanLyMuonTra()
        {
            InitializeComponent();
        }

        private void QuanLyMuonTra_Load(object sender, EventArgs e)
        {
            disable();
            load2();
            loadCB();
            load();
           
        }
        public void load()
        {
            QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
            dataGridView1.DataSource = qlmt.layDsPhieuThue();

        }
        public void loadCB()
        {
            QuanLyKHBLL qlkh = new QuanLyKHBLL();
            QuanLyCDBLL qlcd = new QuanLyCDBLL();
            List<KhachHang> listkh = new List<KhachHang>();
            List<CD> listcd = new List<CD>();

            listkh = qlkh.layDSKH();
            listcd = qlcd.getDSCD();

            for(int i = 0; i < listkh.Count; i++)
            {
                cbmakh.Items.Add(listkh[i].MaKh.ToString());
            }
            for(int i = 0; i < listcd.Count; i++)
            {
                cbmacd.Items.Add(listcd[i].MaCD.ToString());
            }
        }
        public void disable()
        {
            txtmacd1.Enabled = txtmaphieu1.Enabled = txtmakh1.Enabled = txtslmuon1.Enabled = txtthanhtien1.Enabled = false;
            dtNgayMuon1.Enabled = dtNgayTra1.Enabled = false;
            txtghichu1.Enabled = cbtinhtrang1.Enabled = false;
            txtmacd.Enabled = txttencd.Enabled = txtsoluongcon.Enabled = txttheloai.Enabled = txtgiamuon.Enabled = false;
            txtmaphieu.Enabled = cbmakh.Enabled = cbmacd.Enabled = txtslmuon.Enabled = txtthanhtien.Enabled = false;
            dtNgayMuon.Enabled = dtNgayTra.Enabled = false;
            cbtinhtrang.Enabled = txtghichu.Enabled = false;
            btnHuy.Enabled = btnChomuon.Enabled = btnInphieuthuê.Enabled = false;
            btnTradia.Enabled = false;
            txtslTra1.Enabled = false;
            cbmacd.Text = cbmakh.Text = "";
            txtmaphieu.Text = txtthanhtien.Text =   txtghichu.Text = "";
            txttimkiem.Text = "";


        }
        public void enable()
        {
            cbmakh.Enabled = cbmacd.Enabled =   true;
            dtNgayMuon.Enabled = dtNgayTra.Enabled = true;
            cbtinhtrang.Enabled = txtghichu.Enabled = true;
            btnHuy.Enabled = btnChomuon.Enabled = true;
            cbmacd.Text = cbmakh.Text = "";
            txtthanhtien.Text = txtslmuon.Text = txtghichu.Text = "";

        }
        public int checkSo(string a)
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
        public int kiemtra()
        {
            if(cbmakh.Text == "" || cbmacd.Text == "" || txtslmuon.Text == "" || cbtinhtrang.Text == "")
            {
                MessageBox.Show("Không để trống!");
                return 0;
            }
            if(checkSo(txtslmuon.Text) == 0){
                MessageBox.Show("Số lượng mượn phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            if(int.Parse(txtslmuon.Text) <= 0 || int.Parse(txtslmuon.Text) > int.Parse(txtsoluongcon.Text))
            {
                MessageBox.Show("Số lượng mượn phải trong khoảng [1;x]. Trong đó x là: số cd còn lại trong kho!");
                return 0;
            }
            return 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
            txtslmuon.Text = "";
            QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
            int x = qlmt.layDsPhieuThueSetMa().Count;
            txtmaphieu.Text = "MP0" + (x + 1).ToString() + "";
            
        }

        private void btnChomuon_Click(object sender, EventArgs e)
        {
            
            if(kiemtra() == 1)
            {
                try
                {
                    int slcontrongkho = int.Parse(txtsoluongcon.Text) - int.Parse(txtslmuon.Text.Trim());


                    QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
                    QuanLyCDBLL qlcd = new QuanLyCDBLL();
                    string maphieu = txtmaphieu.Text.Trim();
                    string makh = cbmakh.Text;
                    string macd = cbmacd.Text;
                    int slmuon = int.Parse(txtslmuon.Text.Trim());
                    int sltra = 0;
                    int thanhtien = int.Parse(txtthanhtien.Text.Trim());
                    DateTime ngaymuon = dtNgayMuon.Value;
                    DateTime ngaytra = dtNgayTra.Value;
                    string tinhtrang = cbtinhtrang.Text.Trim();
                    int danhdau = 0;
                    string ghichu = txtghichu.Text.Trim();

                    PhieuThue pt = new PhieuThue();
                    pt.MaPhieu = maphieu;
                    pt.MaKh = makh;
                    pt.MaCD = macd;
                    pt.NgayMuon = ngaymuon;
                    pt.NgayTra = ngaytra;
                    pt.SlMuon = slmuon;
                    pt.SlTra = sltra;
                    pt.TinhTrang = tinhtrang;
                    pt.ThanhTien = thanhtien;
                    pt.DanhDau = danhdau;
                    pt.GhiChu = ghichu;

                    if (qlmt.themPhieuThue(pt) && qlcd.suaCdV2(slcontrongkho, macd))
                    {
                        MessageBox.Show("Cho mượn thành công! ", "Thông báo");
                        load();
                        disable();
                        txtslmuon.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Cho mượn không thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {

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

        private void cbmakh_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyKHBLL qlkh = new QuanLyKHBLL();
            
        }

        private void cbmacd_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyCDBLL qlcd = new QuanLyCDBLL();
            
            txttencd.Text = qlcd.timKiemCD(cbmacd.Text).TenCD;
            txtmacd.Text = qlcd.timKiemCD(cbmacd.Text).MaCD;
            txtsoluongcon.Text = qlcd.timKiemCD(cbmacd.Text).SlCon.ToString();
            txttheloai.Text = qlcd.timKiemCD(cbmacd.Text).TheLoai;
            txtgiamuon.Text = qlcd.timKiemCD(cbmacd.Text).GiaMuon.ToString();
            txtslmuon.Enabled = true;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load();
            disable();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int i = dataGridView1.CurrentRow.Index;
            txtmaphieu.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbmakh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbmacd.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtNgayMuon.Value = (DateTime)dataGridView1.Rows[i].Cells[3].Value;
            dtNgayTra.Value = (DateTime )dataGridView1.Rows[i].Cells[4].Value;
            txtslmuon.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtthanhtien.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            cbtinhtrang.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            txtghichu.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();

        }

        private void btnLoad1_Click(object sender, EventArgs e)
        {
            load2();
            btnTradia.Enabled = false;
            disable();
        }
        public void load2()
        {
            QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
            dataGridView2.DataSource = qlmt.layDsPhieuThue();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            int i = dataGridView2.CurrentRow.Index;
            txtmaphieu1.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            txtmakh1.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            txtmacd1.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
            dtNgayMuon1.Value = (DateTime)dataGridView2.Rows[i].Cells[3].Value;
            dtNgayTra1.Value = (DateTime)dataGridView2.Rows[i].Cells[4].Value;
            txtslmuon1.Text = dataGridView2.Rows[i].Cells[5].Value.ToString();
            txtslTra1.Text = dataGridView2.Rows[i].Cells[6].Value.ToString();
            txtthanhtien1.Text = dataGridView2.Rows[i].Cells[7].Value.ToString();
            cbtinhtrang1.Text = dataGridView2.Rows[i].Cells[8].Value.ToString();
            txtghichu1.Text = dataGridView2.Rows[i].Cells[10].Value.ToString();
            btnTradia.Enabled =  txtslTra1.Enabled= cbtinhtrang1.Enabled = txtghichu1.Enabled = true;
            
        }

        private void txtthanhtien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtslmuon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtgiamuon.Text == "" )
                {

                    return;
                }
                txtthanhtien.Text = (int.Parse(txtgiamuon.Text.Trim()) * int.Parse(txtslmuon.Text.Trim())).ToString();
            }
            catch
            {

            }
            
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
            string text = txttimkiem.Text.Trim();
            if (radmakh.Checked) {
                dataGridView1.DataSource = qlmt.timPhieuThueTheoMaKH(text);
            }
            if (radmacd.Checked)
            {
                dataGridView1.DataSource = qlmt.timPhieuThueTheoMaCD(text);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
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
        public void ExportToExcel(string path)
        {
            Excel.Application application = new Excel.Application();

            application.Application.Workbooks.Add(Type.Missing);



            // tao tieu de 

            application.Cells[1, 5] = "Danh sách Phiếu Thuê";

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

        private void btnInphieuthuê_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển", "Thông báo");
        }

        private void txttimkiem1_TextChanged(object sender, EventArgs e)
        {
            QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
            string text = txttimkiem1.Text.Trim();
            if (radmakh12.Checked)
            {
                dataGridView2.DataSource = qlmt.timPhieuThueTheoMaKH(text);
            }
            if (radmacd12.Checked)
            {
                dataGridView2.DataSource = qlmt.timPhieuThueTheoMaCD(text);

            }
        }

        private void btnTradia_Click(object sender, EventArgs e)
        {
            if(check2() == 1)
            {
                


                QuanLyMuonTraBLL qlmt = new QuanLyMuonTraBLL();
                QuanLyCDBLL qlcd = new QuanLyCDBLL();
                string maphieu = txtmaphieu1.Text.Trim();
                string makh = txtmakh1.Text.Trim();
                string macd = txtmacd1.Text.Trim();
                int slmuon = int.Parse(txtslmuon1.Text.Trim());
                int sltra = int.Parse(txtslTra1.Text.Trim());
                int thanhtien = int.Parse(txtthanhtien1.Text.Trim());
                DateTime ngaymuon = dtNgayMuon1.Value;
                DateTime ngaytra = dtNgayTra1.Value;
                string tinhtrang = cbtinhtrang1.Text.Trim();
                int danhdau = 1;
                string ghichu = txtghichu1.Text.Trim();

                int slcontrongkho = int.Parse(txtsoluongcon.Text) + sltra;

                PhieuThue pt = new PhieuThue();
                pt.MaPhieu = maphieu;
                pt.MaKh = makh;
                pt.MaCD = macd;
                pt.NgayMuon = ngaymuon;
                pt.NgayTra = ngaytra;
                pt.SlMuon = slmuon;
                pt.SlTra = sltra;
                pt.TinhTrang = tinhtrang;
                pt.ThanhTien = thanhtien;
                pt.DanhDau = danhdau;
                pt.GhiChu = ghichu;

                if (qlmt.traThueCD(pt) && qlcd.suaCdV2(slcontrongkho, macd))
                {
                    MessageBox.Show("Trả đĩa CD thành công! ", "Thông báo");
                    load2();
                }
                else
                {
                    MessageBox.Show("Trả đĩa CD không thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public int check2()
        {
            if(txtslTra1.Text == "" || cbtinhtrang1.Text == "")
            {
                MessageBox.Show("Không để trống số lượng trả và tình trạng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return 0;
            }
            if(int.Parse(txtslTra1.Text.Trim()) <= 0 || int.Parse(txtslTra1.Text.Trim()) > int.Parse(txtslmuon1.Text.Trim()))
            {
                MessageBox.Show("Số lượng trả nhập vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }
    }
}
