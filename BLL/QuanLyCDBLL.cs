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
    }
}
