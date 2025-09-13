using System;

namespace PhuongTienGiaoThong
{
    public abstract class PhuongTien
    {
        protected string TenXe;
        private string HangSanXuat;
        private double TocDoToiDa;
        private int SoChoNgoi;

        public PhuongTien(string TenXe, string HangSanXuat, double TocDoToiDa, int SoChoNgoi)
        {
            this.TenXe = TenXe;
            this.HangSanXuat = HangSanXuat;
            this.TocDoToiDa = TocDoToiDa;
            this.SoChoNgoi = SoChoNgoi;
        }
        public PhuongTien()
        {
        }

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ten xe: ");
            TenXe = Console.ReadLine();
            Console.Write("Nhap hang san xuat: ");
            HangSanXuat = Console.ReadLine();
            Console.Write("Nhap toc do toi da: ");
            TocDoToiDa = Double.Parse(Console.ReadLine());
            Console.Write("Nhap so cho ngoi: ");
            SoChoNgoi = Int32.Parse(Console.ReadLine());
        }

        public virtual void InThongTin()
        {
            Console.WriteLine("Ten xe: {0}", TenXe);
            Console.WriteLine("Hang san xuat: {0}", HangSanXuat);
            Console.WriteLine($"Toc do toi da: {TocDoToiDa:F2}");
            Console.WriteLine($"So cho ngoi: {SoChoNgoi}");
        }
    }
}