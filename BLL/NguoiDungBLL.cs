using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BLL
{
    public class NguoiDungBLL
    {
        NguoiDungDAL userDal = new NguoiDungDAL();
        
        //login
        public bool dangNhap(NguoiDung user)
        {
            if (userDal.layUser(user))
            {
                
                return true;
            }
            else
            {
                return false;
            }
            
        }
        // doi mat khau
        public bool doiMatKhau(NguoiDung user)
        {
            return userDal.doiMatKhau(user);
        }
    }
}
