using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class HopDongBLL
    {
        HopDongDAL qlhd = new HopDongDAL();
        public bool kiemTraHd(string ma)
        {
            return qlhd.checkHd(ma);
        }
    }
}
