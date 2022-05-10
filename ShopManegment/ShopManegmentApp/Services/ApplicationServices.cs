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

                _shopService.Add(splitCommand[1], splitCommand[2]);
            }
            else if (command.StartsWith("Remove"))
            {
                string[] splitCommand = command.Split(" ");
                _shopService.Remove(splitCommand[1]);
            }
            else if (command.StartsWith("List"))
            {
                List<ShopItem> items = _shopService.GetAll();

                foreach (ShopItem item in items)
                {
                   
                    Console.WriteLine($"ItemName: {item.Name} ItemQty: {item.Qty}");
                }
            }
            else if (command.StartsWith("Exit"))
            {
                return;
            }
            else
                Console.WriteLine("Incorret command");
            
        }
    }
}
