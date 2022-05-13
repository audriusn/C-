// See https://aka.ms/new-console-template for more information
using ShopItemList.Models;
Console.WriteLine("Hello, World!");
List<ShopItem> shopItems = new List<ShopItem>();

shopItems.Add(new ShopItem()
{
    Name = "Ice Cream",
    Price = 2.2M,
    Quantity = 10
});
shopItems.Add(new ShopItem()
{
    Name = "Candy",
    Price = 0.9M,
    Quantity = 3
});
shopItems.Add(new ShopItem()
{
    Name = "Cake",
    Price = 15.0M,
    Quantity = 3
});
shopItems.Add(new ShopItem()
{
    Name = "Expired Sandwitch",
    Price = 3.0M,
    Quantity = 3,
    Expired = true
}); 
shopItems.Add(new ShopItem()
{
    Name = "Expired Sandwitch",
    Price = 3.0M,
    Quantity = 3,
    Expired = true
}); ;
// You cannot simply pritn complex objects

//Console.WriteLine(shopItems);
//foreach ( ShopItem item in shopItems)
//{
//    Console.WriteLine($"{item.Name} {item.Quantity}" );
//}
////Using linq
//shopItems.ForEach(item => Console.WriteLine($"{item.Name} {item.Quantity}"));

//filtered
//Filter not Expired
//List<ShopItem> notExpiredShopItemsWirhLinq = shopItems.Where(item => item.Expired == false).ToList();

//notExpiredShopItemsWirhLinq.ForEach(item => Console.WriteLine($"{item.Name} {item.Quantity}"));


//Select
//unique 
//List<string> uniqueNames = new List<string>();
//foreach (ShopItem item in shopItems)
//{
//    var uniqueName = item.Name;
//    if(uniqueNames.Contains(uniqueName))
//    {
//        uniqueNames.Add(uniqueName);
//    }
//}

//List<string> uniqueNamesWithLinq = shopItems.Select(item => item.Name).Distinct().ToList();
//uniqueNames.ForEach(name => Console.WriteLine(name));

//Function programming

//Get The first item by name that is nor expired

//ShopItem firstShopItem = shopItems.Where(s => !s.Expired).OrderBy(s => s.Name).First();
//Console.WriteLine(firstShopItem.Name);

// Get the  biggest quantity of an item

int largestQuantity = shopItems.OrderByDescending(s =>s.Quantity).Select(s => s.Quantity).First();
Console.WriteLine(largestQuantity);

// Check if item named "Apple" exist
bool doesExist = shopItems.Any(si => si.Name.ToLower() == "apple");

//Get first item where QTY is more that 100
ShopItem item = shopItems.Where(si => si.Quantity > 100).FirstOrDefault();
if(item != null)
{
    Console.WriteLine(item.Name);
}
