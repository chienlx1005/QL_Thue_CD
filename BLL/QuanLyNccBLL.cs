using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class QuanLyNccBLL
    {
        QuanLyNCCDAL qlncc = new QuanLyNCCDAL();
        // lay ds ncc
        public List<NhaCungCap> getDSNcc()
        {
            return qlncc.layDsNcc();
        }
        // tim kiem ncc theo mancc
        public NhaCungCap SearchNccMa(string mancc)
        {
            return qlncc.timKiemTheoMa(mancc);
        }
        // them ncc
        public bool addNcc(NhaCungCap ncc)
        {
            return qlncc.themNcc(ncc);
        }
        // sua ncc
        public bool editNcc(NhaCungCap ncc)
        {
            return qlncc.suaNcc(ncc);
        }

        // tim kiem gan dung ma ncc
        public List<NhaCungCap> timKiemTheoMaNcc(string ma)
        {
            return qlncc.timKiemDsNccTheoMa(ma);
        }

        // tim kiem gan dung theo ten ncc
        public List<NhaCungCap> timKiemTheoTenNcc(string ten)
        {
            return qlncc.timKiemDsNccTheoten(ten);
        }
    }
}
