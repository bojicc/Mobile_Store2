using Microsoft.AspNetCore.Mvc;
using Mobile_Store2.Data.Repositories;
using Mobile_Store2.Services.Interfaces;

namespace Mobile_Store2.Controllers
{
    public class ShopController : Controller
    {
        private readonly IPhoneRepository _phoneRepository;

        public ShopController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public IActionResult Index()
        {
            var phones = _phoneRepository.GetAllPhones();
            return View(phones);
        }

        public IActionResult Details(int id)
        {
            var phone = _phoneRepository.GetPhoneById(id);
            if (phone == null)
                return NotFound();

            return View(phone);
        }

    }
}
