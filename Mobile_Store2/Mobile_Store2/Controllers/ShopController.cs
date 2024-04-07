using Microsoft.AspNetCore.Mvc;
using Mobile_Store2.Data.Repositories;
using Mobile_Store2.Services.Interfaces;

namespace Mobile_Store2.Controllers
{
    public class ShopController : Controller
    {
        private readonly IPhoneService _phoneService;

        public ShopController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public IActionResult Index()
        {
            var phones = _phoneService.GetAllPhones();
            return View(phones);
        }

        public IActionResult Details(int id)
        {
            var phone = _phoneService.GetPhoneById(id);
            if (phone == null)
                return NotFound();

            return View(phone);
        }
    }
}
