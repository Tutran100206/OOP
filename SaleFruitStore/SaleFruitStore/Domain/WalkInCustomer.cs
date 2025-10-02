using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Domain
{
    public class WalkInCustomer : Customer // khách vãng lai => 0%
    {
        public override decimal GetDiscountPercent(Order order)
        {
            return 0m;
        }
    }

}
