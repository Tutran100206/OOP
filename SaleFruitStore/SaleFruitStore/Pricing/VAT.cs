using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Pricing
{
    public class VAT : ITaxCalculator
    {
        public decimal ComputeTax(decimal taxableAmount)
        {
            // Làm tròn đơn giản về đơn vị đồng
            return Math.Round(taxableAmount * 0.08m, 0, MidpointRounding.AwayFromZero);
        }
    }
}
