using BookStore.DBOperations;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId); ;
            if (author is null)
                throw new InvalidOperationException(" Güncellenecek yazar bulunamadı ");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Books = Model.Books != default ? Model.Books : author.Books;
            
            _dbContext.SaveChanges();


        }


        public class UpdateAuthorModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime Dob { get; set; }
            public ICollection<Book> Books { get; set; }

        }

    }
}

