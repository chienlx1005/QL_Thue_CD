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
        public List<NhaCungCap> getDSNcc()
        {
            return qlncc.layDsNcc();
        }
        public NhaCungCap SearchNccMa(string mancc)
        {
            return qlncc.timKiemTheoMa(mancc);
        }
    }
}
