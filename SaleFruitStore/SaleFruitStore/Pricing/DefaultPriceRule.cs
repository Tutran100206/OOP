using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFruitStore.Domain;

namespace SaleFruitStore.Pricing
{
    public class DefaultPriceRule : IPriceRule
    {
        public decimal ComputeLineAmount(OrderLine l)
        {
            return l.LineAmount();
        }
    }
}
