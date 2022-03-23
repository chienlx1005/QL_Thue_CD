using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class QuanLyCDBLL
    {
        List<CD> listCD = new List<CD>();
        QuanLyCDDAL qlcd = new QuanLyCDDAL();

        public List<CD> getDSCD()
        {
            return qlcd.layDsCD();
        }
        // them cd
        public bool ThemCD(CD cd)
        {
            if (qlcd.themCD(cd))
            {
                return true;
            }else
            {
                return false;
            }
        }
        // sua cd
        public bool suaCd(CD cd)
        {
           return qlcd.suaCD(cd);
 
        }
        // sua cd v2
        public bool suaCdV2(int slcon, string macd)
        {
            return qlcd.suaCDv2(slcon, macd);
        }

        // tim kiem cd
        public CD timKiemCD(string ma)
        {
            return qlcd.timKiemCD(ma);
        }

        // tim theo ten cd
        public List<CD> timTheoTenCD(string ten)
        {
            return qlcd.timKiemTheoTenCD(ten);
        }

        public List<CD> timTheoMaCD(string ten)
        {
            return qlcd.timKiemTheoMaCD(ten);
        }
        public List<CD> timTheoTenCaSi(string ten)
        {
            return qlcd.timKiemTheoTenCaSi(ten);
        }
        public List<CD> timTheoTheLoai(string ten)
        {
            return qlcd.timKiemTheoTheLoai(ten);
        }
    }
}
