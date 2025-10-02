using SaleFruitStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Pricing
{
    public class NoOrderDiscount : IOrderDiscountPolicy
    {
        public decimal ComputeOrderLevelDiscount(Order order)
        {
            return 0m;
        }
    }
}
