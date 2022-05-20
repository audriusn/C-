using Microsoft.AspNetCore.Mvc;
using ShopManagmentApp.Models;
using ShopManagmentApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Controllers
{
    public class ShopItemController : Controller
    {
        private ShopItemService _shopItemService;

       
        public ShopItemController (ShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }

        public IActionResult Index()
        {
            var shopItems = _shopItemService.GetAll();
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
            _shopItemService.Add(shopItem);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string name)
        {
            _shopItemService.Delete(name);
            return RedirectToAction("Index");
        }
       
        public IActionResult Edit (string name)
        {
            var shopItem = _shopItemService.Get(name);
            return View(shopItem);
        }
        [HttpPost]
        public IActionResult Edit (ShopItem shopitem)
        {
            _shopItemService.Update(shopitem);
            return RedirectToAction("Index");
        }

    }
  
}
