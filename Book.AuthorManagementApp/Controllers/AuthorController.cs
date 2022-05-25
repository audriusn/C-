using Book.AuthorManagementApp.Models;
using Book.AuthorManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.AuthorManagementApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var author = _authorService.GetAll();
            return View(author);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Author author = new Author();
            return View(author);
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            _authorService.Add(author);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string name)
        {
            _authorService.Delete(name);
            return RedirectToAction("Index");
        }
    }
}
