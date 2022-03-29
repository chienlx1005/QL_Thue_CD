using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataAccess
    {
        public static string strcon = @"Data Source=.\SQLEXPRESS;Initial Catalog=DAPM_THUE_CD;Integrated Security=True";
        /*  public SqlConnection con = new SqlConnection(strcon);*/
        public SqlConnection con = null;

        public void moketnoi()
        {

            /*con.Open();*/
            if (con == null)
            {
                con = new SqlConnection(strcon);

            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
        }
        public void dongketnoi()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }

           /* con.Close();*/
        }
    }
}
