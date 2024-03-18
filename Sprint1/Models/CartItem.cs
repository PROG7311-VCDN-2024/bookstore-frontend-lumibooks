namespace Sprint1.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        // Navigation property for the Book entity
        public Book Book { get; set; }
    }
}
