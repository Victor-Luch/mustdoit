using MustDoIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MustDoIt.Controllers
{
    public class HomeController : Controller
    {
        //створення контексту даних
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            //отримуємо з БД всі об'єкти Book
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            return View();
        }
        //При кліку на "купить" приймає "Id" книги
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Thanks," + purchase.Person + "for buy!";
        }

      
    }
}