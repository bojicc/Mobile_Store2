using Microsoft.AspNetCore.Mvc;
using Mobile_Store2.Data.Models;
using Mobile_Store2.Services.Interfaces;

namespace Mobile_Store2.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;

        public CheckoutController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
             var checkoutModel = new CheckoutViewModel();
            return View(checkoutModel);
        }

        [HttpPost]
        //public IActionResult ProcessOrder(OrderViewModel orderViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View("Index", orderViewModel);

        //    _orderService.ProcessOrder(orderViewModel);
        //    return RedirectToAction("OrderConfirmation");
        //}

        public IActionResult ProcessOrder(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var order = new Order
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                ZipCode = model.ZipCode,
                City = model.City,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            _orderService.ProcessOrder(order);
            return RedirectToAction("OrderConfirmation");
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
