using System.ComponentModel.DataAnnotations;

namespace web_assignment3.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string shippingAddress { get; set; }
    }
}
