using Microsoft.AspNetCore.Mvc;
using Mobile_Store2.Data.Models;
using Mobile_Store2.Data;
using Mobile_Store2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Mobile_Store2.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            _context = context;
            _userManager = userManager;
            _cartService = cartService;
        }

        private static List<OrderItem> cartItems = new List<OrderItem>();

        public async Task<IActionResult> Index()
        {
            var orderItems = await _context.OrderItems.Include(oi => oi.Phone).ToListAsync();
            return View(orderItems);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(int phoneId, int quantity)
        {
            var user = await _userManager.GetUserAsync(this.User);
            var activeOrder = _context.Orders
               .Include(i => i.OrderItems)
               .FirstOrDefault(i => i.UserId == user.Id);

            if (activeOrder == null)
            {
                activeOrder = new Order
                {
                    UserId = user.Id,
                    CreateDate = DateTime.Now,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(activeOrder);
                await _context.SaveChangesAsync();
            }


            var phone = await _context.Phones.FindAsync(phoneId);
            if (phone == null)
            {
                return NotFound();
            }

            if (quantity <= phone.Quantity)
            {
                var existingCartItem = activeOrder.OrderItems.FirstOrDefault(item => item.PhoneId == phoneId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    activeOrder.OrderItems.Add(new OrderItem { PhoneId = phoneId, Quantity = quantity, Phone = phone });
                    if (quantity > 4)
                    {
                        orderItem.UnitPrice = phone.Price * 0.8; // 20% popust
                    }
                    activeOrder.OrderItems.Add(orderItem);
                }
                //phone.Quantity -= quantity;
                await _context.SaveChangesAsync();

                TempData["CartItemCount"] = _cartService.CartItemCount();
            }
            else
            {
                TempData["ErrorMessage"] = $"There are only {phone.Quantity} phone available.";
                ModelState.AddModelError("quantity", $"There are only {phone.Quantity} phones available.");
                return RedirectToAction("Index", "Shop", new { id = phoneId });
            }

            //if (quantity > phone.Quantity)
            //{
            //    TempData["ErrorMessage"] = "That number of phones are currenty unavailable.";
            //    return RedirectToAction("Index", "Shop", new { id = phoneId });
            //}

            //var orderItem = new OrderItem
            //{
            //    PhoneId = phone.PhoneId,
            //    Quantity = quantity,
            //    UnitPrice = phone.Price,
            //    //Phone = phone
            //};
            //_context.OrderItems.Add(orderItem);
            //await _context.SaveChangesAsync();

            // Calculate the total count of items in the cart
             //ViewData["CartItemCount"] = _cartService.CartItemCount();
            //ViewBag.CartItemCount = _cartService.CartItemCount();

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CheckAvailabilityFromDatabase(int phoneId, int quantity)
        {
            var product = await _context.Phones.FindAsync(phoneId);
            if (product != null && product.Quantity >= quantity)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        public async Task<JsonResult> CheckAvailability(int phoneId, int quantity)
        {
            bool isAvailable = await CheckAvailabilityFromDatabase(phoneId, quantity);
            return Json(new { available = isAvailable });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int orderItemId, int quantity)
        {
            var cartItem = _context.OrderItems.Find(orderItemId);
            await _context.Entry(cartItem).Reference(o => o.Phone).LoadAsync();
            var phone = cartItem.Phone;

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                if (quantity > phone.Quantity)
                {
                    TempData["ErrorMessage"] = "That number of phone are unavailable.";
                    return RedirectToAction("Index", "Cart");
                }

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkAsShipped(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            order.Shipped = true;

            ViewBag.OrderId =  order.OrderId;
            await _context.SaveChangesAsync();
            //return RedirectToAction("Index", "Shop");
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Shop", new { id = order.OrderId });

        }

    }
}
