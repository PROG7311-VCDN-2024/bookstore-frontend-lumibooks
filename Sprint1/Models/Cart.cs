using System.Collections.Generic;

namespace Sprint1.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }

        public List<CartItem> CartItems { get; set; } // Updated property name
    }
}
