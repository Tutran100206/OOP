using System;

namespace MoHinhNhanVien
{
    public class EmPloyFullTime
    {
        private string id;
        private string Name;
        private string NumberPhone;
        private double Salary;
        private string Address;
        private int NumberWorkday;
        public EmPloyFullTime()
        {
        }

        public EmPloyFullTime(string id, string Name, string NumberPhone, string Address, int NumberWorkday)
        {
            this.id = id;
            this.Name = Name;
            this.NumberPhone = NumberPhone;
            this.Address = Address;
            this.NumberWorkday = NumberWorkday;
        }
        public string getId()
        {
            return id;
        }

        public void setId(string id)
        {
            this.id = id;
        }
        public string getName()
        {
            return Name;
        }
        public void setName(string Name)
        {
            this.Name = Name;
        }
        public string getNumberPhone()
        {
            return NumberPhone;
        }
        public void setNumberPhone(string NumberPhone)
        {
            this.NumberPhone = NumberPhone;
        }
        public string getAddress()
        {
            return Address;
        }
        public void setAddress(string Address)
        {
            this.Address = Address;
        }
        public int getNumberWorkday()
        {
            return NumberWorkday;
        }
        public void setNumberWorkday(int TimeHours)
        {
            this.NumberWorkday = NumberWorkday;
        }
        public double getSalary()
        {
            return NumberWorkday * 1500000;
        }
        public void setSalary(double Salary)
        {
            this.Salary = Salary;
        }
        
        public void display()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"NumberPhone: {NumberPhone}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Salary: {getSalary():F2}");
            Console.WriteLine($"NumberWorkday: {NumberWorkday}");
        }
    }
}