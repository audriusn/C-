using Microsoft.EntityFrameworkCore;
using Book.AuthorManagementApp.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.AuthorManagementApp.Data
{
    public class DataContext : DbContext 
    {
        public DbSet<Books> Books { get; set;}
        public DbSet<Author> Authors { get; set; }
        public object Author { get; internal set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
