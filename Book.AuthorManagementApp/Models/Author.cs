using System.Collections.Generic;

namespace Book.AuthorManagementApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Books> Books { get; set; }

    }
}
