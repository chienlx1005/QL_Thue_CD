using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class QuanLyMuonTraDAL:DataAccess
    {

        public List<PhieuThue> layDsPhieuThue()
        {
            List<PhieuThue> listpt = new List<PhieuThue>();

            try
            {
                string sql = "select * from phieuThue where danhDau = 0";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string maphieu = dr.GetString(0);
                    string makh = dr.GetString(1);
                    string macd = dr.GetString(2);
                    DateTime ngaymuon = dr.GetDateTime(3);
                    DateTime ngaytra = dr.GetDateTime(4);
                    int slmuon = dr.GetInt32(5);
                    int sltra = dr.GetInt32(6);
                    int thanhtien = dr.GetInt32(7);
                    string tinhtrang = dr.GetString(8);
                    int danhdau = dr.GetInt32(9);
                    string ghichu = dr.GetString(10);

                    PhieuThue pt = new PhieuThue();
                    pt.MaPhieu = maphieu;
                    pt.MaKh = makh;
                    pt.MaCD = macd;
                    pt.NgayMuon = ngaymuon;
                    pt.NgayTra = ngaytra;
                    pt.SlMuon = slmuon;
                    pt.SlTra = sltra;
                    pt.ThanhTien = thanhtien;
                    pt.TinhTrang = tinhtrang;
                    pt.DanhDau = danhdau;
                    pt.GhiChu = ghichu;
                    listpt.Add(pt);
                }

             }
            catch
            {

            }
            return listpt;
        }
        // lay ds phieu thue de set ma phieu thue
        public List<PhieuThue> layDsPhieuThueSetMa()
        {
            List<PhieuThue> listpt = new List<PhieuThue>();

            try
            {
                string sql = "select * from phieuThue";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string maphieu = dr.GetString(0);
                    string makh = dr.GetString(1);
                    string macd = dr.GetString(2);
                    DateTime ngaymuon = dr.GetDateTime(3);
                    DateTime ngaytra = dr.GetDateTime(4);
                    int slmuon = dr.GetInt32(5);
                    int sltra = dr.GetInt32(6);
                    int thanhtien = dr.GetInt32(7);
                    string tinhtrang = dr.GetString(8);
                    int danhdau = dr.GetInt32(9);
                    string ghichu = dr.GetString(10);

                    PhieuThue pt = new PhieuThue();
                    pt.MaPhieu = maphieu;
                    pt.MaKh = makh;
                    pt.MaCD = macd;
                    pt.NgayMuon = ngaymuon;
                    pt.NgayTra = ngaytra;
                    pt.SlMuon = slmuon;
                    pt.SlTra = sltra;
                    pt.ThanhTien = thanhtien;
                    pt.TinhTrang = tinhtrang;
                    pt.DanhDau = danhdau;
                    pt.GhiChu = ghichu;
                    listpt.Add(pt);
                }

            }
            catch
            {

            }
            return listpt;
        }
        // them phieu thue
        public bool themPhieuThue(PhieuThue pt)
        {
            try
            {
                moketnoi();
                string sql = "insert into phieuThue(maPhieu,maKh,maCD,ngayMuon,ngayTra,slMuon,slTra,thanhTien,tinhTrang,danhDau,ghiChu)"
                +"  values(@maphieu, @makh, @macd, @ngaymuon, @ngaytra, @slmuon, @sltra, @thanhtien, @tinhtrang, @danhdau, @ghichu)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@maphieu", pt.MaPhieu);
                cmd.Parameters.Add("@makh", pt.MaKh);
                cmd.Parameters.Add("@macd", pt.MaCD);
                cmd.Parameters.Add("@ngaymuon", pt.NgayMuon);
                cmd.Parameters.Add("@ngaytra", pt.NgayTra);
                cmd.Parameters.Add("@slmuon", pt.SlMuon);
                cmd.Parameters.Add("@sltra", pt.SlTra);
                cmd.Parameters.Add("@thanhtien", pt.ThanhTien);
                cmd.Parameters.Add("@tinhtrang", pt.TinhTrang);
                cmd.Parameters.Add("@danhdau", pt.DanhDau);
                cmd.Parameters.Add("@ghichu", pt.GhiChu);
               

                int x = cmd.ExecuteNonQuery();
                dongketnoi();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }

        }
        public bool traDiaCD(PhieuThue pt)
        {
            try
            {
                moketnoi();
                string sql = "update phieuThue set slTra = @sltra , tinhTrang = @tinhtrang, danhDau = @danhdau, ghiChu = @ghichu where maPhieu = @maphieu";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@sltra", pt.SlTra);
                cmd.Parameters.Add("@tinhtrang", pt.TinhTrang);
                cmd.Parameters.Add("@danhdau", pt.DanhDau);
                cmd.Parameters.Add("@ghichu", pt.GhiChu);
                cmd.Parameters.Add("@maphieu", pt.MaPhieu);

                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        // tim kiem phieu thue
        public List<PhieuThue> timKiemPhieuTheoMaKH(string ma)
        {
            List<PhieuThue> listpt = new List<PhieuThue>();

            try
            {
                string sql = "select * from phieuThue where maKh like '%" + ma + "%'";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string maphieu = dr.GetString(0);
                    string makh = dr.GetString(1);
                    string macd = dr.GetString(2);
                    DateTime ngaymuon = dr.GetDateTime(3);
                    DateTime ngaytra = dr.GetDateTime(4);
                    int slmuon = dr.GetInt32(5);
                    int sltra = dr.GetInt32(6);
                    int thanhtien = dr.GetInt32(7);
                    string tinhtrang = dr.GetString(8);
                    int danhdau = dr.GetInt32(9);
                    string ghichu = dr.GetString(10);

                    PhieuThue pt = new PhieuThue();
                    pt.MaPhieu = maphieu;
                    pt.MaKh = makh;
                    pt.MaCD = macd;
                    pt.NgayMuon = ngaymuon;
                    pt.NgayTra = ngaytra;
                    pt.SlMuon = slmuon;
                    pt.SlTra = sltra;
                    pt.ThanhTien = thanhtien;
                    pt.TinhTrang = tinhtrang;
                    pt.DanhDau = danhdau;
                    pt.GhiChu = ghichu;
                    listpt.Add(pt);
                }

            }
            catch
            {

            }
            return listpt;
        }
        // tim kiem phieu thue theo ma cd
        public List<PhieuThue> timKiemPhieuTheoMaCD(string ma)
        {
            List<PhieuThue> listpt = new List<PhieuThue>();

            try
            {
                string sql = "select * from phieuThue where maCD like '%" + ma + "%'";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string maphieu = dr.GetString(0);
                    string makh = dr.GetString(1);
                    string macd = dr.GetString(2);
                    DateTime ngaymuon = dr.GetDateTime(3);
                    DateTime ngaytra = dr.GetDateTime(4);
                    int slmuon = dr.GetInt32(5);
                    int sltra = dr.GetInt32(6);
                    int thanhtien = dr.GetInt32(7);
                    string tinhtrang = dr.GetString(8);
                    int danhdau = dr.GetInt32(9);
                    string ghichu = dr.GetString(10);

                    PhieuThue pt = new PhieuThue();
                    pt.MaPhieu = maphieu;
                    pt.MaKh = makh;
                    pt.MaCD = macd;
                    pt.NgayMuon = ngaymuon;
                    pt.NgayTra = ngaytra;
                    pt.SlMuon = slmuon;
                    pt.SlTra = sltra;
                    pt.ThanhTien = thanhtien;
                    pt.TinhTrang = tinhtrang;
                    pt.DanhDau = danhdau;
                    pt.GhiChu = ghichu;
                    listpt.Add(pt);
                }

            }
            catch
            {

            }
            return listpt;
        }
    }
}
