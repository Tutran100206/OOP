using System;

namespace HinhHoc
{
    class Program
    {
        static void Main(string[] args)
        {
            HinhVuong hv01 = new HinhVuong();
            hv01.InThongTin();
            HinhChuNhat hcn01 = new HinhChuNhat();
            hcn01.InThongTin();
            TamGiac tg01 = new TamGiac();
            tg01.InThongTin();
        }
    }
}