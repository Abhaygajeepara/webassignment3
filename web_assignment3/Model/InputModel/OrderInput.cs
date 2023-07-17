namespace web_assignment3.Model.InputModel
{
    public class OrderInput
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public List<string> Items { get; set; }

        public OrderInput() { }

        public OrderInput(int id, int userId, decimal totalAmount, string shippingAddress, List<string> items)
        {
            Id = id;
            UserId = userId;
            TotalAmount = totalAmount;
            ShippingAddress = shippingAddress;
            Items = items;
        }
    }
}
