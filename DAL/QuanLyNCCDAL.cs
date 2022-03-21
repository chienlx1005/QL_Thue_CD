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
    }
}
