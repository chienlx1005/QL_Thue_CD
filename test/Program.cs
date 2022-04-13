using System;
using BLL;
using DTO;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            NguoiDung user = new NguoiDung("admin", "1", "abc");
            NguoiDungBLL userbll = new NguoiDungBLL();
            bool a = true;
            Console.WriteLine(a);
        }
    }
}
