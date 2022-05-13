
using ShopApplication.Services;

var applicationService = new ApplicationServices();
while (true)
{
    Console.WriteLine("You are allowed to use these commands: Add, Remove, Show, Set, Balance, Topup, Buy, Cart, Exit");
    Console.WriteLine("Enter your command:");
    var command = Console.ReadLine().ToLower();

    applicationService.Process(command);
}