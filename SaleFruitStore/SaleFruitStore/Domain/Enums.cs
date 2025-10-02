using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Domain
{
    public enum FruitCategory { Domestic, Imported} // trong nước và ngoài nước
    public enum OrderStatus { Draft, Confirmed, Paid, Cancelled } // tạo, xác nhận, thanh toán, hủy
    public enum MemberTier { Standard, Silver, Gold, Platinum } // liệt kê các loại khách hàng
}
