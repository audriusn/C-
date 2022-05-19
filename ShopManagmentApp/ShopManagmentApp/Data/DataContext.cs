using Microsoft.EntityFrameworkCore;
using ShopManagmentApp.Models;


namespace ShopManagmentApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ShopItem> ShopItems { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
