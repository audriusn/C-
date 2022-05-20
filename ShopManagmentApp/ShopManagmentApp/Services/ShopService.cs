using ShopManagmentApp.Data;
using ShopManagmentApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagmentApp.Services
{
    public class ShopService
    {
        private DataContext _dataContext;

        public ShopService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Shop> GetAll()
        {
            return _dataContext.Shops.ToList();
        }
        public void Add(Shop shop)
        {
            _dataContext.Shops.Add(shop);
            _dataContext.SaveChanges();
        }
        public void Delete(string name)
        {
            var item = _dataContext.Shops.FirstOrDefault(y => y.Name == name);
            _dataContext.Shops.Remove(item);
            _dataContext.SaveChanges();
        }

    }
}
