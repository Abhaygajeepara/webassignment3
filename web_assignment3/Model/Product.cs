using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_assignment3.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string description { get; set; }

        public string image { get; set; }
        public decimal pricing { get; set; }
        public decimal shippingCost { get; set; }
    }
}
