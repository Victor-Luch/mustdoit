using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MustDoIt.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
    
    //Ініціалізація бази даних "BookContext" і стровення початкових даних
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Author = "Someone", Name = "Notbad", Price = 300 });
            db.Books.Add(new Book { Author = "People", Name = "Badman", Price = 30 });
            db.Books.Add(new Book { Author = "Me", Name = "Superpen", Price = 29 });

            base.Seed(db);
        }
    }
}