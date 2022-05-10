using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagment.ConsoleApp.Services
{
    public class ApplicationService
    {
        private WarehouseService warehouseService;
        public void Process(string command)
        {
            if(command.StartsWith("Add"))
            {
                _warehouseService.Add();
            }
            if (command.StartsWith("Remove"))
            {
                _warehouseService.Remove();
            }
            if (command.StartsWith("List"))
            {
                _warehouseService.List();
            }
            if (command.StartsWith("Exit"))
            {
               return;
            }
            Console.WriteLine("INcorret command");
            //interpretet if command is valid 
            // parse the commans type and information
            // call valid WarehouseService coomand
        }
    }
}
