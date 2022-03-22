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
    public class QuanLyCDDAL:DataAccess
    {
        
        // lay ds cd
        public List<CD> layDsCD()
        {
            List<CD> listCD = new List<CD>();
            try
            {
                
                moketnoi();
                string sql = "select * from CD";
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataReader read = cmd.ExecuteReader();
               
                while(read.Read())
                {
                    string macd = read.GetString(0);
                    string tencd = read.GetString(1);
                    string theloai = read.GetString(2);
                    string tacgia = read.GetString(3);
                    string mancc = read.GetString(4);
                    int namph = read.GetInt32(5);
                    int slnhap = read.GetInt32(6);
                    int slcon = read.GetInt32(7);
                    int dongia = read.GetInt32(8);
                    int giamuon = read.GetInt32(9);
                    string tinhtrang = read.GetString(10);
                    string ghichu = read.GetString(11);

                    CD cd = new CD();
                    cd.MaCD = macd;
                    cd.TenCD = tencd;
                    cd.TheLoai = theloai;
                    cd.TacGia = tacgia;
                    cd.MaNcc = mancc;
                    cd.NamPh = namph;
                    cd.SlNhap = slnhap;
                    cd.SlCon = slcon;
                    cd.DonGia = dongia;
                    cd.GiaMuon = giamuon;
                    cd.TinhTrang = tinhtrang;
                    cd.GhiChu = ghichu;

                    listCD.Add(cd);
                }
                dongketnoi();

            }
            catch
            {

            }

            return listCD;
        }
        // them Cd
        public bool themCD(CD cd)
        {
            try
            {
                moketnoi();
                string sql = "insert into CD(maCD,tenCD,theLoai,tacGia,maNcc,namPh,slNhap,slCon,donGia,giaMuon,tinhTrang,ghiChu)"
                            + "values(@maCD, @tenCD, @theLoai, @tacGia, @maNcc, @namPh, @slNhap, @slCon, @donGia, @giaMuon, @tinhTrang, @ghiChu)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@maCD", cd.MaCD);
                cmd.Parameters.Add("@tenCD",cd.TenCD);
                cmd.Parameters.Add("@theLoai",cd.TheLoai);
                cmd.Parameters.Add("@tacGia",cd.TacGia);
                cmd.Parameters.Add("@maNcc",cd.MaNcc);
                cmd.Parameters.Add("@namPh",cd.NamPh);
                cmd.Parameters.Add("@slNhap",cd.SlNhap);
                cmd.Parameters.Add("@slCon",cd.SlCon);
                cmd.Parameters.Add("@donGia",cd.DonGia);
                cmd.Parameters.Add("@giaMuon",cd.GiaMuon);
                cmd.Parameters.Add("@tinhTrang",cd.TinhTrang);
                cmd.Parameters.Add("@ghiChu",cd.GhiChu);

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
        // sua cd
        public bool suaCD(CD cd)
        {
            try
            {
                string sql = "update CD "
                +" set tenCD = @tencd,theLoai = @theloai,tacGia = @tacgia,maNcc = @mancc,namPh = @namph,slNhap = @slnhap, slCon = @slcon,donGia =@dongia,giaMuon = @giamuon,tinhTrang = @tinhtrang,ghiChu = @ghichu where maCD =@macd";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tencd", cd.TenCD);
                cmd.Parameters.Add("@theloai", cd.TheLoai);
                cmd.Parameters.Add("@tacgia", cd.TacGia);
                cmd.Parameters.Add("@mancc", cd.MaNcc);
                cmd.Parameters.Add("@namph", cd.NamPh);
                cmd.Parameters.Add("@slnhap", cd.SlNhap);
                cmd.Parameters.Add("@slcon", cd.SlCon);
                cmd.Parameters.Add("@dongia", cd.DonGia);
                cmd.Parameters.Add("@giamuon", cd.GiaMuon);
                cmd.Parameters.Add("@tinhtrang", cd.TinhTrang);
                cmd.Parameters.Add("@ghichu", cd.GhiChu);
                cmd.Parameters.Add("@macd", cd.MaCD);


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
        // tim kiem cd
        //  tim kiem theo ten cd
        public List<CD> timKiemTheoTenCD(string ten)
        {
            List<CD> listcd= new List<CD>();
            try
            {


                moketnoi();

                string sql = "select * from CD where tenCD like '%" + ten + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string macd = read.GetString(0);
                    string tencd = read.GetString(1);
                    string theloai = read.GetString(2);
                    string tacgia = read.GetString(3);
                    string mancc = read.GetString(4);
                    int namph = read.GetInt32(5);
                    int slnhap = read.GetInt32(6);
                    int slcon = read.GetInt32(7);
                    int dongia = read.GetInt32(8);
                    int giamuon = read.GetInt32(9);
                    string tinhtrang = read.GetString(10);
                    string ghichu = read.GetString(11);

                    CD cd = new CD();
                    cd.MaCD = macd;
                    cd.TenCD = tencd;
                    cd.TheLoai = theloai;
                    cd.TacGia = tacgia;
                    cd.MaNcc = mancc;
                    cd.NamPh = namph;
                    cd.SlNhap = slnhap;
                    cd.SlCon = slcon;
                    cd.DonGia = dongia;
                    cd.GiaMuon = giamuon;
                    cd.TinhTrang = tinhtrang;
                    cd.GhiChu = ghichu;

                    listcd.Add(cd);
                }
                dongketnoi();
            }
            catch
            {

            }

            return listcd;
        }
        // tim kiem theo ma cd
        public List<CD> timKiemTheoMaCD(string ten)
        {
            List<CD> listcd = new List<CD>();
            try
            {


                moketnoi();

                string sql = "select * from CD where maCD like '%" + ten + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string macd = read.GetString(0);
                    string tencd = read.GetString(1);
                    string theloai = read.GetString(2);
                    string tacgia = read.GetString(3);
                    string mancc = read.GetString(4);
                    int namph = read.GetInt32(5);
                    int slnhap = read.GetInt32(6);
                    int slcon = read.GetInt32(7);
                    int dongia = read.GetInt32(8);
                    int giamuon = read.GetInt32(9);
                    string tinhtrang = read.GetString(10);
                    string ghichu = read.GetString(11);

                    CD cd = new CD();
                    cd.MaCD = macd;
                    cd.TenCD = tencd;
                    cd.TheLoai = theloai;
                    cd.TacGia = tacgia;
                    cd.MaNcc = mancc;
                    cd.NamPh = namph;
                    cd.SlNhap = slnhap;
                    cd.SlCon = slcon;
                    cd.DonGia = dongia;
                    cd.GiaMuon = giamuon;
                    cd.TinhTrang = tinhtrang;
                    cd.GhiChu = ghichu;

                    listcd.Add(cd);
                }
                dongketnoi();
            }
            catch
            {

            }

            return listcd;
        }
        // tim kiem theo ten ca si
        public List<CD> timKiemTheoTenCaSi(string ten)
        {
            List<CD> listcd = new List<CD>();
            try
            {
                moketnoi();

                string sql = "select * from CD where tacGia like '%" + ten + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string macd = read.GetString(0);
                    string tencd = read.GetString(1);
                    string theloai = read.GetString(2);
                    string tacgia = read.GetString(3);
                    string mancc = read.GetString(4);
                    int namph = read.GetInt32(5);
                    int slnhap = read.GetInt32(6);
                    int slcon = read.GetInt32(7);
                    int dongia = read.GetInt32(8);
                    int giamuon = read.GetInt32(9);
                    string tinhtrang = read.GetString(10);
                    string ghichu = read.GetString(11);

                    CD cd = new CD();
                    cd.MaCD = macd;
                    cd.TenCD = tencd;
                    cd.TheLoai = theloai;
                    cd.TacGia = tacgia;
                    cd.MaNcc = mancc;
                    cd.NamPh = namph;
                    cd.SlNhap = slnhap;
                    cd.SlCon = slcon;
                    cd.DonGia = dongia;
                    cd.GiaMuon = giamuon;
                    cd.TinhTrang = tinhtrang;
                    cd.GhiChu = ghichu;

                    listcd.Add(cd);
                }
                dongketnoi();
            }
            catch
            {

            }

            return listcd;
        }
        // tim kiem theo the loai
        public List<CD> timKiemTheoTheLoai(string ten)
        {
            List<CD> listcd = new List<CD>();
            try
            {
                moketnoi();

                string sql = "select * from CD where theLoai like '%" + ten + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string macd = read.GetString(0);
                    string tencd = read.GetString(1);
                    string theloai = read.GetString(2);
                    string tacgia = read.GetString(3);
                    string mancc = read.GetString(4);
                    int namph = read.GetInt32(5);
                    int slnhap = read.GetInt32(6);
                    int slcon = read.GetInt32(7);
                    int dongia = read.GetInt32(8);
                    int giamuon = read.GetInt32(9);
                    string tinhtrang = read.GetString(10);
                    string ghichu = read.GetString(11);

                    CD cd = new CD();
                    cd.MaCD = macd;
                    cd.TenCD = tencd;
                    cd.TheLoai = theloai;
                    cd.TacGia = tacgia;
                    cd.MaNcc = mancc;
                    cd.NamPh = namph;
                    cd.SlNhap = slnhap;
                    cd.SlCon = slcon;
                    cd.DonGia = dongia;
                    cd.GiaMuon = giamuon;
                    cd.TinhTrang = tinhtrang;
                    cd.GhiChu = ghichu;

                    listcd.Add(cd);
                }
                dongketnoi();
            }
            catch
            {

            }

            return listcd;
        }
    }
}
