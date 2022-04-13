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
        public bool doiMatKhau(NguoiDung user,string nhaplaimk)
        {
            if(user.Matkhau != nhaplaimk)
            {
                return false;
            }
            
            return userDal.doiMatKhau(user);
        }
       
        // dang ky nguoi dung
        public bool dangKyNguoiDung(NguoiDung user,string nhaplaimmk)
        {
            if(user.Matkhau != nhaplaimmk)
            {
                return false;
            }
            else
            {
                return userDal.dangKy(user);
            }
           
        }

        
    }
}
