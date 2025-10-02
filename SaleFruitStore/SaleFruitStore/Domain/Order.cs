using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFruitStore.Pricing;
namespace SaleFruitStore.Domain
{
    public class Order
    {
        public string OrderNo { get; set; } = Guid.NewGuid().ToString();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Draft;

        public List<OrderLine> Lines { get; private set; } = new List<OrderLine>();

        public decimal Subtotal { get; private set; }
        public decimal CustomerDiscount { get; private set; }
        public decimal OrderLevelDiscount { get; private set; }
        public decimal VAT { get; private set; }
        public decimal Total { get; private set; }

        // Strategy
        private readonly Pricing.IPriceRule _priceRule;
        private readonly IOrderDiscountPolicy _orderDiscount;
        private readonly ITaxCalculator _tax;

        // Events
        public event EventHandler<OrderStatusChangedEventArgs> OrderStatusChanged;
        public event EventHandler<PointsAccruedEventArgs> PointsAccrued;

        public Order(Customer customer,
                     IPriceRule priceRule,
                     IOrderDiscountPolicy orderDiscount,
                     ITaxCalculator tax)
        {
            Customer = customer;
            _priceRule = priceRule;
            _orderDiscount = orderDiscount;
            _tax = tax;
        }

        public void AddLine(FruitProduct product, int qty, decimal discount = 0m)
        {
            if (qty <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.");
            if (qty > product.StockQty) throw new InvalidOperationException("Không đủ tồn kho.");

            var line = new OrderLine(product, qty, product.UnitPrice, discount);
            Lines.Add(line);

        }

        public void RecalcTotals()
        {
            Subtotal = Lines.Sum(l => _priceRule.ComputeLineAmount(l));
            CustomerDiscount = Subtotal * Customer.GetDiscountPercent(this);
            OrderLevelDiscount = _orderDiscount.ComputeOrderLevelDiscount(this);

            var taxable = Subtotal - CustomerDiscount - OrderLevelDiscount;
            VAT = _tax.ComputeTax(taxable);
            Total = taxable + VAT;
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            var old = Status;
            Status = newStatus;
            OrderStatusChanged?.Invoke(this, new OrderStatusChangedEventArgs(old, newStatus));
        }

        public void Confirm()
        {
            if (Status != OrderStatus.Draft)
                throw new InvalidOperationException("Chỉ có thể Confirm từ Draft.");

            ChangeStatus(OrderStatus.Confirmed);
        }

        public void Pay()
        {
            if (Status != OrderStatus.Confirmed)
                throw new InvalidOperationException("Chỉ có thể Pay sau Confirm.");

            ChangeStatus(OrderStatus.Paid);

            if (Customer is MemberCustomer mc)
            {
                int added = (int)Math.Floor((Subtotal - CustomerDiscount - OrderLevelDiscount) / 100000);
                mc.Points += added;
                PointsAccrued?.Invoke(this, new PointsAccruedEventArgs(mc.CustomerId, mc.FullName, added, mc.Points));
            }
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Paid)
                throw new InvalidOperationException("Không thể Cancel đơn đã thanh toán.");

            ChangeStatus(OrderStatus.Cancelled);

            // Hoàn kho
            foreach (var line in Lines)
            {
                line.Product.StockQty += line.Quantity;
            }
        }
    }
}
