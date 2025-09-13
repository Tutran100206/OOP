using System;

namespace LoaiCa
{
    public abstract class LopCa
    {
        protected string TenCa;
        protected double CanNang;
        bool CoVay;
        public LopCa(string TenCa, double CanNang, bool CoVay)
        {
            this.TenCa = TenCa;
            this.CanNang = CanNang;
            this.CoVay = CoVay;
        }
        public LopCa()
        {

        }
        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ten ca: ");
            TenCa = Console.ReadLine();
            Console.Write("Nhap can nang (kg): ");
            CanNang = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ca co vay khong? (y/n): ");
            string input = Console.ReadLine()?.ToLower();
            CoVay = (input == "y" || input == "yes");
        }
        public virtual void InThongTin()
        {
            Console.WriteLine($"Ten Ca: {TenCa}");
            Console.WriteLine($"Can Nang: {CanNang:F2} kg");   
            Console.WriteLine($"Co Vay: {(CoVay ? "Co" : "Khong")}");
        }
    }
}