using Mobile_Store2.Data;
using Mobile_Store2.Services.Interfaces;

namespace Mobile_Store2.Services.Implementations
{
    public class CartService : ICartService

    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CartItemCount()
        {
            return _context.OrderItems.Sum(item => item.Quantity);
        }
    }
}
