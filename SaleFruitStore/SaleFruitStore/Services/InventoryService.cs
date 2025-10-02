using SaleFruitStore.Domain;
using SaleFruitStore.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Services
{
    public class InventoryService
    {
        private readonly IRepository<FruitProduct, string> _productRepo;

        // Ngưỡng cảnh báo (ví dụ dưới 20kg thì báo Low stock)
        private readonly int _reorderThreshold;

        public event EventHandler<InventoryLowEventArgs> InventoryLow;

        public event NearExpiryHandler NearExpiry;

        private const int ExpiryWarningDays = 7; // Cảnh báo khi còn 7 ngày nữa là hết hạn
     
        public void CheckNearExpiry(FruitProduct product)
        {
            // Cảnh báo nếu hạn sử dụng nhỏ hơn hoặc bằng 7 ngày kể từ hôm nay
            if (product.ExpiryDate != default(DateTime) && product.ExpiryDate <= DateTime.Now.AddDays(ExpiryWarningDays))
            {
                // Kích hoạt sự kiện Near Expiry
                NearExpiry?.Invoke(this, new NearExpiryEventArgs(product, product.ExpiryDate));
            }
        }

        public InventoryService(IRepository<FruitProduct, string> productRepo, int reorderThreshold = 20)
        {
            _productRepo = productRepo;
            _reorderThreshold = reorderThreshold;
        }
        public void DeductStock(string productId, int qty)
        {
            var product = _productRepo.GetById(productId)
                ?? throw new InvalidOperationException($"Không tìm thấy sản phẩm {productId}");

            if (qty <= 0) throw new ArgumentException("Số lượng mua phải > 0");

            if (product.StockQty < qty)throw new InvalidOperationException($"Kho không đủ. Hiện còn {product.StockQty}, yêu cầu {qty}");

            product.StockQty -= qty;
            _productRepo.Update(product);

            if (product.StockQty < _reorderThreshold) InventoryLow?.Invoke(this, new InventoryLowEventArgs(product, product.StockQty));
            CheckNearExpiry(product);
        }
        public void Restock(string productId, int qty)
        {
            var product = _productRepo.GetById(productId) ?? throw new InvalidOperationException($"Không tìm thấy sản phẩm {productId}");

            if (qty <= 0) throw new ArgumentException("Số lượng hoàn kho phải > 0");

            product.StockQty += qty;
            _productRepo.Update(product);
        }
    }
}
