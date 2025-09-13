using System;

namespace LoaiCa
{
    public class CaChuon : LopCa, IBoi, IBay
    {
        private double tocdobay;
        public CaChuon(string TenCa, double CanNang, double tocdobay, bool CoVay)
            : base(TenCa, CanNang, CoVay)
        {
            this.tocdobay = tocdobay;
        }
        public CaChuon() : base()
        {
        }
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write($"Nhap toc do bay cua ca chuon {TenCa} (m/s): ");
            tocdobay = double.Parse(Console.ReadLine());
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Toc do bay cua ca chuon {TenCa}: {tocdobay:F2} m/s");

        }
        public void Boi()
        {
            Console.WriteLine($"Ca chuon {TenCa} dang boi tren mat nuoc");
        }
        public void Bay()
        {
            Console.WriteLine($"Ca chuon {TenCa} dang bay tren bau troi");
        }
    }
}