using ShopManagmentApp.Data;
using ShopManagmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Services
{
    public class ShopItemService
    {
        private DataContext _dataContext;

        public ShopItemService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
 
        public List<ShopItem> GetAll()
        {           
            return _dataContext.ShopItems.ToList();
        }

        public void Add(ShopItem shopItem)
        {
            _dataContext.ShopItems.Add(shopItem);
            _dataContext.SaveChanges();
        }
        public ShopItem Get(string name)
        {
            return _dataContext.ShopItems.FirstOrDefault(x => x.Name == name);
        }

        public void Delete(string name)
        {
            var item = _dataContext.ShopItems.FirstOrDefault(y => y.Name == name);
            _dataContext.ShopItems.Remove(item);
            _dataContext.SaveChanges();
        }
        public void Update(ShopItem shopItem)
        {
            var item = Get(shopItem.Name);
            item.Name = shopItem.Name;
            item.ShopName = shopItem.ShopName;
            item.ExpireDate = shopItem.ExpireDate;
            _dataContext.SaveChanges();  
        }
    }


}

