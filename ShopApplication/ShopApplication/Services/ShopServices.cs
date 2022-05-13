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
        private List<ShopItem> _cart;
        private Customer _customer =  new Customer();
        public ShopServices ()
        {
            _items = new List<ShopItem> ();
            _cart = new List<ShopItem>();
        }
        public void Add (string name, int quantity, decimal price)
        {
            var item = new ShopItem ();
            {
                item.Name = name;
                item.Quantity = quantity;
                item.Price = price;
            }
            bool doesExist = !_items.Any(i => i.Name == name);
            if (doesExist)
                _items.Add(item);
            else
                Console.WriteLine("This item is already in list.");
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
        public void Buy (string name, int quantity)  
        {
            try
            {          
                var item = _items.First(i => i.Name == name);
                if (item.Quantity >= quantity)
                {
                    if (item.Price * quantity <= _customer.Wallet)
                    {
                        item.Quantity -= quantity;
                        _customer.Wallet -= (item.Price * quantity);
                        _cart.Add(item);
                    }
                    else
                    {
                        Console.WriteLine("Customer does not have enough funds");
                    }
                }
                else
                {
                    Console.WriteLine("Shop does not have enaugth units");
                }
            }
          catch (Exception )
            {
                Console.WriteLine("Shop item is not found");
            }          
        }     
        public decimal CustomerBalance()
        {
            return _customer.Wallet;
        }
        public void Topup(decimal addmoney)
        {
            _customer.Wallet += addmoney;
        }
        public List<ShopItem> GetCart()
        {
            return _cart;
        }

    }
}
