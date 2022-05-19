using ShopManagmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Services
{
    public class ShopService
    {
      
        private List<ShopItem> _shopItem = new List<ShopItem>()
        {

             new ShopItem()
            {
                Name = "Cola",
                ShopName = "IKI",
                ExpireDate = System.DateTime.Today
            }
        };
        public List<ShopItem> GetAll()
        {
            return _shopItem;
        }

        public void Add(ShopItem shopItem)
        {
            _shopItem.Add(shopItem);
        }
        public ShopItem Get(string name)
        {
            return _shopItem.FirstOrDefault(x => x.Name == name);
        }

        public void Delete(string name)
        {
            _shopItem = _shopItem.Where(t => t.Name != name).ToList();
        }
        public void Update(ShopItem shopItem)
        {
            var item = Get(shopItem.Name);
            item.Name = shopItem.Name;
            item.ShopName = shopItem.ShopName;
            item.ExpireDate = shopItem.ExpireDate;
        }
    }


}

