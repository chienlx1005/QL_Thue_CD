using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        private string mahd;
        private string taikhoan;
        private string matkhau;
        private string hoten;

        public NguoiDung()
        {
        }

        public NguoiDung(string mahd, string taikhoan, string matkhau, string hoten)
        {
            this.Mahd = mahd;
            this.Taikhoan = taikhoan;
            this.Matkhau = matkhau;
            this.Hoten = hoten;
        }

        public string Mahd { get => mahd; set => mahd = value; }
        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Hoten { get => hoten; set => hoten = value; }
    }
}
