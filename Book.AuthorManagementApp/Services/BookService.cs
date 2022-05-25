using Book.AuthorManagementApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Book.AuthorManagementApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Book.AuthorManagementApp.Services
{
    public class BookService
    {

        private DataContext _dataContext;

        public BookService (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Books> GetAll()
        {
            return _dataContext.Books.Include(b =>b.Author).ToList();
        }

        public void Add(Books books)
        {
            _dataContext.Books.Add(books);
            _dataContext.SaveChanges();
        }
        public Books Get(string title)
        {
            return _dataContext.Books.FirstOrDefault(x => x.Title == title);
        }

        public void Delete(string title)
        {
            var book = _dataContext.Books.FirstOrDefault(y => y.Title == title);
            _dataContext.Books.Remove(book);
            _dataContext.SaveChanges();
        }
        public void Update(Books books)
        {
            var item = Get(books.Title);
            item.Title = books.Title;
            item.AuthorName = books.AuthorName;
            _dataContext.SaveChanges();
        }
    }
}
