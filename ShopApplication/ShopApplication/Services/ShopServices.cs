using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApplication.Models;

namespace ShopApplication.Services
{
    public class ShopServices
    {
        private List<ShopItem> _items;
        public ShopServices ()
        {
            _items = new List<ShopItem> ();
        }
        public void Add (string name, decimal price, int quantity)
        {
            ShopItem shopItem = new ShopItem ();
            {
                shopItem.Name = name;
                shopItem.Price = price;
                shopItem.Quantity = quantity;
            }
            _items.Add (shopItem);
        }
        public void Remove(string name)
        {
            _items = _items.Where(si => si.Name != name).ToList();
        }
        public List<ShopItem> GetAll()
        {
            return _items;
        }
        public void Update (string name, int quantity)
        {
            var item = _items.First(si => si.Name == name);
            item.Quantity = quantity;
        }
    }
}
