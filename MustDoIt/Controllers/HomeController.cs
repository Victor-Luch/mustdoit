using MustDoIt.Models;
using MustDoIt.Util;
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
        //Get метод явий передає вюшку
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
        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public string PostBook()
        {
            string title = Request.Form["title"];
            string author = Request.Form["author"];
            return title + " " + author;
        }
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }
        public ActionResult GetImage()
        {
            string path = "../Content/Images/Безымянный.png";
            return new ImageResult(path);
        }

    }
}