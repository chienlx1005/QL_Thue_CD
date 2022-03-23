using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class QuanLyKHBLL
    {
        QuanLyKHDAL qlkh = new QuanLyKHDAL();
        public List<KhachHang> layDSKH()
        {
            return qlkh.layDsKh();
        }
        // them
        public bool themKh(KhachHang kh)
        {
            return qlkh.themKh(kh);
        }
        // sua
        public bool suaKh(KhachHang kh)
        {
            return qlkh.suaKh(kh);
        }

        // tim kiem theo ma
        public List<KhachHang> timKiemTheoMaKh(string ma)
        {
            return qlkh.timKiemDsKhTheoMa(ma);
        }
        // tim theo ten
        public List<KhachHang> timKiemTheoTenKh(string ten)
        {
            return qlkh.timKiemDsKhTheoTen(ten);
        }

        // tim kiem khach hang
        public KhachHang timKiemKh(string ma)
        {
            return qlkh.timKiemKhachHang(ma);

        } 

    }
}
