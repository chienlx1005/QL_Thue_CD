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
            if (qlcd.suaCD(cd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // tim kiem cd

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
