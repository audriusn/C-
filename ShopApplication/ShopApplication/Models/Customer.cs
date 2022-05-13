using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    public class Customer
    {
        public decimal Wallet { get; set; }
        public Customer (decimal wallet = 20)
        {
            Wallet = wallet;
        }
    }
}
