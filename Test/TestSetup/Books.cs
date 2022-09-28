using BookStore.DBOperations;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                   new Book
                   {
                       // Id = 1,
                       Title = " Book",
                       GenreId = 1,
                       PageCount = 1,
                       PublishDate = new DateTime(2001, 06, 12)
                   }
                   );
        }
    }
}
