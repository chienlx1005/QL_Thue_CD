using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PhieuThue
    {
        private string maPhieu;
        private string maKh;
        private string maCD;
        private string ngayMuon;
        private string ngayTra;
        private int slMuon;
        private int slTra;
        private string tinhTrang;
        private string ghiChu;
        private int danhDau;

        public PhieuThue()
        {
        }

        public PhieuThue(string maPhieu, string maKh, string maCD, string ngayMuon, string ngayTra, int slMuon, int slTra, string tinhTrang, string ghiChu, int danhDau)
        {
            this.MaPhieu = maPhieu;
            this.MaKh = maKh;
            this.MaCD = maCD;
            this.NgayMuon = ngayMuon;
            this.NgayTra = ngayTra;
            this.SlMuon = slMuon;
            this.SlTra = slTra;
            this.TinhTrang = tinhTrang;
            this.GhiChu = ghiChu;
            this.DanhDau = danhDau;
        }

        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string MaKh { get => maKh; set => maKh = value; }
        public string MaCD { get => maCD; set => maCD = value; }
        public string NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public string NgayTra { get => ngayTra; set => ngayTra = value; }
        public int SlMuon { get => slMuon; set => slMuon = value; }
        public int SlTra { get => slTra; set => slTra = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int DanhDau { get => danhDau; set => danhDau = value; }
    }
}
