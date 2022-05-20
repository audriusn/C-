using System;

namespace ShopManagmentApp.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ShopName { get; set; }

        public DateTime ExpireDate { get; set; }
        public Shop Shop { get; set; }

        public int? ShopId { get; set; }
    }
}
