using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class NguoiDung
    {
        private string taikhoan;
        private string matkhau;
        private string hoten;

        public NguoiDung()
        {
        }

        public NguoiDung(string taikhoan, string matkhau, string hoten)
        {
            this.Taikhoan = taikhoan;
            this.Matkhau = matkhau;
            this.Hoten = hoten;
        }

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Hoten { get => hoten; set => hoten = value; }
    }
}
