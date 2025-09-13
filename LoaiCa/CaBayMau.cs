using System;

namespace LoaiCa
{
    public class CaBayMau : LopCa, IBoi
    {
        private int SoMau;

        public CaBayMau(string TenCa, double CanNang, int SoMau, bool CoVay)
            : base(TenCa, CanNang, CoVay)
        {
            this.SoMau = SoMau;
        }
        public CaBayMau() : base()
        {
        }
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write($"Nhap so mau cua ca {TenCa}: ");
            SoMau = int.Parse(Console.ReadLine());
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"So Mau: {SoMau}");

        }
        public void Boi()
        {
            Console.WriteLine($"Ca {SoMau} mau {TenCa} dang boi tren mat nuoc");
        }
    }
}