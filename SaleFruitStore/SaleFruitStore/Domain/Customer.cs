using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Domain
{
    public abstract class Customer
    {
        public string CustomerId { get; set; } = System.Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Phone { get; set; }
        public abstract decimal GetDiscountPercent(Order order);
    }
}
