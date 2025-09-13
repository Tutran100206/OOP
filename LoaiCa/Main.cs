using System;

namespace LoaiCa
{
    class Program
    {
        static void Main(string[] args)
        {
            LopCa[] dsCa = new LopCa[3];
            dsCa[0] = new CaBayMau();
            dsCa[1] = new CaTre();
            dsCa[2] = new CaChuon();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Nhap thong tin ca thu {i + 1}:");
                dsCa[i].NhapThongTin();
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Thong tin ca thu {i + 1}:");
                dsCa[i].InThongTin();
                if (dsCa[i] is IBo bo)
                {
                    bo.Bo();
                }
                if (dsCa[i] is IBoi boi)
                {
                    boi.Boi();
                }
                if (dsCa[i] is IBay bay)
                {
                    bay.Bay();
                }
            }
        }
    }
}
