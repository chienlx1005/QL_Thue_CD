using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BLL;
using DTO;

namespace QLCDTester
{
    [TestClass]
    public class UnitTest1
    {
        NguoiDungBLL userbll = new NguoiDungBLL();
        NguoiDung user;
        HopDong hd;
        HopDongBLL hdbll = new HopDongBLL();

        private TestContext context;
        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }
        [TestInitialize] // khoi tao 
        public void SetUp()
        {
            

        }
        // test chức năng đăng nhập
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"E:\nam4-ky2\du_an_Quan_Ly_Thue_CD\QLCD\QLCDTester\DataTest\DangNhapTest.csv", "DangNhapTest#csv",DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestDangNhap()// test case 1
        {
            string tk, mk;
            bool expected, actual;

            user = new NguoiDung();
            user.Taikhoan = context.DataRow[0].ToString();
            user.Matkhau = context.DataRow[1].ToString();
            user.Hoten = "";
            expected = Convert.ToBoolean(context.DataRow[2].ToString());

            actual = userbll.dangNhap(user);

            Assert.AreEqual(expected, actual);
        }

        // test chức năng đăng ký
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"E:\nam4-ky2\du_an_Quan_Ly_Thue_CD\QLCD\QLCDTester\DataTest\DangKyTest.csv", "DangKyTest#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestDangKy()// test case 1
        {
            string mahd, tk, mk, laimk, hoten;
            bool expected, actual;

            user = new NguoiDung();
            user.Mahd = context.DataRow[0].ToString();
            user.Taikhoan = context.DataRow[1].ToString();
            user.Matkhau = context.DataRow[2].ToString();
            string nhaplaimk = context.DataRow[3].ToString();
            user.Hoten = context.DataRow[4].ToString();
            expected = Convert.ToBoolean(context.DataRow[5].ToString());


            actual = userbll.dangKyNguoiDung(user, nhaplaimk);


            Assert.AreEqual(expected, actual);
        }
        // test chức năng đổi mật khẩu 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"E:\nam4-ky2\du_an_Quan_Ly_Thue_CD\QLCD\QLCDTester\DataTest\DoiMatKhauTest.csv", "DoiMatKhauTest#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestDoiMatKhau()// test case 1
        {
            string mkcu, mkmoi, nhaplaimk;
            bool expected, actual;

            user = new NguoiDung();
            mkcu = context.DataRow[0].ToString();
            mkmoi = context.DataRow[1].ToString();
            nhaplaimk = context.DataRow[2].ToString();
            expected = Convert.ToBoolean(context.DataRow[3].ToString());
            if(nhaplaimk != mkmoi)
            {
                actual = false;
            }

            actual = userbll.doiMatKhau(user, nhaplaimk);

            Assert.AreEqual(expected, actual);
        }

    }
}
