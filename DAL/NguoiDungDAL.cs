using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    
    public class NguoiDungDAL:DataAccess
    {

       

        public static NguoiDung user1 = new NguoiDung();

        public bool layUser(NguoiDung user)
        {
            try
            {

                moketnoi();
                string sql = "select * from nguoidung where taikhoan = @Taikhoan and matkhau = @Matkhau";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.Add("@Taikhoan", user.Taikhoan);
                cmd.Parameters.Add("@Matkhau", user.Matkhau);

            /*cmd.Parameters.Add(new SqlParameter("@Taikhoan", user.Taikhoan));
            cmd.Parameters.Add(new SqlParameter("@Matkhau", user.Matkhau));*/
            SqlDataReader dtr = cmd.ExecuteReader();

           
                if(dtr.Read() == true)
                {
                    user1.Mahd = dtr.GetString(0);
                    user1.Taikhoan = dtr.GetString(1);
                        user1.Matkhau = dtr.GetString(2);
                        user1.Hoten = dtr.GetString(3);
                   
                    dongketnoi();
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
        public bool doiMatKhau(NguoiDung user)
        {
            try
            {
                string sql = "update nguoiDung "
                    +" set matkhau = @matkhau where taikhoan = @taikhoan and mahd = @mahd";
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@matkhau", user.Matkhau);
                cmd.Parameters.Add("@taikhoan", user.Taikhoan);
                cmd.Parameters.Add("@mahd", user.Mahd);


                int x = cmd.ExecuteNonQuery();
                if(x > 0)
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
        public bool dangKy(NguoiDung user)
        {
            string sql = "insert into nguoidung(mahd,taikhoan,matkhau,hoten) "
            +" values(@mahd,@taikhoan, @matkhau, @hoten) ";

            try
            {
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@mahd", user.Mahd);
                cmd.Parameters.Add("@taikhoan", user.Taikhoan);
                cmd.Parameters.Add("@matkhau", user.Matkhau);
                cmd.Parameters.Add("@hoten", user.Hoten);

                int x = cmd.ExecuteNonQuery();

                if(x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dongketnoi();

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
