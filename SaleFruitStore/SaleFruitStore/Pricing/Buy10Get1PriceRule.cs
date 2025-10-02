using SaleFruitStore.Domain;
using System;

namespace SaleFruitStore.Pricing
{
    // Khuyến mãi mua 10 tặng 1 (thanh toán 10/11 số lượng)
    public class Buy10Get1PriceRule : IPriceRule
    {
        private readonly IPriceRule _baseRule;
        private const int PayQuantity = 10;
        private const int FreeQuantity = 1;
        private const int BlockSize = PayQuantity + FreeQuantity; // = 11

        public Buy10Get1PriceRule(IPriceRule baseRule)
        {
            // Nhận một baseRule để có thể mở rộng (ví dụ: DefaultPriceRule)
            _baseRule = baseRule;
        }

        public decimal ComputeLineAmount(OrderLine l)
        {
            // 1. Tính toán số lượng trả tiền
            int totalQty = l.Quantity;

            // Số lượng được miễn phí: 11kg -> 1kg miễn phí, 22kg -> 2kg miễn phí
            int freeQty = totalQty / BlockSize;
            int paidQty = totalQty - freeQty;

            // 2. Tính toán số tiền thực tế (chỉ tính trên số lượng trả tiền)
            // Giữ nguyên LineDiscountPercent (chiết khấu KH) nếu có
            decimal paidAmount = paidQty * l.UnitPrice * (1 - l.LineDiscountPercent);

            return paidAmount;
        }
    }
}