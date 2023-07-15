
namespace web_assignment3.Model
{
    public class ProductInputModel
    {
        public string description { get; set; }
        public string image { get; set; }
        public decimal pricing { get; set; }
        public decimal shippingCost { get; set; }

        public ProductInputModel() { }
        public ProductInputModel(
            string description, string
             image, decimal pricing, decimal shippingCost)
        {
            this.description  = description;
            this.image = image;
            this.pricing = pricing;
            this.shippingCost = shippingCost;
            
        }
    }
}
