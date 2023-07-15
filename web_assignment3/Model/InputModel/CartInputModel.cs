namespace web_assignment3.Model.InputModel
{
    public class CartInputModel
    {
        public int productId { get; set; }
        public int userId { get; set; }
        public int quantity { get; set; }
        public CartInputModel() { }
        public CartInputModel(int productId, int userId, int quantity)
        {
            this.productId = productId;
            this.userId = userId;
            this.quantity = quantity;
        }
    }
}
