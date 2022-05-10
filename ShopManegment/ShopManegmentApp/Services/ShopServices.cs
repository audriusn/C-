﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManegmentApp.Models;

namespace ShopManegmentApp.Services
{
    public class ShopServices
    {
        private List<ShopItem> _items;
        public ShopServices()
        {
            _items = new List<ShopItem>();
        }
        public void Add(string name, string qty)
        {
            var item = new ShopItem()
            {
                Name = name,
                Qty = qty
            };

            _items.Add(item);
        }
        public void Remove(string name)
        {
            _items = _items.Where(i => i.Name != name).ToList();
        }
        public List<ShopItem> GetAll()
        {
            return _items;
        }
    }
}
