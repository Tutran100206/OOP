using System;

namespace MoHinhNhanVien
{
    public class EmPloyPartTime
    {
        private string id;
        private string Name;
        private string NumberPhone;
        private double Salary;
        private string Address;
        private int TimeHours;
        public EmPloyPartTime()
        {
        }

        public EmPloyPartTime(string id, string Name, string NumberPhone, string Address, int TimeHours)
        {
            this.id = id;
            this.Name = Name;
            this.NumberPhone = NumberPhone;
            this.Address = Address;
            this.TimeHours = TimeHours;
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
        public int getTimeHours()
        {
            return TimeHours;
        }
        public void setTimeHours(int TimeHours)
        {
            this.TimeHours = TimeHours;
        }
        public double getSalary()
        {
            return TimeHours*120000;
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
            Console.WriteLine($"TimeHours: {TimeHours}");
        }
    }
}