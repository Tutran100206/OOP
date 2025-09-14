using System;
using System.Collections.Generic;

namespace MoHinhNhanVien
{
    public class ManagerPartTime
    {
        private List<EmPloyPartTime> listEmPloyPartTime = new List<EmPloyPartTime>();

        public List<EmPloyPartTime> getListEmPloyPartTime()
        {
            return listEmPloyPartTime;
        }

        public void SetListEmPloyPartTime(List<EmPloyPartTime> listEmPloyPartTime)
        {
            this.listEmPloyPartTime = listEmPloyPartTime;
        }
        public void displaylistEmPloyPartTime()
        {
            Console.WriteLine("------------Danh sach nhan vien PartTime------------");
            if (listEmPloyPartTime.Count == 0)
            {
                Console.WriteLine("Khong co nhan vien PartTime nao!");
                return;
            }
            for (int i = 0; i < listEmPloyPartTime.Count; i++)
            {
                listEmPloyPartTime[i].display();
            }
        }
        public void SalaryPartTime()
        {
            double total = 0;
            for (int i = 0; i < listEmPloyPartTime.Count; i++)
            {
                total += listEmPloyPartTime[i].getSalary();
            }
            Console.WriteLine($"Tong luong phai tra cho nhan vien PartTime: {total:F2}");
        }
    public void SearchPartTime()
        {
            Console.Write("Nhap ten nhan vien can tim: ");
            string name = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < listEmPloyPartTime.Count; i++)
            {
                if (listEmPloyPartTime[i].getName().Contains(name))
                {
                    listEmPloyPartTime[i].display();
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
            for (int i = 0; i < listEmPloyPartTime.Count - 1; i++)
            {
                for (int j = i + 1; j < listEmPloyPartTime.Count; j++)
                {
                    if (String.Compare(listEmPloyPartTime[i].getName(), listEmPloyPartTime[j].getName()) > 0)
                    {
                        EmPloyPartTime temp = listEmPloyPartTime[i];
                        listEmPloyPartTime[i] = listEmPloyPartTime[j];
                        listEmPloyPartTime[j] = temp;
                    }
                }
            }
        }
        public void RunPartTime()
        {
            int choice;
            do
            {
                Console.WriteLine("------------Menu quan ly nhan vien PartTime------------");
                Console.WriteLine("1. Nhap Thong Tin Nhan Vien PartTime");
                Console.WriteLine("2. Hien Thi Danh Sach Nhan Vien PartTime");
                Console.WriteLine("3. Tong Luong Phai Tra Cho Nhan Vien PartTime");
                Console.WriteLine("4. Tim Kiem Nhan Vien PartTime Theo Ten");
                Console.WriteLine("5. Sap Xep Nhan Vien PartTime Theo Ten");
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
                        Console.Write("Nhap so luong nhan vien PartTime can them: ");
                        if (!int.TryParse(Console.ReadLine(), out int n))
                        {
                            Console.WriteLine("So luong khong hop le!");
                            break;
                        }
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Nhap thong tin nhan vien PartTime thu {i + 1}:");
                            Console.Write("Nhap ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Nhap Name: ");
                            string Name = Console.ReadLine();
                            Console.Write("Nhap NumberPhone: ");
                            string NumberPhone = Console.ReadLine();
                            Console.Write("Nhap Address: ");
                            string Address = Console.ReadLine();
                            Console.Write("Nhap TimeHours: ");
                            if (!int.TryParse(Console.ReadLine(), out int TimeHours))
                            {
                                Console.WriteLine("Thoi gian khong hop le!");
                                continue;
                            }
                            EmPloyPartTime emp = new EmPloyPartTime(id, Name, NumberPhone, Address, TimeHours);
                            listEmPloyPartTime.Add(emp);
                        }
                        break;
                    case 2:
                        displaylistEmPloyPartTime();
                        break;
                    case 3:
                        SalaryPartTime();
                        break;
                    case 4:
                        SearchPartTime();
                        Console.WriteLine("Done!");
                        break;
                    case 5:
                        SapXepTen();
                        Console.WriteLine("Da sap xep xong!");
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