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
   public class QuanLyNCCDAL:DataAccess
    {

        // lay danh sach nha cung cap
        List<NhaCungCap> listNcc = new List<NhaCungCap>();
 
        public List<NhaCungCap> layDsNcc()
        {
            try
            {
                moketnoi();
                string sql = "select * from nhaCungCap";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    string mancc = read.GetString(0);
                    string tenncc = read.GetString(1);
                    string email = read.GetString(2);
                    string sdt = read.GetString(3);
                    string diachi = read.GetString(4);
                    string trangthai = read.GetString(5);
                    string ghichu = read.GetString(6);

                    NhaCungCap ncc = new NhaCungCap();
                    ncc.MaNcc = mancc;
                    ncc.TenNcc = tenncc;
                    ncc.Email = email;
                    ncc.Sdt = sdt;
                    ncc.DiaChi = diachi;
                    ncc.TrangThai = trangthai;
                    ncc.GhiChu = ghichu;

                    listNcc.Add(ncc);
                }
                dongketnoi();

            }
            catch
            {

            }

            return listNcc;
        }
        // them nha cung cap 
        public bool themNcc(NhaCungCap ncc)
        {
            try
            {
                string sql = "insert into nhaCungCap(maNcc,tenNcc,email,sdt,diaChi,trangThai,ghiChu)"
                    +"values(@mancc, @tenncc, @email, @sdt, @diaChi, @trangThai, @ghiChu)";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@mancc", ncc.MaNcc);
                cmd.Parameters.Add("@tenncc", ncc.TenNcc);
                cmd.Parameters.Add("@email", ncc.Email);
                cmd.Parameters.Add("@sdt", ncc.Sdt);
                cmd.Parameters.Add("@diaChi", ncc.DiaChi);
                cmd.Parameters.Add("@trangThai", ncc.TrangThai);
                cmd.Parameters.Add("@ghiChu", ncc.GhiChu);

                int  x = cmd.ExecuteNonQuery();
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
        // sua nha cung cap 
        public bool suaNcc(NhaCungCap ncc)
        {
            try
            {
                string sql = "update nhaCungCap"
                +" set tenNcc = @tenncc,email = @email,sdt = @sdt,diaChi = @diachi,trangThai = @trangthai, ghiChu = @ghichu where maNcc = @mancc";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.Add("@tenncc", ncc.TenNcc);
                cmd.Parameters.Add("@email", ncc.Email);
                cmd.Parameters.Add("@sdt", ncc.Sdt);
                cmd.Parameters.Add("@diachi", ncc.DiaChi);
                cmd.Parameters.Add("@trangthai", ncc.TrangThai);
                cmd.Parameters.Add("@ghichu", ncc.GhiChu);
                cmd.Parameters.Add("@mancc", ncc.MaNcc);

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

        // tim kiem nha cung cap
        // tim kiem theo ma ncc 
        public NhaCungCap timKiemTheoMa(string maNcc)
        {
            moketnoi();
            NhaCungCap ncc = new NhaCungCap();
            string sql = "select * from nhaCungCap where maNcc = @MaNcc";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@MaNcc", maNcc);
            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string mancc = dr.GetString(0);
                string tenncc = dr.GetString(1);
                string email = dr.GetString(2);
                string sdt = dr.GetString(3);
                string diachi = dr.GetString(4);
                string trangthai = dr.GetString(5);
                string ghichu = dr.GetString(6);

                
                ncc.MaNcc = maNcc;
                ncc.TenNcc = tenncc;
                ncc.Email = email;
                ncc.Sdt = sdt;
                ncc.DiaChi = diachi;
                ncc.TrangThai = trangthai;
                ncc.GhiChu = ghichu;

            }
            dongketnoi();

            return ncc;
        }

        // tim kiem gan giong theo ma ncc 
        public List<NhaCungCap> timKiemDsNccTheoMa(string ma)
        {
            List<NhaCungCap> listdsncc = new List<NhaCungCap>();

            moketnoi();
            
            string sql = "select * from nhaCungCap where maNcc like '%"+ma+"%'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                string mancc = dr.GetString(0);
                string tenncc = dr.GetString(1);
                string email = dr.GetString(2);
                string sdt = dr.GetString(3);
                string diachi = dr.GetString(4);
                string trangthai = dr.GetString(5);
                string ghichu = dr.GetString(6);

                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNcc = mancc;
                ncc.TenNcc = tenncc;
                ncc.Email = email;
                ncc.Sdt = sdt;
                ncc.DiaChi = diachi;
                ncc.TrangThai = trangthai;
                ncc.GhiChu = ghichu;

                listdsncc.Add(ncc);
            }
            dongketnoi();

            return listdsncc;
        }

        // tim kiem gan dung theo ten  ncc
        public List<NhaCungCap> timKiemDsNccTheoten(string ten)
        {
            List<NhaCungCap> listdsncc = new List<NhaCungCap>();

            moketnoi();

            string sql = "select * from nhaCungCap where tenNcc like N'%" + ten + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                string mancc = dr.GetString(0);
                string tenncc = dr.GetString(1);
                string email = dr.GetString(2);
                string sdt = dr.GetString(3);
                string diachi = dr.GetString(4);
                string trangthai = dr.GetString(5);
                string ghichu = dr.GetString(6);

                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNcc = mancc;
                ncc.TenNcc = tenncc;
                ncc.Email = email;
                ncc.Sdt = sdt;
                ncc.DiaChi = diachi;
                ncc.TrangThai = trangthai;
                ncc.GhiChu = ghichu;

                listdsncc.Add(ncc);
            }
            dongketnoi();

            return listdsncc;
        }
    }
}
