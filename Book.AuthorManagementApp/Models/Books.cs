using System;

namespace Book.AuthorManagementApp.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public Author Author { get; set;}

        public int? AuthorId { get; set; }

    }
}
