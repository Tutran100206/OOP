using SaleFruitStore.Domain;
using SaleFruitStore.Pricing;
using System.Text;

public class SimpleReceiptFormatter : IReceiptFormatter
{
    public string Format(Order order)
    {
        var sb = new StringBuilder();
        sb.AppendLine("===== HÓA ĐƠN BÁN TRÁI CÂY =====");
        sb.AppendLine($"Số đơn: {order.OrderNo}");
        sb.AppendLine($"Ngày: {order.OrderDate:dd/MM/yyyy HH:mm}");
        sb.AppendLine($"Khách hàng: {order.Customer.FullName}");
        sb.AppendLine($"Trạng thái: {order.Status}");
        sb.AppendLine("---------------------------------");
        sb.AppendLine($"{"Sản phẩm",-20} {"SL",3} {"Đơn giá",10} {"Giảm%",6} {"Thành tiền",12}");

        foreach (var line in order.Lines)
        {
            sb.AppendLine($"{line.Product.Name,-20} {line.Quantity,3} {line.UnitPrice,10:#,##0} {line.LineDiscountPercent * 100,6:0}% {line.LineAmount(),12:#,##0}");
        }

        sb.AppendLine("---------------------------------");
        sb.AppendLine($"Tạm tính: {order.Subtotal:#,##0} đ");
        sb.AppendLine($"Chiết khấu KH: {order.Customer.GetDiscountPercent(order) * 100:0}%");
        sb.AppendLine($"Chiết khấu đơn: {order.OrderLevelDiscount:#,##0} đ");
        sb.AppendLine($"VAT: {order.VAT:#,##0} đ");
        sb.AppendLine($"TỔNG CỘNG: {order.Total:#,##0} đ");
        sb.AppendLine("=================================");

        return sb.ToString();
    }
}