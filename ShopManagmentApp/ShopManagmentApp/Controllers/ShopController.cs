using Microsoft.AspNetCore.Mvc;
using ShopManagmentApp.Models;
using ShopManagmentApp.Services;

namespace ShopManagmentApp.Controllers
{
    public class ShopController : Controller
    {
        private ShopService _shopService;

        public ShopController (ShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            var shopItems = _shopService.GetAll();
            return View(shopItems);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ShopItem shopItem = new ShopItem(); //Passing empty model
            return View(shopItem);
        }
        [HttpPost]
        public IActionResult Add(ShopItem shopItem)
        {
            _shopService.Add(shopItem);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string name)
        {
            _shopService.Delete(name);
            return RedirectToAction("Index");
        }
    }
}
