using ShopManagmentApp.Models;
using System;
using System.Collections.Generic;


namespace ShopManagmentApp.Dtos
{
    public class CreateShopItemDto
    {
        public ShopItem ShopItem { get; set; }
        public  List<Shop> Shops { get; set; }
    }
}
