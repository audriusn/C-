using ShopManagmentApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Services
{
    public class ShopService
    {
        public ShopService()
        {

        }
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

        public void Delete(string name)
        {
            _shopItem = _shopItem.Where(t => t.Name != name).ToList();
        }
    }


}

