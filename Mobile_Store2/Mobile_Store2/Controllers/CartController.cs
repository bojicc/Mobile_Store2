using Microsoft.AspNetCore.Mvc;
using Mobile_Store2.Services.Interfaces;

namespace Mobile_Store2.Controllers
{
    //public class CartController : Controller
    //{
    //    private readonly ICartService _cartService;
    //    private readonly IPhoneService _phoneService;

    //    public CartController(ICartService cartService, IPhoneService phoneService)
    //    {
    //        _cartService = cartService;
    //        _phoneService = phoneService;
    //    }

    //    public IActionResult Index()
    //    {
    //        var cartItems = _cartService.GetCartItems();
    //        return View(cartItems);
    //    }

    //    [HttpPost]
    //    public IActionResult AddToCart(int id)
    //    {
    //        var phone = _phoneService.GetPhoneById(id);
    //        if (phone == null)
    //        {
    //            return NotFound();
    //        }
    //        _cartService.AddToCart(phone);
    //        return RedirectToAction("Index");
    //    }

    //    [HttpPost]
    //    public IActionResult RemoveFromCart(int id)
    //    {
    //        _cartService.RemoveFromCart(id);
    //        return RedirectToAction("Index");
    //    }
    //}
}
