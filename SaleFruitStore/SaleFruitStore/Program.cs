using System;
using System.Linq;
using System.Text;
using SaleFruitStore.Domain;
using SaleFruitStore.Generic;
using SaleFruitStore.Pricing;
using SaleFruitStore.Services;

namespace SaleFruitStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Repo
            var productRepo = new InMemoryRepository<FruitProduct, string>(p => p.ProductId);
            var orderRepo = new InMemoryRepository<Order, string>(o => o.OrderNo);

            // Seed sản phẩm
            var sp1 = new FruitProduct
            {
                Name = "Táo Mỹ",
                Origin = "USA",
                UnitPrice = 120_000,
                StockQty = 50,
                StorageTemp = "0-4°C",
                Description = "Táo đỏ ngọt giòn",
                Category = FruitCategory.Imported,
                ExpiryDate = DateTime.Now.AddDays(30)
            };

            var sp2 = new FruitProduct
            {
                Name = "Cam Úc",
                Origin = "Australia",
                UnitPrice = 150_000,
                StockQty = 40,
                StorageTemp = "0-5°C",
                Description = "Cam vàng mọng nước",
                Category = FruitCategory.Imported,
                ExpiryDate = DateTime.Now.AddDays(8)
            };

            var sp3 = new FruitProduct
            {
                Name = "Xoài Cát",
                Origin = "Việt Nam",
                UnitPrice = 60_000,
                StockQty = 100,
                StorageTemp = "10-15°C",
                Description = "Xoài ngọt thanh",
                Category = FruitCategory.Domestic,
                ExpiryDate = DateTime.Now.AddDays(1)
            };

            var sp4 = new FruitProduct
            {
                Name = "Thanh long",
                Origin = "Việt Nam",
                UnitPrice = 40_000,
                StockQty = 80,
                StorageTemp = "5-10°C",
                Description = "Thanh long ruột trắng",
                Category = FruitCategory.Domestic,
                ExpiryDate = DateTime.Now.AddDays(100)
            };


            productRepo.Add(sp1); productRepo.Add(sp2); productRepo.Add(sp3); productRepo.Add(sp4);

            // Services
            var inventoryService = new InventoryService(productRepo, 20);
            var priceRuleWithPromotion = new Buy10Get1PriceRule(new DefaultPriceRule());


            // Khởi tạo OrderService với InventoryService
            var orderService = new OrderService(orderRepo, productRepo, inventoryService, priceRuleWithPromotion,
                 new NoOrderDiscount(), new VAT(), new SimpleReceiptFormatter());

            // ĐĂNG KÝ EVENT INVENTORY LOW
            inventoryService.InventoryLow += (s, e) =>
                Console.WriteLine($"[EVENT]: {e.Product.Name}, còn {e.CurrentQty}kg");
            // DANG KI EVENT NEARExpiry
            inventoryService.NearExpiry += (s,e) =>
                Console.WriteLine($"[EVENT]: {e.Product.Name} còn hạn đến ngày {e.ExpiryDate}");

            // Khách hàng test: Member
            var customer = new MemberCustomer { FullName = "Anh Tú", Tier = MemberTier.Gold };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== CỬA HÀNG TRÁI CÂY =====");
                Console.WriteLine("1. Trái cây trong nước");
                Console.WriteLine("2. Trái cây nhập khẩu");
                Console.WriteLine("0. Thoát");

                int choiceNum;

                // Logic kiểm tra đầu vào (chọn danh mục)
                while (true)
                {
                    Console.Write("Chọn: ");
                    var choiceStr = Console.ReadLine();
                    if (!int.TryParse(choiceStr, out choiceNum))
                    {
                        Console.WriteLine("Nhập số đừng nhập chữ.");
                        continue;
                    }
                    else if ( choiceNum < 0 || choiceNum > 2)
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập 0, 1 hoặc 2.");
                        continue;
                    }
                    break;
                }

                if (choiceNum == 0) break;

                FruitCategory category = choiceNum == 1 ? FruitCategory.Domestic : FruitCategory.Imported;

                // Lọc sản phẩm CÓ TỒN KHO > 0
                var products = productRepo.GetAll()
                                          .Where(p => p.Category == category && p.StockQty > 0)
                                          .ToList();

                string categoryName = (category == FruitCategory.Domestic) ? "Trái cây Trong nước" : "Trái cây Nhập khẩu";

                Console.WriteLine($"\n--- Danh sách {categoryName} ---");

                if (!products.Any())
                {
                    Console.WriteLine($"\n[INFO] {categoryName} đã hết hàng hoặc không còn sản phẩm có sẵn để bán.");
                    Console.WriteLine("Ấn Enter để quay lại menu chính.");
                    Console.ReadLine();
                    continue;
                }

                for (int i = 0; i < products.Count; i++)
                {
                    var p = products[i];
                    Console.WriteLine($"{i + 1}. {p.Name} ({p.UnitPrice:#,##0}đ/kg) tồn {p.StockQty}kg");
                }

                Console.Write("Chọn sản phẩm (nhập số): ");
                int choiceProd;
                while (!int.TryParse(Console.ReadLine(), out choiceProd) || choiceProd < 1 || choiceProd > products.Count)
                {
                    Console.Write("Lựa chọn không hợp lệ, nhập lại: ");
                }

                var product = products[choiceProd - 1];


                Console.WriteLine($"\nThông tin sản phẩm: {product.Name}");
                Console.WriteLine($"Giá: {product.UnitPrice:#,##0} đ/kg");
                Console.WriteLine($"Tồn kho: {product.StockQty} kg");

                int qty;
                while (true)
                {
                    Console.Write("Nhập số lượng (kg): ");
                    if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
                    {
                        Console.WriteLine("Số lượng không hợp lệ!");
                        continue;
                    }
                    if (qty > product.StockQty)
                    {
                        Console.WriteLine($"Không đủ tồn kho, chỉ còn {product.StockQty}kg!");
                        continue;
                    }
                    break;
                }

                // 1. Tạo đơn hàng (Status: Draft) và thêm OrderLine
                var order = orderService.CreateOrder(customer);
                orderService.AddOrderLine(order, product.ProductId, qty);

                // ĐĂNG KÝ EVENT STATUS CHANGED CHO ĐƠN HÀNG VỪA TẠO
                order.OrderStatusChanged += (s, e) =>
                    Console.WriteLine($"[EVENT] Trạng thái đơn hàng {((Order)s).OrderNo} thay đổi: {e.OldStatus} -> {e.NewStatus}");

                order.RecalcTotals(); // Tính toán để hiện tổng tiền trước khi chốt

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Tạm tính (chưa chiết khấu, chưa VAT): {order.Subtotal:#,##0} đ");
                Console.WriteLine($"Tổng tiền sau CK và VAT: {order.Total:#,##0} đ");
                Console.WriteLine("---------------------------------");

                // 2. LOGIC XÁC NHẬN CHỐT ĐƠN (1: Có, 2: Không)
                int confirmChoice;
                Console.WriteLine("\nXác nhận chốt đơn?");
                Console.WriteLine("1. Có");
                Console.WriteLine("2. Không");

                while (true)
                {
                    Console.Write("Chọn (1 hoặc 2): ");
                    var choiceStr = Console.ReadLine();
                    if (!int.TryParse(choiceStr, out confirmChoice) || (confirmChoice != 1 && confirmChoice != 2))
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        continue;
                    }
                    break;
                }

                if (confirmChoice == 1) // CÓ (Chốt đơn)
                {
                    // Dòng này sẽ bắn EVENT: Draft -> Confirmed VÀ event InventoryLow (nếu cần)
                    orderService.Submit(order);

                    // Dòng này sẽ bắn EVENT: Confirmed -> Paid
                    orderService.Pay(order);
                    // ban event NearExpiry
                    
                    Console.WriteLine("\n===== HÓA ĐƠN ĐÃ THANH TOÁN =====");
                    Console.WriteLine(orderService.PrintReceipt(order));

                    if (customer is MemberCustomer mc)
                        Console.WriteLine($"Điểm tích lũy mới: {mc.Points}");
                }
                else // KHÔNG (Hủy bỏ)
                {
                    Console.WriteLine("Đơn hàng đã bị hủy bỏ.");
                }

                Console.Write("\nTiếp tục mua? (y/n): ");
                var cont = Console.ReadLine();
                if (cont?.ToLower() != "y") break;
            }
        }
    }
}