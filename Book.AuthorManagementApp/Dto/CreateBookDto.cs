using Book.AuthorManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Book.AuthorManagementApp.Dto
{
    public class CreateBookDto
    {
        public Books Books { get; set; }
        public List<Author> Authors { get; set; }
    }
}
