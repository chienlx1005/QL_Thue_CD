using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class CD
    {
        private string maCD;
        private string tenCD;
        private string theLoai;
        private string tacGia;
        private string maNcc;
        private int namPh;
        private int slNhap;
        private int slCon;
        private float donGia;
        private float giaMuon;
        private string tinhTrang;
        private string ghiChu;

        public CD()
        {
        }

        public CD(string maCD, string tenCD, string theLoai, string tacGia, string maNcc, int namPh, int slNhap, int slCon, float donGia, float giaMuon, string tinhTrang, string ghiChu)
        {
            this.MaCD = maCD;
            this.TenCD = tenCD;
            this.TheLoai = theLoai;
            this.TacGia = tacGia;
            this.MaNcc = maNcc;
            this.NamPh = namPh;
            this.SlNhap = slNhap;
            this.SlCon = slCon;
            this.DonGia = donGia;
            this.GiaMuon = giaMuon;
            this.TinhTrang = tinhTrang;
            this.GhiChu = ghiChu;
        }

        public string MaCD { get => maCD; set => maCD = value; }
        public string TenCD { get => tenCD; set => tenCD = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public string MaNcc { get => maNcc; set => maNcc = value; }
        public int NamPh { get => namPh; set => namPh = value; }
        public int SlNhap { get => slNhap; set => slNhap = value; }
        public int SlCon { get => slCon; set => slCon = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public float GiaMuon { get => giaMuon; set => giaMuon = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
