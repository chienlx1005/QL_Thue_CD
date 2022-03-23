using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThue
    {
        private string maPhieu;
        private string maKh;
        private string maCD;
        private DateTime ngayMuon;
        private DateTime ngayTra;
        private int slMuon;
        private int slTra;
        private int thanhTien;
        private string tinhTrang;
        private int danhDau;
        private string ghiChu;

        public PhieuThue()
        {
        }

        public PhieuThue(string maPhieu, string maKh, string maCD, DateTime ngayMuon, DateTime ngayTra, int slMuon, int slTra, int thanhTien, string tinhTrang, int danhDau, string ghiChu)
        {
            this.MaPhieu = maPhieu;
            this.MaKh = maKh;
            this.MaCD = maCD;
            this.NgayMuon = ngayMuon;
            this.NgayTra = ngayTra;
            this.SlMuon = slMuon;
            this.SlTra = slTra;
            this.ThanhTien = thanhTien;
            this.TinhTrang = tinhTrang;
            this.DanhDau = danhDau;
            this.GhiChu = ghiChu;
        }

        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string MaKh { get => maKh; set => maKh = value; }
        public string MaCD { get => maCD; set => maCD = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public int SlMuon { get => slMuon; set => slMuon = value; }
        public int SlTra { get => slTra; set => slTra = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int DanhDau { get => danhDau; set => danhDau = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
