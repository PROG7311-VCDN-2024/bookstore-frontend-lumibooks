using Sprint1.Models;
using System;

namespace Sprint1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public UserModel User { get; set; } 

        public int BookId { get; set; } 
        public Book Book { get; set; } 

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
