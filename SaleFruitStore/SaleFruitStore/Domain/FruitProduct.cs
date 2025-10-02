using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Domain
{
    public class FruitProduct
    {
            public string ProductId { get; set; } = Guid.NewGuid().ToString();
            public string Name { get; set; } = "";
            public FruitCategory Category { get; set; }
            public string Origin { get; set; } = "";
            public string StorageTemp { get; set; } = "";
            public string Description { get; set; } = "";   // Đặc điểm nổi bật
            public string StorageInfo { get; set; } = "";   // Cách bảo quản
            public decimal UnitPrice { get; set; }          // Giá theo kg
            public int StockQty { get; set; }               // Số lượng tồn kho (kg)
            public DateTime ExpiryDate { get; set; }        // Ngày hết hạn
            public bool IsActive { get; set; } = true;      // Còn kinh doanh hay không
    }
}
