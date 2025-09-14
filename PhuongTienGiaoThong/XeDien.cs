using System;

namespace PhuongTienGiaoThong
{
    public class XeDien : PhuongTien, IChay, IDien
    {
        public int PhanTramPin;
        public XeDien(string TenXe, string HangSanXuat, double TocDoToiDa, int SoChoNgoi, int PhanTramPin)
        : base(TenXe, HangSanXuat, TocDoToiDa, SoChoNgoi)
        {
            this.PhanTramPin = PhanTramPin;
        }
        public XeDien() : base()
        {
        }
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap phan tram pin: ");
            PhanTramPin = Int32.Parse(Console.ReadLine());
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Phan tram pin: {PhanTramPin}%");
        }
        public void Chay()
        {
            Console.WriteLine($"Xe dien {TenXe} dang chay tren duong");
        }
        public void NapDien()
        {
            Console.WriteLine($"Xe dien {TenXe} da duoc sac day dien");
        }
    }
}