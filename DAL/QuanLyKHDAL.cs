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
    public class QuanLyKHDAL:DataAccess
    {
        // lay danh sach khach hang
        List<KhachHang> listkh = new List<KhachHang>();

        public List<KhachHang> layDsKh()
        {
            try
            {
                moketnoi();
                string sql = "select * from khachhang";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    string makh = read.GetString(0);
                    string tenkh  = read.GetString(1);
                    string gioitinh = read.GetString(2);
                    int tuoi = read.GetInt32(3);
                    string sdt = read.GetString(4);
                    string diachi = read.GetString(5);
                    string ghichu = read.GetString(6);

                    KhachHang kh = new KhachHang();
                    kh.MaKh = makh;
                    kh.TenKh = tenkh;
                    kh.GioiTinh = gioitinh;
                    kh.Tuoi = tuoi;
                    kh.Sdt = sdt;
                    kh.DiaChi = diachi;
                    kh.GhiChu = ghichu;

                    listkh.Add(kh);
                }
                dongketnoi();

            }
            catch(Exception ex)
            {
                
            }

            return listkh;
        }
        // them khach hang
        public bool themKh(KhachHang kh)
        {
            try
            {
                string sql = "insert into khachHang(maKh,tenKh,gioiTinh,tuoi,sdt,diaChi,ghiChu)"
                    +"values(@makh, @tenkh, @gioitinh, @tuoi, @sdt, @diachi, @ghichu)";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@makh", kh.MaKh);
                cmd.Parameters.Add("@tenkh", kh.TenKh);
                cmd.Parameters.Add("@gioitinh", kh.GioiTinh);
                cmd.Parameters.Add("@tuoi", kh.Tuoi);
                cmd.Parameters.Add("@sdt", kh.Sdt);
                
                cmd.Parameters.Add("@diachi", kh.DiaChi);
                cmd.Parameters.Add("@ghichu", kh.GhiChu);

                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dongketnoi();
            }
            catch
            {
                return false;
            }


        }
        // sua khach hang
        public bool suaKh(KhachHang kh)
        {
            try
            {
                string sql = "update khachHang "
                +" set tenKh = @tenkh, gioiTinh = @gioitinh,tuoi = @tuoi, sdt = @sdt, diaChi =@diachi,ghiChu = @ghichu where maKh = @makh";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@makh", kh.MaKh);
                cmd.Parameters.Add("@tenkh", kh.TenKh);
                cmd.Parameters.Add("@gioitinh", kh.GioiTinh);
                cmd.Parameters.Add("@tuoi", kh.Tuoi);
                cmd.Parameters.Add("@sdt", kh.Sdt);
                cmd.Parameters.Add("@diachi", kh.DiaChi);
                cmd.Parameters.Add("@ghichu", kh.GhiChu);

                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dongketnoi();
            }
            catch
            {
                return false;
            }
        }

        // tim kiem gan dung theo ma khach hang
        public List<KhachHang> timKiemDsKhTheoMa(string ma)
        {
            List<KhachHang> listdskh = new List<KhachHang>();

            moketnoi();

            string sql = "select * from khachHang  where maKh like '%" + ma + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                string makh = dr.GetString(0);
                string tenkh = dr.GetString(1);
                string gioitinh = dr.GetString(2);
                int tuoi = dr.GetInt32(3);
                string sdt = dr.GetString(4);
                string diachi = dr.GetString(5);
                string ghichu = dr.GetString(6);

                KhachHang kh = new KhachHang();
                kh.MaKh = makh;
                kh.TenKh = tenkh;
                kh.GioiTinh = gioitinh;
                kh.Tuoi = tuoi;
                kh.Sdt = sdt;
                kh.DiaChi = diachi;
                kh.GhiChu = ghichu;

                listdskh.Add(kh);
            }
            dongketnoi();

            return listdskh;
        }
        // tim kiem gan dung theo ten khach hang
        public List<KhachHang> timKiemDsKhTheoTen(string ten)
        {
            List<KhachHang> listdskh = new List<KhachHang>();
            moketnoi();
            
            string sql = "select * from khachHang  where tenKh like N'%" + ten + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                string makh = dr.GetString(0);
                string tenkh = dr.GetString(1);
                string gioitinh = dr.GetString(2);
                int tuoi = dr.GetInt32(3);
                string sdt = dr.GetString(4);
                string diachi = dr.GetString(5);
                string ghichu = dr.GetString(6);

                KhachHang kh = new KhachHang();

                kh.MaKh = makh;
                kh.TenKh = tenkh;
                kh.GioiTinh = gioitinh;
                kh.Tuoi = tuoi;
                kh.Sdt = sdt;
                kh.DiaChi = diachi;
                kh.GhiChu = ghichu;

                listdskh.Add(kh);
            }
            dongketnoi();

            return listdskh;
        }
        // tim kiem khach hang
        public KhachHang timKiemKhachHang(string ma)
        {
            moketnoi();
            KhachHang kh = new KhachHang();

            string sql = "select * from khachHang where maKh = @makh";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@MaNcc", ma);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string makh = dr.GetString(0);
                string tenkh = dr.GetString(1);
                string gioitinh = dr.GetString(2);
                int tuoi = dr.GetInt32(3);
                string sdt = dr.GetString(4);
                string diachi = dr.GetString(5);
                string ghichu = dr.GetString(6);



                kh.MaKh = makh;
                kh.TenKh = tenkh;
                kh.GioiTinh = gioitinh;
                kh.Tuoi = tuoi;
                kh.Sdt = sdt;
                kh.DiaChi = diachi;
                kh.GhiChu = ghichu;

            }
            dongketnoi();

            return kh;
        }
    }
}
