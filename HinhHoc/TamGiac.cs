using System;

namespace HinhHoc
{
    public class TamGiac : LopDaGiac
    {
        public TamGiac() : base(3)
        {
        Nhap3CanhTG:
            NhapCanhA:
            try
            {
                Console.Write("Nhap canh 1: ");
                chieudaicanh[0] = Double.Parse(Console.ReadLine());
                if (chieudaicanh[0] <= 0)
                {
                    throw new NhapCanhDuongException("Nhap canh la so duong");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nhap du lieu la so");
                goto NhapCanhA;
            }
            catch (NhapCanhDuongException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                goto NhapCanhA;
            }
            NhapCanhB:
            try
            {
                Console.Write("Nhap canh 2: ");
                chieudaicanh[1] = Double.Parse(Console.ReadLine());
                if (chieudaicanh[1] <= 0)
                {
                    throw new NhapCanhDuongException("Nhap canh la so duong");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nhap du lieu la so");
                goto NhapCanhB;
            }
            catch (NhapCanhDuongException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                goto NhapCanhB;
            }
            NhapCanhC:
            try
            {
                Console.Write("Nhap canh 3: ");
                chieudaicanh[2] = Double.Parse(Console.ReadLine());
                if (chieudaicanh[2] <= 0)
                {
                    throw new NhapCanhDuongException("Nhap canh la so duong");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nhap du lieu la so");
                goto NhapCanhC;
            }
            catch (NhapCanhDuongException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                goto NhapCanhC;
            }
            try
            {
                if ((chieudaicanh[0] + chieudaicanh[1] <= chieudaicanh[2]) ||
                        (chieudaicanh[0] + chieudaicanh[2] <= chieudaicanh[1]) ||
                        (chieudaicanh[1] + chieudaicanh[2] <= chieudaicanh[0]))
                {
                    throw new NhapBaCanhTGException("3 canh vua nhap khong phai la 3 canh cua tam giac");
                }
            }
            catch (NhapBaCanhTGException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                goto Nhap3CanhTG;
            }
        }
        public override double TinhChuVi()
        {
            return chieudaicanh[0] + chieudaicanh[1] + chieudaicanh[2];
        }
        public override double TinhDienTich()
        {
            double P = (chieudaicanh[0] + chieudaicanh[1] + chieudaicanh[2]) / 2;
            return Math.Sqrt(P * (P - chieudaicanh[0]) * (P - chieudaicanh[1]) * (P - chieudaicanh[2]));
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Dien tich Tam Giac: {TinhDienTich():F2}");
            Console.WriteLine($"Chu vi Tam Giac: {TinhChuVi():F2}");
        }
    }
}