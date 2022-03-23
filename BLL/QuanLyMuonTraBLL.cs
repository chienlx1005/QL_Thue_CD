using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class QuanLyMuonTraBLL
    {
        QuanLyMuonTraDAL qlmt = new QuanLyMuonTraDAL();
        public List<PhieuThue> layDsPhieuThue()
        {
            return qlmt.layDsPhieuThue();
        }
        // lay ds phieu thue co trong db de cai dat ma phieu thue
        public List<PhieuThue> layDsPhieuThueSetMa()
        {
            return qlmt.layDsPhieuThueSetMa();
        }
        // them phieu thue
        public bool themPhieuThue(PhieuThue pt)
        {
            return qlmt.themPhieuThue(pt);
        }
        // tra phieu thue
        public bool traThueCD(PhieuThue pt)
        {
            return qlmt.traDiaCD(pt);
        }
        // tim kiem phieu thue theo ma kh
        public List<PhieuThue> timPhieuThueTheoMaKH(string ma)
        {
            return qlmt.timKiemPhieuTheoMaKH(ma);
        }
        // tim kiem phieu thue theo ma cd
        public List<PhieuThue> timPhieuThueTheoMaCD(string ma)
        {
            return qlmt.timKiemPhieuTheoMaCD(ma);
        }
    }
}
