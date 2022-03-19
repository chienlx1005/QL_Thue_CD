using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class KhachHang
    {
        private string maKh;
        private string tenKh;
        private string gioiTinh;
        private int tuoi;
        private string sdt;
        private string diaChi;
        private string ghiChu;

        public KhachHang()
        {
        }

        public KhachHang(string maKh, string tenKh, string gioiTinh, int tuoi, string sdt, string diaChi, string ghiChu)
        {
            this.MaKh = maKh;
            this.TenKh = tenKh;
            this.GioiTinh = gioiTinh;
            this.Tuoi = tuoi;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
            this.GhiChu = ghiChu;
        }

        public string MaKh { get => maKh; set => maKh = value; }
        public string TenKh { get => tenKh; set => tenKh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
