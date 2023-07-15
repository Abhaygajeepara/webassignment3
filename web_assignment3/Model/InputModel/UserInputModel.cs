

namespace web_assignment3.Model
{
    public class UserInputModel
    {

        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string shippingAddress { get; set; }
        public UserInputModel() { }

        public UserInputModel(
            string email, string
             password, string username, string shippingAddress)
        {
            this.email = email;
            this.password = password;
            this.username = username;
            this.shippingAddress = shippingAddress;
        }
    }
}
