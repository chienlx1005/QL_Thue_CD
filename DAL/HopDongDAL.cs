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
    public class HopDongDAL:DataAccess
    {
        public bool checkHd(string ma)
        {
            string sql = "select * from hopDong where mahd = @mahd";

            try
            {
                moketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@mahd", ma);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dongketnoi();
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
