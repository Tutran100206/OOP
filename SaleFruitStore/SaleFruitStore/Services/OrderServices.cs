using System;
using SaleFruitStore.Domain;
using SaleFruitStore.Generic;
using SaleFruitStore.Pricing;
using SaleFruitStore.Services; // <-- QUAN TRỌNG: Thêm using này

namespace SaleFruitStore.Services
{
    public class OrderService
    {
        private readonly IRepository<Order, string> _orderRepo;
        private readonly IRepository<FruitProduct, string> _productRepo;
        private readonly IPriceRule _priceRule;
        private readonly IOrderDiscountPolicy _orderDiscount;
        private readonly ITaxCalculator _tax;
        private readonly IReceiptFormatter _receiptFormatter;
        private readonly InventoryService _inventoryService; // <-- THÊM TRƯỜNG NÀY

        public OrderService(
            IRepository<Order, string> orderRepo,
            IRepository<FruitProduct, string> productRepo,
            InventoryService inventoryService, // <-- THÊM THAM SỐ VÀO CONSTRUCTOR
            IPriceRule priceRule,
            IOrderDiscountPolicy orderDiscount,
            ITaxCalculator tax,
            IReceiptFormatter receiptFormatter)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _inventoryService = inventoryService; // <-- GÁN GIÁ TRỊ
            _priceRule = priceRule;
            _orderDiscount = orderDiscount;
            _tax = tax;
            _receiptFormatter = receiptFormatter;
        }

        public Order CreateOrder(Customer customer) => new Order(customer, _priceRule, _orderDiscount, _tax);

        public void AddOrderLine(Order order, string productId, int qty, decimal discount = 0m)
        {
            var product = _productRepo.GetById(productId)
                ?? throw new InvalidOperationException($"Không tìm thấy sản phẩm {productId}");

            order.AddLine(product, qty, discount);
            order.RecalcTotals();
        }

        public void Submit(Order order)
        {
            // SỬ DỤNG InventoryService để trừ tồn kho (sẽ bắn sự kiện cảnh báo)
            foreach (var line in order.Lines)
            {
                // Gọi DeductStock để trừ và kích hoạt cảnh báo (InventoryLow)
                _inventoryService.DeductStock(line.Product.ProductId, line.Quantity);
            }
            order.Confirm();
            order.RecalcTotals();
        }
        public void Pay(Order order)
        {
            order.Pay();
            order.RecalcTotals();
            _orderRepo.Add(order); // Lưu đơn hàng sau khi Pay
        }
        public void Cancel(Order order)
        {
            order.Cancel();
            order.RecalcTotals();
        }
        public string PrintReceipt(Order order)
        {
           return _receiptFormatter.Format(order);
        }
        public void SaveOrder(Order order)
        {
            _orderRepo.Add(order);
        }
    }
}