using Microsoft.AspNetCore.Mvc;
using ShopManagmentApp.Models;
using ShopManagmentApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Controllers
{
    public class ShopController : Controller
    {
        private ShopService _shopService;

        private List<ShopItem> _shopItem = new List<ShopItem>
        {

        };
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
            ShopItem shopItem = new ShopItem(); 
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
       
        public IActionResult Edit (string name)
        {
            var shopItem = _shopService.Get(name);
            return View(shopItem);
        }
        [HttpPost]
        public IActionResult Edit (ShopItem shopitem)
        {
            _shopService.Update(shopitem);
            return RedirectToAction("Index");
        }

    }
  
}
