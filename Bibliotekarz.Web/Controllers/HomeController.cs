using Bibliotekarz.Data.Context;
using Bibliotekarz.Data.Model;
using Bibliotekarz.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bibliotekarz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotekarzDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, BibliotekarzDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;

            dbContext.Database.Migrate();
        }

        public IActionResult Index()
        {
            IndexViewModel vm = GetBooks();
            return View(vm);
        }

        private IndexViewModel GetBooks()
        {
            IndexViewModel result = new IndexViewModel();
            result.BookList = dbContext.Books.Include(x => x.Borrower).ToList();

            //var books = dbContext.Books
            //    .Where(book => book.PageCount > 10 && book.IsBorrowed == true)
            //    .Where(book => book.Title.Contains("Les"))
            //    .OrderBy(book => book.Author).ThenByDescending(book => book.Title)
            //    .Skip(10).Take(10)
            //    .Select(book => new { book.Author, book.Title })
            //    .FirstOrDefault()
            //    .ToList();

            //if (result.BookList.All(b => b.IsBorrowed == true))

                //result.BookList = new List<Book>()
                //{
                //    new Book()
                //    {
                //        Id = 1,
                //        Author = "Leszek Lewandowski",
                //        Title = "Programowanie w C#",
                //        PageCount = 456,
                //        IsBorrowed = true,
                //        Borrower = new Customer
                //        {
                //            Id = 1,
                //            FirstName = "Jan",
                //            LastName = "Kowalski"
                //        }
                //    },
                //    new Book()
                //    {
                //        Id = 2,
                //        Author = "John Sharp",
                //        Title = "ASP.NET for newbees",
                //        PageCount = 554,
                //        IsBorrowed = false                    
                //    }
                //};
                return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id, string name)
        {
            EditViewModel vm = new EditViewModel()
            {
                Book = new Book()
                {
                    Borrower = new Customer()
                }
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel vm)
        {
            if (vm != null)
            {
                if (!vm.Book.IsBorrowed)
                {
                    vm.Book.Borrower = null;
                }

                dbContext.Books.Add(vm.Book);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}