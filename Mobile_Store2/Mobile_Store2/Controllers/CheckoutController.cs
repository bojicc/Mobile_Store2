using Microsoft.AspNetCore.Mvc;

namespace Mobile_Store2.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}
