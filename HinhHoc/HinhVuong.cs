using System;

namespace HinhHoc
{
    public class HinhVuong : LopDaGiac
    {
        public HinhVuong() : base(1)
        {
        NhapLaiCanhHV:
            try
            {
                Console.Write("Nhap chieu dai canh hinh vuong: ");
                chieudaicanh[0] = Double.Parse(Console.ReadLine());
                if (chieudaicanh[0] <= 0)
                {
                    throw new NhapCanhDuongException("Nhap canh la so duong");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nhap du lieu la so");
                goto NhapLaiCanhHV;
            }
            catch (NhapCanhDuongException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                goto NhapLaiCanhHV;
            }
        }
        public override double TinhChuVi()
        {
            return chieudaicanh[0] * 4;
        }
        public override double TinhDienTich()
        {
            return chieudaicanh[0] * chieudaicanh[0];
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Dien tich Hinh Vuong: {TinhDienTich():F2}");
            Console.WriteLine($"Chu vi Hinh Vuong: {TinhChuVi():F2}");
        }
    }
}