
using ShopApplication.Services;

var applicationService = new ApplicationServices();
while (true)
{

    Console.WriteLine("Enter your command:");
    var command = Console.ReadLine();

    applicationService.Process(command);
}