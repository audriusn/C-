using Microsoft.AspNetCore.Mvc;
using ShopManagmentApp.Models;
using ShopManagmentApp.Services;

namespace ShopManagmentApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            var shop = _shopService.GetAll();
            return View(shop);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Shop shop= new Shop();
            return View(shop);
        }
        [HttpPost]
        public IActionResult Add(Shop shop)
        {
            _shopService.Add(shop);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string name)
        {
            _shopService.Delete(name);
            return RedirectToAction("Index");
        }
    }

}

