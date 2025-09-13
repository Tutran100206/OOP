using System;

namespace LoaiCa
{
    public class CaTre : LopCa, IBo, IBoi
    {
        private double tocdobo;
        public CaTre(string TenCa, double CanNang, double tocdobo, bool CoVay)
            : base(TenCa, CanNang, CoVay)
        {
            this.tocdobo = tocdobo;
        }
        public CaTre() : base()
        {
        }
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write($"Nhap toc do bo cua ca tre {TenCa} (m/s): ");
            tocdobo = double.Parse(Console.ReadLine());
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Toc do bo: {tocdobo:F2} m/s");

        }
        public void Bo()
        {
            Console.WriteLine($"Ca tre {TenCa} dang bo tren mat dat");
        }
        public void Boi()
        {
            Console.WriteLine($"Ca tre {TenCa} dang boi tren mat nuoc");
        }
    }
}