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
            XeCon xc01 = new XeCon();
            xc01.NhapThongTin();
            xc01.InThongTin();
            Console.ReadKey();
        }
    }
}