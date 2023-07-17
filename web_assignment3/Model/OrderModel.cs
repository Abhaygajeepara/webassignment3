namespace web_assignment3.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderModel() { }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public OrderItem() { }
       
    }

    public class FullOrderModel {
        public OrderModel order { get; set; }
        public List<OrderItem> items { get; set; }

        public FullOrderModel() { } 
    }
}
