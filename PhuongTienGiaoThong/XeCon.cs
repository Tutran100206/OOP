using System;

namespace PhuongTienGiaoThong
{
    public class XeCon : PhuongTien, IChay, IXang
    {
        private int SoTuiKhi;
        private string KieuDongCo;

        public XeCon(string TenXe, string HangSanXuat, double TocDoToiDa, int SoChoNgoi, int SoTuiKhi, string KieuDongCo)
            : base(TenXe, HangSanXuat, TocDoToiDa, SoChoNgoi)
        {
            this.SoTuiKhi = SoTuiKhi;
            this.KieuDongCo = KieuDongCo;
        }

        public XeCon() : base()
        {
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap so tui khi: ");
            SoTuiKhi = Int32.Parse(Console.ReadLine());
            Console.Write("Nhap kieu dong co: ");
            KieuDongCo = Console.ReadLine();
        }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"So tui khi: {SoTuiKhi}");
            Console.WriteLine($"Kieu dong co: {KieuDongCo}");
        }

        public void Chay()
        {
            Console.WriteLine("Xe con dang chay tren duong");
        }
        public void DoXang()
        {
            Console.WriteLine("Xe con da do day xang");
        }
    }
}