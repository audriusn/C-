using Microsoft.AspNetCore.Mvc;
using ShopManagmentApp.Dtos;
using ShopManagmentApp.Models;
using ShopManagmentApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Controllers
{
    public class ShopItemController : Controller
    {
        private ShopItemService _shopItemService;
        private ShopService _shopService;

       
        public ShopItemController (ShopItemService shopItemService, ShopService shopService)
        {
            _shopItemService = shopItemService;
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            var shopItems = _shopItemService.GetAll();
            return View(shopItems);
        }
        [HttpGet]
        public IActionResult Add()
        {
            CreateShopItemDto shopItem = new CreateShopItemDto(); 
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
