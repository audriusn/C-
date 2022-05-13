using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApplication.Models;


namespace ShopApplication.Services
{
    public class ApplicationServices
    {
        private ShopServices _shopService;
        public ApplicationServices()
        {
            _shopService = new ShopServices();
        }
        public void Process(string command)
        {
            
                if (command.StartsWith("Add".ToLower()))
                {
                    try
                    {
                        string[] parts = command.Split(" ");
                    if (int.Parse(parts[2]) >= 0 && decimal.Parse(parts[3]) >= 0)

                        _shopService.Add(parts[1], int.Parse(parts[2]), decimal.Parse(parts[3]));
                    else
                        Console.WriteLine("You cannot add item with negative price or quantity");
                    }                               
                    catch (Exception)
                    {
                        Console.WriteLine("The command was not recognized");
                    }
                }
                else if (command.StartsWith("Remove".ToLower()))
                {
                    try
                    {
                        string[] splitCommand = command.Split(" ");
                        _shopService.Remove(splitCommand[1]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("The command was not recognized");
                    }
                 }
                else if (command.StartsWith("Show".ToLower()))            
                {
                    try
                    {
                        List<ShopItem> items = _shopService.GetAll();

                        items.ForEach(item => Console.WriteLine($"ItemName: {item.Name} ItemQuantity: {item.Quantity} ItemPrice: {item.Price}"));
                    }
                    catch (Exception)
                    {
                    Console.WriteLine("The command was not recognized");
                    }
                 }
                else if (command.StartsWith("Set".ToLower()))
                {
                    string[] splitCommand = command.Split(" ");
                    int quantity = int.Parse(splitCommand[2]);
                    _shopService.Update(splitCommand[1], quantity);
                }

                else if (command.StartsWith("Exit".ToLower()))
                {
                    Environment.Exit(0);
                }
                else if (command.StartsWith("Buy".ToLower()))
                {
                try
                {
                    string[] parts = command.Split(" ");

                    _shopService.Buy(parts[1], int.Parse(parts[2]));

                }
                catch (Exception)
                {
                    Console.WriteLine("The command was not recognized");
                }

                 }
                else if (command.StartsWith("Balance".ToLower()))
                {
                Console.WriteLine("Your balance is {0}:", _shopService.CustomerBalance());
                }

                else if (command.StartsWith("Cart".ToLower()))
                {
                try
                {
                    List<ShopItem> cart = _shopService.GetCart();

                    cart.ForEach(cart => Console.WriteLine($"ItemName: {cart.Name} "));
                }
                catch (Exception)
                {
                    Console.WriteLine("The command was not recognized");
                }
            }
                else if (command.StartsWith("Topup".ToLower()))
                {
                string[] parts = command.Split(" ");

                _shopService.Topup(decimal.Parse(parts[1]));
                Console.WriteLine("Top Up done. Your balance {0}:", _shopService.CustomerBalance());
            }
            else
                    Console.WriteLine("Incorret command");
          
        }
    }
}
