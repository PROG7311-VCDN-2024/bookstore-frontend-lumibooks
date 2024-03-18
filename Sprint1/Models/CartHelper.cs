using System.Linq;
using Sprint1.Models;

namespace Sprint1.Helpers
{
    public static class CartHelper
    {
        public static Book GetBookById(int bookId, ApplicationDbContext context)
        {
            return context.Books.FirstOrDefault(b => b.Id == bookId);
        }
    }
}
