using System;
using System.Collections.Generic;

namespace MoHinhNhanVien
{
    public class ManagerFullTime
    {
        private List<EmPloyFullTime> listEmPloyFullTime = new List<EmPloyFullTime>();

        public List<EmPloyFullTime> GetListEmPloyFullTime()
        {
            return listEmPloyFullTime;
        }

        public void SetListEmPloyFullTime(List<EmPloyFullTime> listEmPloyFullTime)
        {
            this.listEmPloyFullTime = listEmPloyFullTime;
        }
        public void displaylistEmPloyFullTime()
        {
            Console.WriteLine("------------Danh sach nhan vien FullTime------------");
            if (listEmPloyFullTime.Count == 0)
            {
                Console.WriteLine("Khong co nhan vien FullTime nao!");
                return;
            }
            for (int i = 0; i < listEmPloyFullTime.Count; i++)
            {
                listEmPloyFullTime[i].display();
            }
        }
        public void SalaryFullTime()
        {
            double total = 0;
            for (int i = 0; i < listEmPloyFullTime.Count; i++)
            {
                total += listEmPloyFullTime[i].getSalary();
            }
            Console.WriteLine($"Tong luong phai tra cho nhan vien FullTime: {total:F2}");
        }
        public void SearchFullTime()
        {
            Console.Write("Nhap ten nhan vien can tim: ");
            string name = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < listEmPloyFullTime.Count; i++)
            {
                if (listEmPloyFullTime[i].getName().Contains(name))
                {
                    listEmPloyFullTime[i].display();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay nhan vien can tim!");
            }
        }
        public void SapXepTen()
        {
            for (int i = 0; i < listEmPloyFullTime.Count - 1; i++)
            {
                for (int j = i + 1; j < listEmPloyFullTime.Count; j++)
                {
                    if (String.Compare(listEmPloyFullTime[i].getName(), listEmPloyFullTime[j].getName()) > 0)
                    {
                        EmPloyFullTime temp = listEmPloyFullTime[i];
                        listEmPloyFullTime[i] = listEmPloyFullTime[j];
                        listEmPloyFullTime[j] = temp;
                    }
                }
            }
            Console.WriteLine("Danh sach nhan vien FullTime sau khi sap xep theo ten: ");
            displaylistEmPloyFullTime();
        }
        public void RunFullTime()
        {
            int choice;
            do
            {
                Console.WriteLine("------------Menu quan ly nhan vien FullTime------------");
                Console.WriteLine("1. Nhap Thong Tin Nhan Vien FullTime");
                Console.WriteLine("2. Hien Thi Danh Sach Nhan Vien FullTime");
                Console.WriteLine("3. Tong Luong Phai Tra Cho Nhan Vien FullTime");
                Console.WriteLine("4. Tim Kiem Nhan Vien FullTime Theo Ten");
                Console.WriteLine("5. Sap Xep Nhan Vien FullTime Theo Ten");
                Console.WriteLine("6. Thoat");
                Console.Write("Hay nhap lua chon cua ban: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap so luong nhan vien FullTime can them: ");
                        if (!int.TryParse(Console.ReadLine(), out int n))
                        {
                            Console.WriteLine("So luong khong hop le!");
                            break;
                        }
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Nhap thong tin nhan vien FullTime thu {i + 1}:");
                            Console.Write("Nhap ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Nhap Name: ");
                            string Name = Console.ReadLine();
                            Console.Write("Nhap NumberPhone: ");
                            string NumberPhone = Console.ReadLine();
                            Console.Write("Nhap Address: ");
                            string Address = Console.ReadLine();
                            Console.Write("Nhap so ngay da lam viec: ");
                            if (!int.TryParse(Console.ReadLine(), out int NumberWorkday))
                            {
                                Console.WriteLine("Thoi gian khong hop le!");
                                continue;
                            }
                            EmPloyFullTime emp = new EmPloyFullTime(id, Name, NumberPhone, Address, NumberWorkday);
                            listEmPloyFullTime.Add(emp);
                        }
                        break;
                    case 2:
                        displaylistEmPloyFullTime();
                        break;
                    case 3:
                        SalaryFullTime();
                        break;
                    case 4:
                        SearchFullTime();
                        Console.WriteLine("Done!");
                        break;
                    case 5:
                        SapXepTen();
                        break;
                    case 6:
                        Console.WriteLine("Thoat chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Chuc nang khong hop le! Vui long chon lai");
                        break;
                }
            } while (choice != 6);
        }
    }
}