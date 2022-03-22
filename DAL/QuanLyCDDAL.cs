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
        List<CD> listCD = new List<CD>();
        // lay ds cd
        public List<CD> layDsCD()
        {
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
    }
}
