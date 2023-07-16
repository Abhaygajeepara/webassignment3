namespace web_assignment3.Model.InputModel
{
    public class OrderInputModel
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public string Items { get; set; }

        public OrderInputModel() { }
        public OrderInputModel(int userId, decimal totalAmount, string shippingAddress, string items)
        {
            UserId = userId;
            TotalAmount = totalAmount;
            ShippingAddress = shippingAddress;
            Items = items;
        }
    }
}
