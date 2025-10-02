using SaleFruitStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Pricing
{
    public interface IReceiptFormatter
    {
        string Format(Order order);
    }
}
