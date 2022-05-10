using System;
using ShopManegmentApp.Services;

namespace ShopManegmentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var applicationService = new ApplicationServices();
            while (true)
            {

                Console.WriteLine("Enter your command:");
                var command = Console.ReadLine();

                applicationService.Process(command);
            }
        }
    }
}
