using BookStore.DBOperations;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Personal Growrth"
                   },
                   new Genre
                   {
                       Name = "Science Fiction"
                   },
                   new Genre
                   {
                       Name = "Romance",
                   }
                   );

        }
    }
}
