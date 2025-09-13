using System;

namespace HinhHoc
{
    public class HinhChuNhat : LopDaGiac
    {
        public HinhChuNhat() : base(2)
        {
        NhapLaiCanhHCN:
            try
            {
                Console.Write("Nhap chieu dai hinh chu nhat: ");
                chieudaicanh[0] = Double.Parse(Console.ReadLine());
                Console.Write("Nhapchieu rong hinh chu nhat: ");
                chieudaicanh[1] = Double.Parse(Console.ReadLine());
                if (chieudaicanh[0] <= 0 || chieudaicanh[1] <= 0)
                {
                    throw new NhapCanhDuongException("Nhap canh la so duong");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nhap du lieu la so");
                goto NhapLaiCanhHCN;
            }
            catch (NhapCanhDuongException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                goto NhapLaiCanhHCN;
            }
        }
        public override double TinhChuVi()
        {
            return (chieudaicanh[0] + chieudaicanh[1]) * 2;
        }
        public override double TinhDienTich()
        {
            return chieudaicanh[0] * chieudaicanh[1];
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Dien tich Hinh Chu Nhat: {TinhDienTich():F2}");
            Console.WriteLine($"Chu vi Hinh Chu Nhat: {TinhChuVi():F2}");
        }
    }
}