using System;

namespace MoHinhNhanVien
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool Check = true;
            while (Check)
            {
                Console.WriteLine("             MENU           ");
                Console.WriteLine("1. Quan Ly Nhan Vien FullTime");
                Console.WriteLine("2. Quan Ly Nhan Vien PartTime");
                Console.WriteLine("3. Thoat chuong trinh");
                Console.WriteLine("    Hay nhap lua chon cua ban: ");
                int choice = Int32.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------");
                switch (choice)
                {
                    case 1:
                        ManagerFullTime managerFullTime = new ManagerFullTime();
                        managerFullTime.RunFullTime();
                        break;
                    case 2:
                        ManagerPartTime managerPartTime = new ManagerPartTime();
                        managerPartTime.RunPartTime();
                        break;
                    case 3:
                        Console.WriteLine("Thoat chuong trinh!");
                        Check = false;
                        break;
                    default:
                        Console.WriteLine("Chuc nang khong hop le! Vui long chon lai");
                        break;
                }
            }
        }
    }
}