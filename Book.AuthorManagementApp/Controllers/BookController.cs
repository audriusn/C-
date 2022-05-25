using Book.AuthorManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Book.AuthorManagementApp.Models;
using Book.AuthorManagementApp.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Book.AuthorManagementApp.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;


        public BookController(BookService bookService, AuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            return View(books);
        }
        [HttpGet]
        public IActionResult Add()
        {
            CreateBookDto book = new CreateBookDto();
            book.Books = new Models.Books();
            book.Authors = _authorService.GetAll();
            return View(book);
        }
        [HttpPost]
        public IActionResult Add(CreateBookDto createBookDto)
        {
            _bookService.Add(createBookDto.Books);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string title)
        {
            _bookService.Delete(title);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string title)
        {
            var book = _bookService.Get(title);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Books book)
        {
            _bookService.Update(book);
            return RedirectToAction("Index");
        }


    }
}

