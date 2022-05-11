using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManegmentApp.Models;

namespace ShopManegmentApp.Services
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
            if (command.StartsWith("Add"))
            {
                string[] splitCommand = command.Split(" ");
       
                for (int i = 0; i < _shopService.GetAll().Count; i++)
                { 
                    if (splitCommand[1].Equals(_shopService.GetAll()[i].Name))
                    {
                        Console.WriteLine("Sorry, this item is already in a lits");
                    }
                    
                    _shopService.Add(splitCommand[1], splitCommand[2]);
                }
   
            }
            else if (command.StartsWith("Remove"))
            {
                string[] splitCommand = command.Split(" ");
                _shopService.Remove(splitCommand[1]);
            }
            else if (command.StartsWith("Show"))
            {
                List<ShopItem> items = _shopService.GetAll();

                foreach (ShopItem item in items)
                {
                   
                    Console.WriteLine($"ItemName: {item.Name} ItemQty: {item.Quantity}");
                }
            }
            else if (command.StartsWith("Set"))
            {
                string[] splitCommand = command.Split(" ");
                _shopService.Update(splitCommand[1], splitCommand[2]);
            }

            else if (command.StartsWith("Exit"))
            {
              Environment.Exit(0);
            }
            else
                Console.WriteLine("Incorret command");
            
        }
    }
}
