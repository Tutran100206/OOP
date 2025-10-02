using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFruitStore.Domain;

namespace SaleFruitStore.Pricing
{
    public interface IPriceRule
    {
        decimal ComputeLineAmount(OrderLine line);
    }
}

