using System;

namespace PhuongTienGiaoThong
{
    public class XeMay : PhuongTien, IChay, IXang
    {
        public double ThoiGianThayNhot;
        public double GiaTien;
        public XeMay(string TenXe, string HangSanXuat, double TocDoToiDa, int SoChoNgoi, double ThoiGianThayNhot, double GiaTien)
            : base(TenXe, HangSanXuat, TocDoToiDa, SoChoNgoi)
        {
            this.ThoiGianThayNhot = ThoiGianThayNhot;
            this.GiaTien = GiaTien;
        }
        public XeMay() : base()
        {
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Chu ki thanh nhot: ");
            ThoiGianThayNhot = Double.Parse(Console.ReadLine());
            Console.Write("Nhap gia tien thay nhot: ");
            GiaTien = Double.Parse(Console.ReadLine());
        }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Chu ki thay nhot: {ThoiGianThayNhot:F1} thang");
            Console.WriteLine($"Gia tien thay nhot: {GiaTien:F2}");
        }

        public void Chay()
        {
            Console.WriteLine($"Xe may {TenXe} dang chay tren duong");
        }
        public void DoXang()
        {
            Console.WriteLine($"Xe may {TenXe} da do day xang");
        }
    }
}