using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Domain
{
    // 1) OderStatus
    public class OrderStatusChangedEventArgs : EventArgs
    {
        public OrderStatus OldStatus { get; }
        public OrderStatus NewStatus { get; }
        public OrderStatusChangedEventArgs(OrderStatus oldStatus, OrderStatus newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
    public delegate void OrderStatusChangedHandler(object sender, OrderStatusChangedEventArgs e);

    // 2) Inventory low
    public class InventoryLowEventArgs : EventArgs
    {
        public FruitProduct Product { get; }
        public int CurrentQty { get; }
        public InventoryLowEventArgs(FruitProduct product, int qty)
        {
            Product = product;
            CurrentQty = qty;
        }
    }
    public delegate void InventoryLowHandler(object sender, InventoryLowEventArgs e);

    // 3) Near expiry
    public class NearExpiryEventArgs : EventArgs
    {
        public FruitProduct Product { get; }
        public DateTime ExpiryDate { get; }
        public NearExpiryEventArgs(FruitProduct product, DateTime expiry)
        {
            Product = product;
            ExpiryDate = expiry;
        }
    }
    public delegate void NearExpiryHandler(object sender, NearExpiryEventArgs e);

    // 4) Points accrued
    public class PointsAccruedEventArgs : EventArgs
    {
        public string CustomerId { get; }
        public string CustomerName { get; }
        public int PointsAdded { get; }
        public int NewPoints { get; }
        public PointsAccruedEventArgs(string customerId, string customerName, int added, int newPoints)
        {
            CustomerId = customerId; CustomerName = customerName;
            PointsAdded = added; NewPoints = newPoints;
        }
    }
    public delegate void PointsAccruedHandler(object sender, PointsAccruedEventArgs e);
}
