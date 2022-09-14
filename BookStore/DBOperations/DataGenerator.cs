using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initilaze(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Personal Growrth"
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
                context.SaveChanges();
                }
            }
        }
    }
