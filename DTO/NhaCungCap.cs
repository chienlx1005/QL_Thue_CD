using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class NhaCungCap
    {
        private string maNcc;
        private string tenNcc;
        private string email;
        private string sdt;
        private string diaChi;
        private string trangThai;
        private string ghiChu;

        public NhaCungCap()
        {
        }

        public NhaCungCap(string maNcc, string tenNcc, string email, string sdt, string diaChi, string trangThai, string ghiChu)
        {
            this.MaNcc = maNcc;
            this.TenNcc = tenNcc;
            this.Email = email;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
            this.TrangThai = trangThai;
            this.GhiChu = ghiChu;
        }

        public string MaNcc { get => maNcc; set => maNcc = value; }
        public string TenNcc { get => tenNcc; set => tenNcc = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
