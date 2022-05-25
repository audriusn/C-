using Book.AuthorManagementApp.Data;
using Book.AuthorManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Book.AuthorManagementApp.Services
{
 
        public class AuthorService
        {
            private DataContext _dataContext;

            public AuthorService(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public List<Author> GetAll()
            {
                return _dataContext.Authors.ToList();
            }
            public void Add(Author author)
            {
                _dataContext.Authors.Add(author);
                _dataContext.SaveChanges();
            }
            public void Delete(string name)
            {
                var author = _dataContext.Authors.FirstOrDefault(y => y.Name == name);
                _dataContext.Authors.Remove(author);
                _dataContext.SaveChanges();
            }

        }
    }

