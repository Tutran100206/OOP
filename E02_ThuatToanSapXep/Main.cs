using System;
using System.Diagnostics;

namespace E02_ThuatToanSapXep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong san pham muon doc: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("\nChon kieu sap xep:");
            Console.WriteLine("1. Gia (cao -> thap)");
            Console.WriteLine("2. So luong ban (cao -> thap)");
            Console.WriteLine("3. Diem danh gia (thap -> cao)");
            Console.WriteLine("4. Ten (A -> Z)");
            Console.Write("Lua chon: ");
            int choice = int.Parse(Console.ReadLine());

            SanPhamManager spm = new SanPhamManager();
            spm.DocFile("products.csv", n); // chỉ đọc n dòng từ file

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            switch (choice)
            {
                case 1:
                    spm.Sapxepgia(); 
                    break;
                case 2:
                    spm.Sapxepsoluongban();
                    break;
                case 3:
                    spm.Sapxeprating();
                    break;
                case 4:
                    spm.Sapxepten();
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    return;
            }

            stopwatch.Stop();

            Console.WriteLine($"\nDanh sach {n} san pham sau khi sap xep:");
            foreach (var sp in spm.ds)
            {
                Console.WriteLine(sp);
            }

            Console.WriteLine($"\nThoi gian sap xep (lua chon {choice}): {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}
