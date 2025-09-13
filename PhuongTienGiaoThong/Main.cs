using System;

namespace PhuongTienGiaoThong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XeMay xm01 = new XeMay();
            xm01.NhapThongTin();
            xm01.InThongTin();
            XeDien xd01 = new XeDien();
            xd01.NhapThongTin();
            xd01.InThongTin();
        }
    }
}