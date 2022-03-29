using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HopDong
    {
        private string maHd;
        private string hoTen;

        public HopDong()
        {
        }

        public HopDong(string maHd, string hoTen)
        {
            this.MaHd = maHd;
            this.HoTen = hoTen;
        }

        public string MaHd { get => maHd; set => maHd = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
    }
}
