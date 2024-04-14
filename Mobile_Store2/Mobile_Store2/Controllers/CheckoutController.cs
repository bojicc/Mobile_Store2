using Microsoft.AspNetCore.Mvc;
using Mobile_Store2.Data;

namespace Mobile_Store2.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int orderItem)
        {
            //var cartItem = _context.OrderItems.Find(orderItem);
            //if (cartItem != null)
            //{
            //    cartItem = null;
            //}
            return View();
        }

        public IActionResult Confirm()
        {
            return View();
        }

        public IActionResult Delete(int orderItemId)
        {
            var orderItem = _context.OrderItems.Find(orderItemId);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
            }
            _context.SaveChangesAsync();
            return RedirectToAction("Confirm");
        }
    }
}
