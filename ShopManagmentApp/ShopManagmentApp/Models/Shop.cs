using System.Collections.Generic;

namespace ShopManagmentApp.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }

        public List<ShopItem> ShopItems { get; set;}
    }
}
