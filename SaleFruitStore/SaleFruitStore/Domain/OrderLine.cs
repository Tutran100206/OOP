using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Domain
{
    public class OrderLine
    {
        public FruitProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineDiscountPercent { get; set; }

        public OrderLine(FruitProduct product, int qty, decimal unitPrice, decimal lineDiscount = 0m)
        {
            Product = product;
            Quantity = qty;
            UnitPrice = unitPrice;
            LineDiscountPercent = lineDiscount;
        }

        public decimal LineAmount()
        {
            return Quantity * UnitPrice * (1 - LineDiscountPercent);
        }
    }
}
